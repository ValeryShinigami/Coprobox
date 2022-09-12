using coproBox.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;

namespace coproBox.Controllers
{
    [Authorize]
    public class CagnotteController : Controller
    {
        private IWebHostEnvironment _webEnv;

        private IDal dal;

        public CagnotteController(IWebHostEnvironment environment)
        {
            _webEnv = environment;
            this.dal = new Dal();
        }

        public IActionResult Index()
        {
            List<Cagnotte> listeDesCagnottes = dal.ObtientToutesLesCagnottesActives();
            return View(listeDesCagnottes);
        }

        [Authorize(Roles = "Administrateur,Moderateur")]
        public IActionResult CreerCagnotte()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrateur,Moderateur")]
        public IActionResult CreerCagnotte(Cagnotte cagnotte)
        {
            if(!ModelState.IsValid)
                return View(cagnotte);
            if(dal.ObtientToutesLesCagnottes().Find(c => c.Titre == cagnotte.Titre) != null)
            {
                ModelState.AddModelError("Titre", "Ce titre de cagnotte existe déjà");
                return View(cagnotte);
            }

            dal.CreerCagnotte(cagnotte);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrateur,Moderateur")]
        public IActionResult ModifierCagnotte(int Id)
        {
            Cagnotte Cagnotte = dal.ObtientToutesLesCagnottes().Find(c => c.Id == Id);
            if(Cagnotte == null)
            {
                return View("Error");
            }
            return View(Cagnotte);
        }

        [HttpPost]
        [Authorize(Roles = "Administrateur,Moderateur")]
        public IActionResult ModifierCagnotte(Cagnotte cagnotte)
        {
            if(!ModelState.IsValid)
                return View(cagnotte);
            
            dal.ModifierCagnotte(cagnotte);
            return RedirectToAction("Index");
        }

        public IActionResult AnciennesCagnottes(int id)
        {
            ViewData["page"] = id;
            ViewData["reste"] = dal.CombienDeCagnottesApres(id);
            List<Cagnotte> listeDesCagnottes = dal.ObtientCertainesAnciennesCagnottes(id);
            return View(listeDesCagnottes);
        }

        public IActionResult InfoCagnotte(int id)
        {
            Cagnotte cagnotte = dal.ObtientToutesLesCagnottes().Find(c => c.Id == id);
            if(cagnotte == null)
            {
                return View("Error");
            }
            return View(cagnotte);
        }

        [HttpPost]
        public IActionResult InfoCagnotte(int id, int Montant)
        {
            Cagnotte cagnotte = dal.ObtientToutesLesCagnottes().Find(c => c.Id == id);
            if (Montant <= 0 || cagnotte == null)
            {
                return View("Error");
            }
            cagnotte.SommeActuelle += Montant;

            ClaimsPrincipal currentUser = this.User;
            int currentUserID = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            ParticipationCagnotte participationCagnotte = new ParticipationCagnotte()
            {
                CagnotteId = cagnotte.Id,
                Montant = Montant,
                UtilisateurId = currentUserID
            };
            dal.ModifierCagnotte(cagnotte);
            dal.CreerParticipationCagnotte(participationCagnotte);
            return RedirectToAction("Index");
        }
    }
}
