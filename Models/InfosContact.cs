using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class InfosContact
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string telephone { get; set; }
    }
}

