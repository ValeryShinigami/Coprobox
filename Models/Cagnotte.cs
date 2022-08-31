using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Cagnotte
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Titre { get; set; }

        [MaxLength(200)]
        [Required]
        public string Description { get; set; }

        [Required]
        public double SommeObjectif { get; set; }
        public double SommeActuelle { get; set; }
        public DateTime EcheanceCagnotte { get; set; }

    }
}
