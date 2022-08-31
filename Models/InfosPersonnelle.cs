using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class InfosPersonnelle
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Nom { get; set; }
        [MaxLength(30)]
        public string Prenom { get; set; }
        public DateTime dateNaissance { get; set; }
    }
}

