using coproBox.Models;
using coproBox.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace coproBox.Controllers
{
    public class PaiementController : Controller
    {
        private IDal dal;
        private IWebHostEnvironment _webEnv;
        public PaiementController(IWebHostEnvironment environment)
        {
            _webEnv = environment;
            this.dal = new Dal();
        }
        public IActionResult PaiementAnnonce(int id)
        {

           Annonce annonce = dal.ObtenirUneAnnonce(id);
            return View(annonce);
    
        }
        [HttpPost]
        public IActionResult PaiementAnnonce(int id, string cb)
        {
            Paiement paiement = new Paiement()
            {
                UtilisateurId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                AnnonceId = id
            };

            dal.CreerPaiement(paiement);
            Annonce annonce = dal.ObtenirUneAnnonce(id);
            return RedirectToAction("Index", "Annonce");
        }


    }
}
