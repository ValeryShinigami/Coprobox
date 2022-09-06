using System;
using coproBox.Models;
using coproBox.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class HomeController : Controller
    {
        private IDal dal;

        public HomeController()
        {
            this.dal = new Dal();
        }

        public ActionResult Index()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                viewModel.Utilisateur = dal.ObtenirUtilisateur(userId);
                return Redirect("/utilisateur");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UtilisateurViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Utilisateur utilisateur = dal.Authentifier(viewModel.Utilisateur.Compte.email, viewModel.Utilisateur.Compte.motDePasse);
                InfosPersonnelle infosPerso = dal.ObtenirUtilisateur(utilisateur.Id).InfosPersonnelle;
                if (utilisateur != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, infosPerso.Prenom),
                        new Claim(ClaimTypes.NameIdentifier, utilisateur.Id.ToString()),
                        //new Claim(ClaimTypes.Role, utilisateur.Role.ToString()),
                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/utilisateur");
                }
                //ModelState.AddModelError("Utilisateur.Prenom", "Prénom et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}

