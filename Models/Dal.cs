using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace coproBox.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext; // je fais appel à bddC qui est un champ de la classe BddContexte

        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();     // permet de mettre à jour et recréer une nouvelle BDD - peut être rajouter dans le StartUp (pour un démarrage au début de l'app uniquement
        }


        //UTILISATEURS
        public List<Utilisateur> ObtientTousLesUtilisateurs() // permet de retourner tous les séjours sous forme de liste
        {
            return _bddContext.Utilisateurs.Include(u => u.Compte).Include(u => u.Adresse).Include(u => u.InfosPersonnelle).Include(u => u.InfosContact).Include(u => u.Profil).Include(u => u.Notification).ToList();

            //return _bddContext.Utilisateurs.Include(u=> u.Compte).Include.(u=>u.Adresse).ToList();
            // .Include permet de créer une jointure... et d'afficher ou modifier des clés étrangères.
        }

        public int CreerUtilisateur(Utilisateur utilisateur)
        {
            InfosPersonnelle infosPersonnelle = new InfosPersonnelle { Nom = utilisateur.InfosPersonnelle.Nom, Prenom = utilisateur.InfosPersonnelle.Prenom };
            string password = EncodeMD5(utilisateur.Compte.motDePasse);
            Compte compte = new Compte { email = utilisateur.Compte.email, motDePasse = password};
            Adresse adresse = new Adresse();
            InfosContact infosContact = new InfosContact();
            Profil profil = new Profil();
            Notification notification = new Notification();


              Utilisateur Utilisateur = new Utilisateur { InfosPersonnelle = infosPersonnelle, Compte = compte, Adresse= adresse, InfosContact = infosContact, Profil = profil,
              Notification = notification}; // j'instancie Compte et je lui transmet ce que l'utilisateur écrira. J'instancie mais je dois également le rajouter dans la BDD de la liste de séjour via bddContext
              _bddContext.Utilisateurs.Add(Utilisateur);
              _bddContext.SaveChanges();
              return utilisateur.Id;
          }


        public void ModifierUtilisateur(Utilisateur utilisateur)
        {
            Utilisateur Utilisateur = _bddContext.Utilisateurs.Include(u => u.Compte).Include(u => u.Adresse).Include(u => u.InfosPersonnelle)
            .Include(u => u.InfosContact).Include(u => u.Profil).Include(u => u.Notification).FirstOrDefault(u => u.Id==utilisateur.Id);
           
            if (Utilisateur != null)
            {
                Utilisateur.InfosPersonnelle.Nom = utilisateur.InfosPersonnelle.Nom;
                Utilisateur.InfosPersonnelle.Prenom = utilisateur.InfosPersonnelle.Prenom;
                if (utilisateur.InfosPersonnelle.dateNaissance != null)  
                    Utilisateur.InfosPersonnelle.dateNaissance  = utilisateur.InfosPersonnelle.dateNaissance;
                if (utilisateur.Adresse.NumeroPorte != null)
                    Utilisateur.Adresse.NumeroPorte = utilisateur.Adresse.NumeroPorte;
                if (utilisateur.Adresse.AdressePrincipale != null)
                    Utilisateur.Adresse.AdressePrincipale = utilisateur.Adresse.AdressePrincipale;
                if (utilisateur.Adresse.CodePostal != 0)
                    Utilisateur.Adresse.CodePostal = utilisateur.Adresse.CodePostal;
                if (utilisateur.Adresse.Ville != null)
                    Utilisateur.Adresse.Ville = utilisateur.Adresse.Ville;
                if(utilisateur.Compte.numeroIdentifiant != null)
                    Utilisateur.Compte.numeroIdentifiant = utilisateur.Compte.numeroIdentifiant;
                if(utilisateur.Compte.role != null)
                    Utilisateur.Compte.role = utilisateur.Compte.role;
                Utilisateur.Compte.motDePasse = utilisateur.Compte.motDePasse;

                Utilisateur.Compte.email = utilisateur.Compte.email;
                if (utilisateur.InfosContact.telephone != null)
                    Utilisateur.InfosContact.telephone = utilisateur.InfosContact.telephone;

                _bddContext.SaveChanges();
            }
        }

        public Utilisateur Authentifier(string email, string motdepasse)
        {
            string motDePasse = /*EncodeMD5(*/motdepasse/*)*/;
            Utilisateur user = this._bddContext.Utilisateurs.FirstOrDefault(u => u.Compte.email == email && u.Compte.motDePasse == motDePasse);
            return user;
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return this._bddContext.Utilisateurs.Include(u => u.Compte).Include(u => u.Adresse).Include(u => u.InfosPersonnelle).Include(u => u.InfosContact).Include(u => u.Profil).Include(u => u.Notification).FirstOrDefault(u => u.Id == id);
        }

        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirUtilisateur(id);
            }
            return null;
        }

        // ANNONCE DEBUT
        public void CreerAnnonce(string titre, string description, string tauxHoraire, int tarif, DateTime dateDebut, DateTime dateFin, TypeService typeService, int id = 0)
        {
            Utilisateur utilisateur = ObtenirUtilisateur(id);

            Annonce annonceToAdd = new Annonce { Titre = titre, Description = description, TauxHoraire = tauxHoraire, Tarif = tarif, DateDebut = dateDebut, DateFin = dateFin, TypeService = typeService, Utilisateur=utilisateur, InfosPersonnelle =  utilisateur.InfosPersonnelle};

           
            this._bddContext.Annonces.Add(annonceToAdd);
            this._bddContext.SaveChanges();
        }

        public List<Annonce> ObtientToutesLesAnnonces()
        {
            return _bddContext.Annonces.Include(a => a.Utilisateur).Include(a => a.InfosPersonnelle).Include(a => a.Compte).ToList();
        }

        public void SupprimerAnnonce(int id)
        {
            Annonce annonceToDelete = this._bddContext.Annonces.Find(id);
            this._bddContext.Annonces.Remove(annonceToDelete);
            this._bddContext.SaveChanges();
        }

        //supprimer annonce suite

        //modifier annonce
        public void ModifierAnnonce(int id, string titre, string description, string tauxHoraire, int tarif, DateTime dateDebut, DateTime dateFin, TypeService typeService, string imagePath)
        {
            Annonce annonceToUpdate = this._bddContext.Annonces.Find(id);
            if (annonceToUpdate != null)
            {
                annonceToUpdate.Titre = titre;
                annonceToUpdate.Description = description;
                annonceToUpdate.TauxHoraire = tauxHoraire;
                annonceToUpdate.Tarif = tarif;
                annonceToUpdate.DateDebut = dateDebut;
                annonceToUpdate.DateFin = dateFin;
                annonceToUpdate.TypeService=typeService;
                annonceToUpdate.ImagePath = imagePath;
                this._bddContext.SaveChanges();
            }
        }



        //ANNONCE FIN 

        // CAGNOTTE

        public List<Cagnotte> ObtientToutesLesCagnottes()
        {
            return _bddContext.Cagnottes.ToList();
        }

        public List<Cagnotte> ObtientToutesLesCagnottesActives()
        {
            return _bddContext.Cagnottes.Where(c => c.EcheanceCagnotte > DateTime.Now && c.SommeActuelle < c.SommeObjectif).ToList();
        }

        public List<Cagnotte> ObtientCertainesAnciennesCagnottes(int page)
        {
            return _bddContext.Cagnottes.Where(c => c.EcheanceCagnotte < DateTime.Now).Skip(page * 4).Take(4).ToList();
        }

        public int CombienDeCagnottesApres(int page)
        {
            return _bddContext.Cagnottes.Where(c => c.EcheanceCagnotte < DateTime.Now).Skip(page * 4).Count() - 4;
        }
        
        public int CreerCagnotte(Cagnotte cagnotte)
        {
            Cagnotte Cagnotte = new Cagnotte() { 
                Titre = cagnotte.Titre, 
                Description = cagnotte.Description, 
                SommeObjectif = cagnotte.SommeObjectif,
                EcheanceCagnotte = cagnotte.EcheanceCagnotte};
            _bddContext.Cagnottes.Add(Cagnotte);
            _bddContext.SaveChanges();
            return cagnotte.Id;
        }
        
        public void ModifierCagnotte(Cagnotte cagnotte)
        {
            Cagnotte cagnotteARemplacer= _bddContext.Cagnottes.Find(cagnotte.Id);

            if(cagnotteARemplacer != null)
            {
                cagnotteARemplacer.Titre = cagnotte.Titre;
                cagnotteARemplacer.Description = cagnotte.Description;
                cagnotteARemplacer.SommeObjectif = cagnotte.SommeObjectif;
                cagnotteARemplacer.EcheanceCagnotte = cagnotte.EcheanceCagnotte;
                _bddContext.SaveChanges();
            }
        }

        // QUITTANCE

        public List<Quittance> ObtientTouteslesQuittances()
        {
            return _bddContext.Quittances.ToList();
        }

        public Quittance ObtenirQuittance(int Id)
        {
            return _bddContext.Quittances.Find(Id);
        }

        public int CreerQuittance(Quittance quittance)
        {
            Quittance Quittance = new Quittance()
            {
                DateButoir = quittance.DateButoir,
                DateLocation = quittance.DateLocation,
                Emetteur = quittance.Emetteur,
                Montant = quittance.Montant,
                Statut = Statut.Creee
            };
            _bddContext.Quittances.Add(Quittance);
            _bddContext.SaveChanges();
            return Quittance.Id;
        }

        public void ModifierQuittance(Quittance quittance)
        {
            Quittance Quittance = _bddContext.Quittances.Find(quittance.Id);

            if(Quittance != null)
            {
                Quittance.DateButoir = quittance.DateButoir;
                Quittance.Montant = quittance.Montant;
                Quittance.Emetteur = quittance.Emetteur;
                _bddContext.SaveChanges();
            }
        }

        /*  // AUTHENTIFICATION



          public int AjouterUtilisateur(string nom, string password)
          {
              throw new NotImplementedException();
          }
        */
          private string EncodeMD5(string motDePasse)
          {
              string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
              return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
          }


        /*  public Utilisateur Authentifier(string nom, string password)
          {

          }

          public Utilisateur ObtenirUtilisateur(int id)
          {

          }

          public Utilisateur ObtenirUtilisateur(string idStr)
          {

          }*/



        //FERMETURE DE LA CONNEXION avec MySQL
        public void Dispose()
        {
            _bddContext.Dispose();
        }
              
    }
}

