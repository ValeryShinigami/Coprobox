using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coproBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class AdresseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModifierAdresse(int id) // sans annotation, par défaut, il s'agit d'un méthode http GET
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Adresse adresse = dal.ObtientToutesLesAdresses().Where(r => r.Id == id).FirstOrDefault();
                    if (adresse == null)
                    {
                        return View("Error");
                    }
                    return View(adresse);
                }
            }
            return View("Error");
        }

       /* [HttpPost]
        public IActionResult ModifierAdresse(Adresse adresse)
        {

            if (adresse.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierAdresse(adresse.Id, adresse.numeroPorte, adresse.numeroRue, adresse.nomRue, adresse.codePostal);
                    return RedirectToAction("ModifierAdresse", new { @id = adresse.Id });
                }
            }
            else
            {
                return View("Error");
            }
        } */
    }
}