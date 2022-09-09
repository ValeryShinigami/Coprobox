using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace coproBox.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase(); // méthode qui ne retourne rien et ne prend rien en paramètre

        // Gestion Utilisateurs

        List<Utilisateur> ObtientTousLesUtilisateurs();
        public int CreerUtilisateur(string Prenom, string Nom, string email, string motDePasse, Role role, bool estProprietaire);
        public void ModifierUtilisateur(Utilisateur utilisateur);
        Utilisateur Authentifier(string email, string motdepasse);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string idStr);
        public void SupprimerUtilisateur(int id);
        
        // Gestion Annonces

        List<Annonce> ObtientToutesLesAnnonces();
        public void CreerAnnonce(string titre, string description, string tauxHoraire, int tarif, DateTime dateDebut, DateTime dateFin, TypeService typeService, string imagePath, int id = 0);

        void ModifierAnnonce(int id, string titre, string description, string tauxHoraire, int tarif, DateTime dateDebut, DateTime dateFin, TypeService typeService, string imagePath);
        public void SupprimerAnnonce(int id);

        // Gestion Cagnotte Solidaire
        public List<Cagnotte> ObtientToutesLesCagnottes();
        public List<Cagnotte> ObtientToutesLesCagnottesActives();
        public List<Cagnotte> ObtientCertainesAnciennesCagnottes(int page);
        public int CombienDeCagnottesApres(int page);
        public int CreerCagnotte(Cagnotte cagnotte);
        public void ModifierCagnotte(Cagnotte cagnotte);

        // Gestion Quittances
        public List<Quittance> ObtientTouteslesQuittances();
        public Quittance ObtenirQuittance(int Id);
        public int CreerQuittance(Quittance quittance);
        public void ModifierQuittance(Quittance Quittance);

        // Dashboard
        public List<Paiement> ObtientTousSesPaiements(int UserId);
        public List<Reservation> ObtientToutesSesReservations(int UserId);
        public List<ParticipationCagnotte> ObtientToutesSesParticipationCagnottes(int UserId);
        public List<Annonce> ObtientToutesSesAnnonces(int UserId);
        public List<Annonce> ObtientLesAnnoncesAVerifier();
        /* //Anthentification
         int AjouterUtilisateur(string nom, string password);
         Utilisateur Authentifier(string nom, string password);
         Utilisateur ObtenirUtilisateur(int id);
         Utilisateur ObtenirUtilisateur(string idStr); */
            

        // Paiement
       
       
    }

}

