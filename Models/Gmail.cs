using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Gmail
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string De { get; set; }
        public string Sujet { get; set; }
        public string Body { get; set; }
        [Required(ErrorMessage = "L'adresse mail doit être précisée.")]
        [MaxLength(50)]
        [Display(Name = "Adresse email")]
        public string email { get; set; }
    }
}

