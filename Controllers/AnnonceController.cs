using coproBox.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace coproBox.Controllers
{
    public class AnnonceController : Controller
    {
        private IDal dal;
        private IWebHostEnvironment _webEnv;
        public AnnonceController(IWebHostEnvironment environment)
        {
            _webEnv = environment;
            this.dal = new Dal();
        }
 
        public IActionResult AfficherAnnonce()
        {
            List<Annonce> listeDesAnnonces = dal.ObtientToutesLesAnnonces();
            return View(listeDesAnnonces);
        }

        public IActionResult CreerAnnonce()

        {
            return View();
        }


        [HttpPost]
        public ActionResult Creer(Annonce annonce)

        public IActionResult AfficherAnnonce()



        {
            
            if (!ModelState.IsValid)
                return View(annonce);
            dal.CreerAnnonce(annonce.Titre, annonce.Description, annonce.TauxHoraire, annonce.Tarif, annonce.DateDebut, annonce.DateFin, annonce.TypeService);
            return RedirectToAction("AfficherAnnonce");
        }

        //modifier
    }
}
