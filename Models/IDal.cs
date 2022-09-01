using System;
using System.Collections.Generic;

namespace coproBox.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase(); // méthode qui ne retourne rien et ne prend rien en paramètre

        // Gestion Utilisateurs

        List<Utilisateur> ObtientTousLesUtilisateurs();

        public int CreerUtilisateur(string Nom, string Prenom, DateTime dateNaissance);

        List<Compte> ObtientTousLesComptes();

        public void ModifierCompte(int Id, string numeroIdentifiant, string role, string motDePasse, string codeIban);

        public void ModifierAdresse(int Id, string numeroPorte, int numeroRue, string typeRue, int codePostal); // il faudrait rajouter la ville non ? histoire de ne pas refaire cette modif pour le projet 3...

        List<Adresse> ObtientToutesLesAdresses();

        // Gestion Annonces

        List<Annonce> ObtientToutesLesAnnonces();
        public void CreerAnnonce(string titre, string description, string tauxHoraire, int tarif, DateTime dateDebut, DateTime dateFin, TypeService typeService, int id = 0);
        public void SupprimerAnnonce(int id);

        // Gestion Cagnotte Solidaire
        public List<Cagnotte> ObtientToutesLesCagnottes();
        public List<Cagnotte> ObtientCertainesAnciennesCagnottes(int page);
        public int CombienDeCagnottesApres(int page);
        public int CreerCagnotte(Cagnotte cagnotte);
        public void ModifierCagnotte(Cagnotte cagnotte);

        // Gestion Quittances
        public List<Quittance> ObtientTouteslesQuittances();
        public int CreerQuittance(Quittance quittance);


       /* //Anthentification
        int AjouterUtilisateur(string nom, string password);
        Utilisateur Authentifier(string nom, string password);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string idStr); */
    }

}

