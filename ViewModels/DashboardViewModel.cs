using coproBox.Models;
using System.Collections.Generic;

namespace coproBox.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Utilisateur> Utilisateurs { get; set; }
        public IEnumerable<Cagnotte> Cagnottes { get; set; }
        public IEnumerable<Annonce> Annonces { get; set; }
        public IEnumerable<Paiement> Paiements { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
