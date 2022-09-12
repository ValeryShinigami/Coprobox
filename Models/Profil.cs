using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Profil
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string username { get; set; }
        [MaxLength(200)]
        public string description { get; set; }
        public string ImageProfil { get; set; }
    }
}

