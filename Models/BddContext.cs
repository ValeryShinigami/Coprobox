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
        public DbSet<Quittance> Quittances { get; set; }


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
            this.InfosPersonnelles.AddRange(
                new InfosPersonnelle
                {
                    Id = 1,
                    Nom = "BENMAKHLOUF",
                    Prenom = "Fouzy"
                },
                new InfosPersonnelle
                {
                    Id = 2,
                    Nom = "KALOMBO",
                    Prenom = "Valery"
                }
            );

           this.Adresses.AddRange(
                 new Adresse
                 {
                     Id = 1,
                     NumeroPorte = "A105",
                     AdressePrincipale = "2 avenue du général Leclerc",
                     CodePostal = 92240,
                     Ville = "MALAKOFF"
                 },

                 new Adresse
                 {
                     Id = 2,
                     NumeroPorte = "A105",
                     AdressePrincipale = "2 avenue du général Leclerc",
                     CodePostal = 92240,
                     Ville = "MALAKOFF"
                 }
             );

            this.Utilisateurs.AddRange(
                new Utilisateur
                {
                    Id = 1,
                    CompteId = 1,
                    AdresseId = 1,
                    InfosPersonnelleId = 1,
                   
                },

                new Utilisateur
                {
                    Id = 2,
                    CompteId = 2,
                    AdresseId = 2,
                    InfosPersonnelleId = 2
                }
            );
            this.Annonces.AddRange(
               new Annonce
               {
                   Id = 1,
                   Titre = "Vélo de courses",
                   TypeService = TypeService.Prêt_Matériel,
                   Description = "Prêt de ce magnifique vélo pour vous enmener partout autour de la résidence",
                   TauxHoraire = "0",
                   Tarif = 20,
                   DateDebut = DateTime.Now,
                   DateFin = DateTime.Now,
                   ImagePath = "/Image/velo.jpeg",
                   UtilisateurId = 1,
                   InfosPersonnelleId = 1,
                   CompteId = 2
               },

               new Annonce
               {
                   Id = 2,
                   Titre = "Fête entre voisin",
                   TypeService = TypeService.Evènement,
                   Description = "Super soirée entre voisin pour danser manger et rigoler ensemble venez comme vous êtes!!",
                   TauxHoraire = "0",
                   Tarif = 150,
                   DateDebut = DateTime.Now,
                   DateFin = DateTime.Now,
                   ImagePath = "/Image/party.jpg",
                   UtilisateurId = 1,
                   InfosPersonnelleId = 1,
                   CompteId = 1
               },
               new Annonce
               {
                   Id = 3,
                   Titre = "Outillage",
                   TypeService = TypeService.Prêt_Matériel,
                   Description = "Prêt d'outillage pour petit ou grand travaux n'hésitez pas à me contacter pour plus d'informations",
                   TauxHoraire = "0",
                   Tarif = 30,
                   DateDebut= DateTime.Now,
                   DateFin = DateTime.Now,
                   ImagePath = "/Image/outillage.jpg",
                   UtilisateurId = 1,
                   InfosPersonnelleId = 1,
                   CompteId = 1
               },
               new Annonce
               {
                   Id = 4,
                   Titre = "Garde de chien",
                   TypeService = TypeService.Garde_Animaux,
                   Description = "Je recherche une personne pour garder mon chien il est très propre et sage",
                   TauxHoraire = "0",
                   Tarif = 550,
                   DateDebut = DateTime.Now,
                   DateFin = DateTime.Now,
                   ImagePath = "/Image/chien.jpg",
                   UtilisateurId = 1,
                   InfosPersonnelleId = 1,
                   CompteId = 1
               },
               new Annonce
               {
                   Id = 5,
                   Titre = "Garde d'enfant",
                   TypeService = TypeService.BabySitting,
                   Description = "Je recherche une personne pour garder mon enfant il est très gentil et sourriant",
                   TauxHoraire = "10",
                   Tarif = 0,
                   DateDebut = DateTime.Now,
                   DateFin = DateTime.Now,
                   ImagePath = "/Image/enfant.png",
                   UtilisateurId = 1,
                   InfosPersonnelleId = 1,
                   CompteId = 1
               },

               new Annonce
               {
                   Id = 6,
                   Titre = "Rangement appartement",
                   TypeService = TypeService.Ménage,
                   Description = "Je recherche une personne pour nettoyer mon appartement suite à une fête",
                   TauxHoraire = "0",
                   Tarif = 50,
                   DateDebut = DateTime.Now,
                   DateFin = DateTime.Now,
                   ImagePath = "/Image/maison.jpg",
                   UtilisateurId = 1,
                   InfosPersonnelleId = 1,
                   CompteId = 1

               }
           ); 
            this.Cagnottes.AddRange(
                new Cagnotte
                {
                    Titre = "Cagnotte 1",
                    Description = "Première cagnotte!",
                    SommeObjectif = 1000, 
                    SommeActuelle = 500
                },

                new Cagnotte
                {
                    Titre = "Cagnotte 2",
                    Description = "Seconde cagnotte!",
                    SommeObjectif = 350,
                    SommeActuelle = 100
                },

                new Cagnotte
                {
                    Titre = "Cagnotte 3",
                    Description = "Dernière cagnotte!",
                    SommeObjectif = 100,
                    SommeActuelle = 100
                }
                );
            this.Quittances.Add(
                new Quittance
                {
                    DateEmission = DateTime.Now,
                    DateButoir = DateTime.Now,
                    DateLocation = DateTime.Now,
                    Emetteur = "Proprio",
                    LocataireId = 1,
                    Montant = 999,
                    StatutQuittance = StatutQuittance.Payee
                }
                );
            this.SaveChanges();
        }
    }

}

