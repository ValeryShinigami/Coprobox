using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using coproBox.Models;
using coproBox.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace coproBox.Controllers
{
    public class UtilisateurController : Controller
    {
     
        private IWebHostEnvironment _webEnv;


        private IDal dal;

        public UtilisateurController(IWebHostEnvironment environment)
        {
            _webEnv = environment;
            this.dal = new Dal();
        }
    
        public IActionResult Index()
        {
            DashboardViewModel dashboardModerateurViewModel = new DashboardViewModel()
            {
                Utilisateurs = dal.ObtientTousLesUtilisateurs(),
                Annonces = dal.ObtientToutesLesAnnonces(),
                Cagnottes = dal.ObtientToutesLesCagnottes(),
                //Paiements = dal.ObtientTousSesPaiements(Int32.Parse(User.Identity.Name))
            };
            return View(dashboardModerateurViewModel);
        }

        public IActionResult ListeUtilisateur()
        {
            List<Utilisateur> listeDesUtilisateurs = dal.ObtientTousLesUtilisateurs();
            return View(listeDesUtilisateurs);
        }

        //public IActionResult ListeRole()
        //{
        //    List<Role> listeDesRoles = dal.ObtientTousLesRoles();
        //    return View(listeDesRoles);
        //}

        //**********************************$CREER UTILISATEUR **************************
        public IActionResult CreerUtilisateur()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreerUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return View(utilisateur);

            //string uploads = Path.Combine(_webEnv.WebRootPath, "Image");
            //string filePath = Path.Combine(uploads, utilisateur.Image.FileName);
            //using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    utilisateur.Image.CopyTo(fileStream);
            //}
            if (dal.ObtientTousLesUtilisateurs().FirstOrDefault (u => u.Compte.email == utilisateur.Compte.email) !=null)
                {
                    ModelState.AddModelError("email", "Cet email est déjà enregistré");
                    return View(utilisateur);
                }
          
                dal.CreerUtilisateur(
                utilisateur.InfosPersonnelle.Nom, utilisateur.InfosPersonnelle.Prenom, utilisateur.Compte.email, utilisateur.Compte.motDePasse, utilisateur.Compte.Role, utilisateur.Compte.estProprietaire );
            return RedirectToAction("CreerUtilisateur"); // en attente de voir vers où le user sera redirigé

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
        public IActionResult ModifierUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return View(utilisateur);

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

