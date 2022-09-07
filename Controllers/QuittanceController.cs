using coproBox.Models;
using coproBox.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class QuittanceController : Controller
    {
        private IDal dal;

        public QuittanceController()
        {
            this.dal = new Dal();
        }

        public IActionResult CreerQuittance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreerQuittance(Quittance quittance)
        {
            if (!ModelState.IsValid)
                return View(quittance);
            quittance.StatutQuittance = StatutQuittance.Creee;
            dal.CreerQuittance(quittance);
            return RedirectToAction("Index");
        }

        public IActionResult ModifierQuittance(int Id)
        {
            Quittance Quittance = dal.ObtientTouteslesQuittances().Find(q => q.Id == Id);
            if (Quittance == null)
            {
                return View("Error");
            }
            return View(Quittance);
        }

        [HttpPost]
        public IActionResult ModifierQuittance(Quittance quittance)
        {
            if (!ModelState.IsValid)
                return View(quittance);

            dal.ModifierQuittance(quittance);
            return RedirectToAction("Index");
        }

        public IActionResult AfficherQuittance(int Id)
        {
            Quittance quittance = dal.ObtientTouteslesQuittances().Find(q => q.Id == Id);
            Utilisateur utilisateur = dal.ObtenirUtilisateur((int)quittance.LocataireId);

            QuittanceViewModel QuittanceViewModel = new QuittanceViewModel
            {
                Quittance = quittance,
                Utilisateur = utilisateur
            };
            
            return View(QuittanceViewModel);
        }
    }
}
