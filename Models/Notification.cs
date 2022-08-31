using System;
using System.ComponentModel.DataAnnotations;

namespace coproBox.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string titre { get; set; }
        [MaxLength(200)]
        public string description { get; set; }
    }
}

