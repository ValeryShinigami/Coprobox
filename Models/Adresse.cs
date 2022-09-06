using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        public int CodePostal { get; set; }
        [MaxLength(10)]
        public string NumeroPorte {get; set;}
        [MaxLength(50)]
        public string AdressePrincipale { get; set;}
        public string Ville { get; set; }
    }
}

