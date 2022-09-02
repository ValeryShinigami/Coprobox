using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class InfosPersonnelle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom doit être précisé.")]
        [MaxLength(30)]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le nom doit être précisé.")]
        [MaxLength(30)]
        public string Prenom { get; set; }
        public DateTime dateNaissance { get; set; }
    }
}

