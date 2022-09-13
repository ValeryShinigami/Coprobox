using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using coproBox.Models;
using coproBox.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    [Authorize]
    public class UtilisateurController : Controller
    {
     
        private IWebHostEnvironment _webEnv;


        private IDal dal;

        public UtilisateurController(IWebHostEnvironment environment)
        {
            _webEnv = environment;
            this.dal = new Dal();
        }
    
        public IActionResult Index()
        {
            DashboardViewModel dashboardViewModel = new DashboardViewModel()
            {
                Utilisateurs = dal.ObtientTousLesUtilisateurs(),
                AnnoncesAVerifier = dal.ObtientLesAnnoncesAVerifier(),
                AnnoncesPerso = dal.ObtientToutesSesAnnonces(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))),
                Cagnottes = dal.ObtientToutesLesCagnottesActives(),
                Paiements = dal.ObtientTousSesPaiements(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))),
                Reservations = dal.ObtientToutesSesReservations(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))),
                ParticipationCagnottes = dal.ObtientToutesSesParticipationCagnottes(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            };
            return View(dashboardViewModel);
        }

        public IActionResult ListeUtilisateur()
        {
            List<Utilisateur> listeDesUtilisateurs = dal.ObtientTousLesUtilisateurs();
            return View(listeDesUtilisateurs);
        }

        /**********************************$CREER UTILISATEUR **************************/
        [Authorize(Roles = "Administrateur")]
        public IActionResult CreerUtilisateur()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        public IActionResult CreerUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return View(utilisateur);

            if (dal.ObtientTousLesUtilisateurs().FirstOrDefault (u => u.Compte.email == utilisateur.Compte.email) !=null)
                {
                    ModelState.AddModelError("email", "Cet email est déjà enregistré");
                    return View(utilisateur);
                }
          
                dal.CreerUtilisateur(
                utilisateur.InfosPersonnelle.Nom, utilisateur.InfosPersonnelle.Prenom, utilisateur.Compte.email, utilisateur.Compte.motDePasse, utilisateur.Compte.Role, utilisateur.Compte.estProprietaire);
                return RedirectToAction("CreerUtilisateur"); // en attente de voir vers où le user sera redirigé

        }

        //MODIFIER UN UTILISATEUR
        public IActionResult ModifierUtilisateur(int id) // sans annotation, par défaut, il s'agit d'un méthode http GET
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Utilisateur utilisateur = dal.ObtientTousLesUtilisateurs().Where(r => r.Id == id).FirstOrDefault();
                    if (utilisateur == null)
                    {
                        return View("Error");
                    }
                    return View(utilisateur);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult ModifierUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return View(utilisateur);

            dal.ModifierUtilisateur(utilisateur);
            return RedirectToAction("Index");
        }

        //MODIFIER UN MOT DE PASSE
        //GET
        public IActionResult ModifierMotDePasse(int id) // sans annotation, par défaut, il s'agit d'un méthode http GET
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModifierMotDePasse(int id, string Oldpwd, string Newpwd)
        {
            Utilisateur utilisateur = dal.ObtenirUtilisateur(id);
            if (dal.EncodeMD5(Oldpwd) == utilisateur.Compte.motDePasse)
            {
                utilisateur.Compte.motDePasse = dal.EncodeMD5(Newpwd);
            }
            dal.ModifierUtilisateur(utilisateur);
            return RedirectToAction("Index");
        }

        //SUPPRIMER UN UTILISATEUR
        [Authorize(Roles = "Administrateur")]
        public IActionResult SupprimerUtilisateur (int id) // sans annotation, par défaut, il s'agit d'un méthode http GET
        {
            dal.SupprimerUtilisateur(id);
            return RedirectToAction("Index");
        }
    }
}



