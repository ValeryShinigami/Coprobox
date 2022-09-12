using coproBox.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Index()
        {
            
            return View();
        }


    }
}
