using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coproBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class CompteController : Controller
    {
        public IActionResult Compte()
        {
            return View();
        }

        public IActionResult ModifierCompte(int Id) // sans annotation, par défaut, il s'agit d'un méthode http GET
        {
            if (Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Compte compte = dal.ObtientTousLesComptes().Where(r => r.Id == Id).FirstOrDefault();
                    if (compte == null)
                    {
                        return View("Error");
                    }
                    return View(compte);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult ModifierCompte(Compte compte)
        {

            if (compte.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierCompte(compte.Id, compte.numeroIdentifiant ,compte.role, compte.motDePasse, compte.codeIban);
                    return RedirectToAction("ModifierCompte", new { @id = compte.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }
    }
}