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
    }
}
