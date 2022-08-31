using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class AnnonceController : Controller
    {
        public IActionResult Annonce()
        {
            return View();
        }
    }
}
