using System;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class ProfilController : Controller
    {
        public IActionResult Profil()
        {
            return View();
        }
    }
}

