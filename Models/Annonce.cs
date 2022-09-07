using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coproBox.Models
{
    public class Annonce
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Le titre doit être rempli !")]
        public string Titre { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "La description doit être rempli !")]
        public string Description { get; set; }   
        public string TauxHoraire { get; set; }

        [Required(ErrorMessage = "Merci d'indiquer un prix valide")]
        public int Tarif { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }

        public TypeService TypeService { get; set; }
        
        public string ImagePath { get; set; }
        [NotMapped]

        public IFormFile Image { get; set; }

        public int? UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

        public int? InfosPersonnelleId { get; set; }
        public virtual InfosPersonnelle InfosPersonnelle { get; set; }

        public int? CompteId { get; set; }
        public virtual Compte  Compte { get; set; }

        public StatutAnnonce StatutAnnonce { get; set; }
       
    }
    public enum StatutAnnonce
    {
        Creee,
        Validée,
        Non_Validée,
        Supprimée,
        Payee,
        EnLigne
    }
}

