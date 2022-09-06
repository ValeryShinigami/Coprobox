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
            return View();
        }

        public IActionResult ListeUtilisateur()
        {
            List<Utilisateur> listeDesUtilisateurs = dal.ObtientTousLesUtilisateurs();
            return View(listeDesUtilisateurs);
        }

        //**********************************$CREER UTILISATEUR **************************
<<<<<<< HEAD
        public IActionResult CreerUtilisateur()
        {
=======
        public IActionResult CreerUtilisateur()
        {
>>>>>>> 6097aee422d09ec2513b2f58014a656a6c6f002d
            return View();
        }

        [HttpPost]
        public IActionResult CreerUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
<<<<<<< HEAD
                return View(utilisateur);

            if (dal.ObtientTousLesUtilisateurs().FirstOrDefault (u => u.Compte.email == utilisateur.Compte.email) !=null)
                {
                    ModelState.AddModelError("email", "Cet email est déjà enregistré");
                    return View(utilisateur);
                }
            dal.CreerUtilisateur(utilisateur);
            return RedirectToAction("CreerUtilisateur"); // en attente de voir vers où le user sera redirigé
=======
                return View(utilisateur);

            if (dal.ObtientTousLesUtilisateurs().FirstOrDefault (u => u.Compte.email == utilisateur.Compte.email) !=null)
                {
                    ModelState.AddModelError("email", "Cet email est déjà enregistré");
                    return View(utilisateur);
                }
            dal.CreerUtilisateur(utilisateur);
            return RedirectToAction("CreerUtilisateur"); // en attente de voir vers où le user sera redirigé

>>>>>>> 6097aee422d09ec2513b2f58014a656a6c6f002d
        }

        //MODIFIER UN UTILISATEUR
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

        [HttpPost]
<<<<<<< HEAD
        public IActionResult ModifierUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return View(utilisateur);

            
=======
        public IActionResult ModifierUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return View(utilisateur);
>>>>>>> 6097aee422d09ec2513b2f58014a656a6c6f002d
            dal.ModifierUtilisateur(utilisateur);
            return RedirectToAction("Index");
        }

    }
}

/*Utilisateur.InfosPersonnelle.Nom = utilisateur.InfosPersonnelle.Nom; OK
Utilisateur.InfosPersonnelle.Prenom = utilisateur.InfosPersonnelle.Prenom; OK
Utilisateur.InfosPersonnelle.dateNaissance = utilisateur.InfosPersonnelle.dateNaissance; OK
Utilisateur.Adresse.numeroPorte = Utilisateur.Adresse.numeroPorte; OK
Utilisateur.Adresse.numeroRue = Utilisateur.Adresse.numeroRue; OK
Utilisateur.Adresse.nomRue = Utilisateur.Adresse.nomRue; OK
Utilisateur.Adresse.codePostal = Utilisateur.Adresse.codePostal; OK
Utilisateur.Adresse.nomVille = Utilisateur.Adresse.nomVille;
Utilisateur.Compte.numeroIdentifiant = Utilisateur.Compte.numeroIdentifiant;
Utilisateur.Compte.role = Utilisateur.Compte.role;
Utilisateur.Compte.motDePasse = Utilisateur.Compte.motDePasse; OK
Utilisateur.Compte.email = Utilisateur.Compte.email; OK
Utilisateur.InfosContact.telephone = Utilisateur.InfosContact.telephone;  OK */
