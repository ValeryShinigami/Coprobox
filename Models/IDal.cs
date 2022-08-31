using System;
using System.Collections.Generic;

namespace coproBox.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase(); // méthode qui ne retourne rien et ne prend rien en paramètre

        List<Utilisateur> ObtientTousLesUtilisateurs();

        //retournera 2 paramètres dans IDal : la liste et les séjours...

        public int CreerUtilisateur(string Nom, string Prenom, DateTime dateNaissance);

        List<Annonce> ObtientToutesLesAnnonces();

        List<Compte> ObtientTousLesComptes();

        public void ModifierCompte(int Id, string numeroIdentifiant, string role, string motDePasse, string codeIban);

        public void ModifierAdresse(int Id, string numeroPorte, int numeroRue, string typeRue, int codePostal); // il faudrait rajouter la ville non ? histoire de ne pas refaire cette modif pour le projet 3...

        List<Adresse> ObtientToutesLesAdresses();

    }

}

