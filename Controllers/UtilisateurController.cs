using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coproBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class UtilisateurController : Controller
    {

        private IDal dal;

        public UtilisateurController()
        {
            this.dal = new Dal();
        }


        public IActionResult Index()
        {
            List<Utilisateur> listeDesUtilisateurs = dal.ObtientTousLesUtilisateurs();
            return View(listeDesUtilisateurs);
        }

        public IActionResult CreerUtilisateur()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreerUtilisateur(Utilisateur utilisateur) // sans annotation, par défaut, il s'agit d'un méthode http GET
        {
            if (!ModelState.IsValid)
                return View(utilisateur);

            if (dal.ObtientTousLesUtilisateurs().FirstOrDefault (u => u.InfosPersonnelle.Nom == utilisateur.InfosPersonnelle.Nom && u.InfosPersonnelle.Prenom == utilisateur.InfosPersonnelle.Prenom && u.Compte.email == utilisateur.Compte.email) !=null)
            {
                ModelState.AddModelError("Utilisateur", "Cet utilisateur est déjà enregistré");
                return View(utilisateur);
            }

            dal.CreerUtilisateur(utilisateur.InfosPersonnelle.Nom, utilisateur.InfosPersonnelle.Prenom, utilisateur.Adresse.numeroRue, utilisateur.Adresse.nomRue, utilisateur.Adresse.codePostal, utilisateur.Adresse.nomVille, utilisateur.Compte.email);
            return RedirectToAction("Index");
        }

        public IActionResult ModifierUtilisateur(int id) // sans annotation, par défaut, il s'agit d'un méthode http GET
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Utilisateur utilisateur = dal.ObtientTousLesUtilisateurs().Where(r => r.Id == id).FirstOrDefault();
                    if (utilisateur == null)
                    {
                        return View("Error");
                    }
                    return View(utilisateur);
                }
            }
            return View("Error");
        }

    }
}

/*Utilisateur.InfosPersonnelle.Nom = utilisateur.InfosPersonnelle.Nom;
Utilisateur.InfosPersonnelle.Prenom = utilisateur.InfosPersonnelle.Prenom;
Utilisateur.InfosPersonnelle.dateNaissance = utilisateur.InfosPersonnelle.dateNaissance;
Utilisateur.Adresse.numeroPorte = Utilisateur.Adresse.numeroPorte;
Utilisateur.Adresse.numeroRue = Utilisateur.Adresse.numeroRue;
Utilisateur.Adresse.nomRue = Utilisateur.Adresse.nomRue;
Utilisateur.Adresse.codePostal = Utilisateur.Adresse.codePostal;
Utilisateur.Adresse.nomVille = Utilisateur.Adresse.nomVille;
Utilisateur.Compte.numeroIdentifiant = Utilisateur.Compte.numeroIdentifiant;
Utilisateur.Compte.role = Utilisateur.Compte.role;
Utilisateur.Compte.motDePasse = Utilisateur.Compte.motDePasse;
Utilisateur.Compte.email = Utilisateur.Compte.email;
Utilisateur.InfosContact.telephone = Utilisateur.InfosContact.telephone; */
