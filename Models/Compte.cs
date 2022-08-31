using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Compte
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string numeroIdentifiant { get; set; }

        [MaxLength(20)]
        public string role { get; set; }

        [Required(ErrorMessage = "L'adresse mail doit être précisée.")]
        [MaxLength(50)]
        public string email { get; set; }

        [MaxLength(50)]
        [Required (ErrorMessage ="Le mot de passe doit être rempli.")]
        public string motDePasse { get; set; }

        public int nombreAnnonce { get; set; }

        [MinLength(14),MaxLength(34)]
        public string codeIban { get; set; }

        public double montant { get; set; }
    }
}

