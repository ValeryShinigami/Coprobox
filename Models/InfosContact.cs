using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class InfosContact
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string telephone { get; set; }
    }
}

