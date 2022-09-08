using System.ComponentModel;

namespace coproBox.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public int AnnonceId { get; set; }
        public Annonce Annonce { get; set; }
        public int? UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public bool EstLoyer { get; set; }
        [DisplayName("Payé")]
        public bool Paye { get; set; }
    }

}
