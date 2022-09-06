using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Quittance
    {
        public int Id { get; set; }
        public string Emetteur { get; set; }
        [Required]
        public double Montant { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEmission { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateButoir { get; set; }
        public byte[] Fichier { get; set; }
        public Statut Statut { get; set; }
    }

    public enum Statut
    {
        Creee,
        Envoyee,
        Payee,
        EnLigne
    }
}
