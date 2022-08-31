using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        public int codePostal { get; set;}
        [MaxLength(30)]
        public string typeRue { get; set;}
        public int numeroRue { get; set; }
        [MaxLength(5)]
        public string numeroPorte { get; set; }
    }
}

