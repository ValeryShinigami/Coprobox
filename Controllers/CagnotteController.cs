using coproBox.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace coproBox.Controllers
{
    public class CagnotteController : Controller
    {
        private IDal dal;

        public CagnotteController()
        {
            this.dal = new Dal();
        }

        public IActionResult Index()
        {
            List<Cagnotte> listeDesCagnottes = dal.ObtientToutesLesCagnottes();
            return View(listeDesCagnottes);
        }

        public IActionResult CreerCagnotte()
        {
            return View();
        }

        [HttpPost]
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

        public IActionResult AnciennesCagnottes(int id)
        {
            ViewData["page"] = id;
            ViewData["reste"] = dal.CombienDeCagnottesApres(id);
            List<Cagnotte> listeDesCagnottes = dal.ObtientCertainesAnciennesCagnottes(id);
            return View(listeDesCagnottes);
        }
    }
}
