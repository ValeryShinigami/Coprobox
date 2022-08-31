using System;
using Microsoft.EntityFrameworkCore;

namespace coproBox.Models
{
    public class BddContext : DbContext
    {
        //partie UTILISATEUR
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<InfosContact> InfosContacts { get; set; }
        public DbSet<InfosPersonnelle> InfosPersonnelles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<Cagnotte> Cagnottes { get; set; }


        // partie ANNONCE
        public DbSet<Annonce> Annonces { get; set; }
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=RRRRR;database=coproBox");  // connexion string. Attention au password. avec comme nom de BDD : ChoixSejourTest
        }
    public void InitializeDb()

        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            this.Comptes.AddRange(
                new Compte
                {
                    Id = 1,
                    numeroIdentifiant = "1",
                    role = "modérateur",
                    email = "fouzi_coprobox@gmail.com",
                    motDePasse="FFFFF",
                    nombreAnnonce=0,
                    codeIban="FR76000 0000 000 0000",
                    montant=0
                },
            
                new Compte
                {
                Id = 2,
                numeroIdentifiant = "2",
                role = "modérateur",
                email = "valery_coprobox@gmail.com",
                motDePasse = "VVVVV",
                nombreAnnonce = 0,
                codeIban = "FR76000 0000 000 0000",
                montant = 0
                }
            );


           this.Adresses.AddRange(
                 new Adresse
                 {
                   Id = 1,
                   codePostal = 92240,
                   typeRue = "avenue du général Leclerc",
                   numeroRue = 2,
                   numeroPorte = "A102"
                 },

                 new Adresse
                 {
                   Id = 2,
                   codePostal = 92240,
                   typeRue = "avenue du général Leclerc",
                   numeroRue = 2,
                   numeroPorte = "B208"
                 }
             );

            this.Utilisateurs.AddRange(
                new Utilisateur
                {
                    Id = 1,
                    CompteId = 1,
                    AdresseId = 1
                },

                new Utilisateur
                {
                    Id = 2,
                    CompteId = 2,
                    AdresseId = 2
                }
            );

            this.Cagnottes.AddRange(
                new Cagnotte
                {
                    Titre = "Cagnotte 1",
                    Description = "Première cagnotte!",
                    SommeObjectif = 1000
                },

                new Cagnotte
                {
                    Titre = "Cagnotte 2",
                    Description = "Seconde cagnotte!",
                    SommeObjectif = 350
                },

                new Cagnotte
                {
                    Titre = "Cagnotte 3",
                    Description = "Dernière cagnotte!",
                    SommeObjectif = 100
                }
                );
            this.SaveChanges();
        }
    }

}

