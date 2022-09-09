using coproBox.Models;
using System.Collections.Generic;

namespace coproBox.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Utilisateur> Utilisateurs { get; set; }
        public IEnumerable<Cagnotte> Cagnottes { get; set; }
        public IEnumerable<Annonce> AnnoncesAVerifier { get; set; }
        public IEnumerable<Annonce> AnnoncesPerso { get; set; }
        public IEnumerable<Paiement> Paiements { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<ParticipationCagnotte> ParticipationCagnottes { get; set; }
    }
}
