﻿using System;
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

        public List<Annonce> ObtientToutesLesAnnonces()
        {
            return _bddContext.Annonces.ToList();
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

        //ANNONCES :
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

        // CAGNOTTE

        public List<Cagnotte> ObtientToutesLesCagnottes()
        {
            return _bddContext.Cagnottes.ToList();
        }
        
        public int CreerCagnotte(String titre, String description, Double sommeObjectif)
        {
            Cagnotte cagnotte = new Cagnotte() { Titre = titre, Description = description, SommeObjectif = sommeObjectif };
            _bddContext.Cagnottes.Add(cagnotte);
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

        //FERMETURE DE LA CONNEXION avec MySQL
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}

