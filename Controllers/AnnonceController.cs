using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class AnnonceController : Controller
    {
        public IActionResult CreerAnnonce()
        {
            return View();
        }

        public IActionResult AfficherAnnonce()
        {
            return View();
        }
    }
}
