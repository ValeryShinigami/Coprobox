using System;
using System.Collections.Generic;
using System.Linq;

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
            return _bddContext.Utilisateurs.ToList();

            //return _bddContext.Utilisateurs.Include(u=> u.Compte).Include.(u=>u.Adresse).ToList();
            // .Include permet de créer une jointure... et d'afficher ou modifier des clés étrangères.
        }

        public int CreerUtilisateur(string Nom, string Prenom, DateTime dateNaissance)
        {
            InfosPersonnelle infosPersonnelle = new InfosPersonnelle { Nom = Nom, Prenom = Prenom, dateNaissance = dateNaissance };
            //_bddContext.InfosPersonnelles.Add(infosPersonnelle);

            Utilisateur utilisateur = new Utilisateur() { InfosPersonnelle = infosPersonnelle}; // j'instancie Compte et je lui transmet ce que l'utilisateur écrira. J'instancie mais je dois égalemen le rajouter dans la BDD de la liste de séjour via bddContext
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }


        public void ModifierUtilisateur(int id, string lieu, string telephone)
        {
            Utilisateur utilisateur = _bddContext.Utilisateurs.Find(id);

            if (utilisateur != null)
            {
                utilisateur.Id = id;
               _bddContext.SaveChanges();
            }
        }

     

        // COMPTES
        public void ModifierCompte(int Id, string numeroIdentifiant, string role, string motDePasse, string codeIban)
        {
            Compte compte = _bddContext.Comptes.Find(Id);
            if (compte != null)
            {
                compte.numeroIdentifiant = numeroIdentifiant;
                compte.role = role;
                compte.motDePasse = motDePasse;
                compte.codeIban = codeIban;
                _bddContext.SaveChanges();
            }
        }

        public List<Compte> ObtientTousLesComptes()
        {
            return _bddContext.Comptes.ToList();
        }

        
        public void ModifierAdresse(int Id, string numeroPorte, int numeroRue, string typeRue, int codePostal)
        {
            Adresse adresse = _bddContext.Adresses.Find(Id);
            if (adresse != null)
            {
                adresse.numeroPorte = numeroPorte;
                adresse.numeroRue = numeroRue;
                adresse.typeRue = typeRue;
                adresse.codePostal = codePostal;
            }
        }

        public List<Adresse> ObtientToutesLesAdresses()
        {
            return _bddContext.Adresses.ToList();
        }
        // ANNONCE DEBUT
        public void CreerAnnonce(string titre, string description, string tauxHoraire, int tarif, DateTime dateDebut, DateTime dateFin, TypeService typeService, int id = 0)
        {
            Annonce annonceToAdd = new Annonce { Titre = titre, Description = description, TauxHoraire = tauxHoraire, Tarif = tarif, DateDebut = dateDebut, DateFin = dateFin, TypeService = typeService };
            if (id != 0)
            {
                annonceToAdd.Id = id;
            }
            this._bddContext.Annonces.Add(annonceToAdd);
            this._bddContext.SaveChanges();
        }

        public List<Annonce> ObtientToutesLesAnnonces()
        {
            List<Annonce> listeAnnonces = this._bddContext.Annonces.ToList();
            return listeAnnonces;
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
            }
        }

        // QUITTANCE

        public List<Quittance> ObtientTouteslesQuittances()
        {
            return _bddContext.Quittances.ToList();
        }

        public int CreerQuittance(Quittance quittance)
        {
            Quittance Quittance = new Quittance()
            {
                DateButoir = quittance.DateButoir,
                DateEmission = quittance.DateEmission,
                Emetteur = quittance.Emetteur,
                Montant = quittance.Montant
            };
            _bddContext.Quittances.Add(Quittance);
            _bddContext.SaveChanges();
            return Quittance.Id;
        }

        //FERMETURE DE LA CONNEXION avec MySQL
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}

