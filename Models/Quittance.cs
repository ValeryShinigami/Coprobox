using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Quittance
    {
        public int Id { get; set; }
        public string Emetteur { get; set; }
        public int? LocataireId { get; set; }
        public Utilisateur Locataire { get; set; }
        [Required]
        public double Montant { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateLocation { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEmission { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateButoir { get; set; }
        public byte[] Fichier { get; set; }
        public StatutQuittance StatutQuittance { get; set; }
    }

    public enum StatutQuittance
    {
        Creee,
        Envoyee,
        Payee,
        EnLigne
    }
}
