using coproBox.Models;

namespace coproBox.ViewModels
{
    public class PaiementViewModel
    {
        public Annonce Annonce { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public Paiement Paiement { get; set; }
    }
}
