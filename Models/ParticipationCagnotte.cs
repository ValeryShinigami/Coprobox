using System.Collections.Generic;

namespace coproBox.Models
{
    public class ParticipationCagnotte
    {
        public int Id { get; set; }
        public int? CagnotteId { get; set; }
        public Cagnotte Cagnotte { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
    }
}
