using coproBox.Models;
using System.Collections.Generic;

namespace coproBox.ViewModels
{
    public class DashboardModerateurViewModel
    {
        public IEnumerable<Cagnotte> Cagnottes { get; set; }
        public IEnumerable<Annonce> Annonces { get; set; }
    }
}
