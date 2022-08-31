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

        // Gestion Cagnotte Solidaire

        public List<Cagnotte> ObtientToutesLesCagnottes();
        public int CreerCagnotte(String titre, String description, Double sommeObjectif);
        public void ModifierCagnotte(Cagnotte cagnotte);
    }

}

