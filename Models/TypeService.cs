using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace coproBox.Models
{
    public enum TypeService // avec "enum", chaque élément sera associé à un entier...
    {
        [Display(Name = "Baby Sitting")]
        BabySitting,
        [Display(Name = "Cagnotte Solidaire")]
        Cagnotte_Solidaire,
        [Display(Name = "Courses")]
        Courses,
        [Display(Name = "Don D'objet")]
        Don_Objet,
        [Display(Name = "Evènement")]
        Evènement,
        [Display(Name = "Garde Animaux")]
        Garde_Animaux,
        [Display(Name = "Ménage")]
        Ménage,
        [Display(Name = "Parking")]
        Parking,
        [Display(Name = "Prêt Matériel")]
        Prêt_Matériel,
        [Display(Name = "Soutien Scolaire")]
        Soutien_Scolaire 
    }
}

