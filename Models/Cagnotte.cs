using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Cagnotte
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Le titre de la cagnotte doit être rempli !")]
        public string Titre { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "La description de la cagnotte doit être remplie !")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La somme à atteindre doit être renseignée !")]
        [Display(Name = "Somme objectif")]
        public double SommeObjectif { get; set; }

        public double SommeActuelle { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Il faut une date de fin pour la cagnotte !")]
        [Display(Name = "Echeance cagnotte")]
        public DateTime EcheanceCagnotte { get; set; }

    }
}
