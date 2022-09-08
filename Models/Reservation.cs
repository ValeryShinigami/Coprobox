using System.Collections.Generic;

namespace coproBox.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Annonce Annonce { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
    }
}
