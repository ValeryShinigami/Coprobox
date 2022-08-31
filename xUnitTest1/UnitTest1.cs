using System;
using System.Collections.Generic;
using coproBox.Models;
using Xunit;

namespace xUnitTest1
{
    public class UnitTest1
    {
        [Fact]
        public void Creation_Utilisateurs_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                dal.CreerUtilisateur("SILVER", "Jason",new DateTime(2008, 5, 1, 8, 30, 52));

                // Nous vérifions que le lieu a bien été créé
                List<Utilisateur> utilisateurs = dal.ObtientTousLesUtilisateurs();
                Assert.NotNull(utilisateurs);
                Assert.Single(utilisateurs);
                Assert.Equal("SILVER", utilisateurs[0].InfosPersonnelle.Nom );
                Assert.Equal("Jason", utilisateurs[0].InfosPersonnelle.Prenom);
                Assert.Equal(new DateTime(2008, 5, 1, 8, 30, 52), utilisateurs[0].InfosPersonnelle.dateNaissance);
            }
        }
    }
}
