using System.Collections.Generic;

namespace coproBox.Models
{
    public class ParticipationCagnotte
    {
        public int Id { get; set; }
        public int? CagnotteId { get; set; }
        public Cagnotte Cagnotte { get; set; }
        public int? UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int Montant { get; set; }
    }
}
