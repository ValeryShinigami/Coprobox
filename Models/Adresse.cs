using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        [Display (Name ="Code Postal")]
        public int CodePostal { get; set; }
        [MaxLength(10)]
        [Display(Name = "n° de porte")]
        public string NumeroPorte {get; set;}
        [MaxLength(50)]
        [Display(Name = "Adresse principale")]
        public string AdressePrincipale { get; set;}
        public string Ville { get; set; }
    }
}

