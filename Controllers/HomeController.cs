using System;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}

