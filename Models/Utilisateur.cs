using System;
namespace coproBox.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        public int? AdresseId { get; set; } // permet à la clé étrangère d'être nulle avec "?" dans le cas contraire, il faudrait que ce soit relié à TOUT...
        public virtual Adresse Adresse { get; set; }

        public int? CompteId { get; set; }
        public virtual Compte Compte { get; set; }

        public int? InfosContactId { get; set; }
        public virtual InfosContact InfosContact { get; set; }

        public int? InfosPersonnelleId { get; set; }
        public virtual InfosPersonnelle InfosPersonnelle { get; set; }

        public int? NotificationId { get; set; }
        public virtual Notification Notification { get; set; }

        public int? ProfilId { get; set; }
        public virtual Profil Profil { get; set; }


        //doubler les fk
    }
}

