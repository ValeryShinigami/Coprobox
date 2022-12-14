using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Compte
    {
        public int Id { get; set; }

        [MaxLength(40)]
        [Display(Name = "numéro identifiant")]
        public string numeroIdentifiant { get; set; }
         
        [Required(ErrorMessage = "L'adresse mail doit être précisée.")]
        [MaxLength(50)]
        [Display(Name ="email")]
        public string email { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "mot de passe")]
        //[Required (ErrorMessage ="Le mot de passe doit être rempli.")]
        public string motDePasse { get; set; }

        [Display(Name = "nombre d'annonce ")]
        public int nombreAnnonce { get; set; }

        [MinLength(14),MaxLength(34)]
        [Display(Name = "code IBAN")]
        public string codeIban { get; set; }

        public double montant { get; set; }

        public bool estProprietaire { get; set; }

        public Role Role { get; set; }
    }
    public enum Role // avec "enum", chaque élément sera associé à un entier...
    {
        Utilisateur,
        Administrateur,
        [Display(Name = "Modérateur")]
        Moderateur
    }
}

