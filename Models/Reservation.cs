namespace coproBox.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Annonce Annonce { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
