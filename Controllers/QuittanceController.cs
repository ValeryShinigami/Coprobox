using coproBox.Models;
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
            quittance.Statut = Statut.Creee;
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
    }
}
