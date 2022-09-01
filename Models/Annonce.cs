using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Annonce
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Titre { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public string TauxHoraire { get; set; }
        public int Tarif { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public TypeService TypeService { get; set;}

        //public IFormFile Image { get; set; }

    }
}

