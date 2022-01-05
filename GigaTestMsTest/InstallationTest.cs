using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Le_Grand_Restaurant;

namespace GigaTestMsTest
{
    [TestClass]
    public class InstallationTests
    {
        
        public void AffectationClient()
        {
            // ÉTANT DONNE une table dans un restaurant ayant débuté son service
            var table = new Table();
            var restaurant = new Restaurant(table);
            restaurant.DébuterService();

            // QUAND un client est affecté à une table
            table.InstallerClient();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.IsFalse(restaurant.LaTableEstLibre(table));
        }

        
        public void DesaffectationClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            var restaurant = new Restaurant(table);

            restaurant.DébuterService();
            table.InstallerClient();

            // QUAND la table est libérée
            table.Libérer();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.IsTrue(restaurant.LaTableEstLibre(table));
        }

        
        public void AlreadyPresentClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            table.InstallerClient();

            // QUAND on veut installer un client
            void Act() => table.InstallerClient();

            // ALORS une exception est lancée
            Assert.ThrowsException<InvalidOperationException>(Act);
        }

        public void ServiceEnd()
        {
            // ÉTANT DONNE un restaurant ayant une table occupée par un client
            var table = new Table();
            table.InstallerClient();

            var restaurant = new Restaurant(table);

            // QUAND le service est terminé
            restaurant.TerminerService();

            // ALORS elle est libérée
            Assert.IsTrue(table.EstLibre);
        }

        public void NextFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, dont une occupée
            var tableOccupée = new Table();
            tableOccupée.InstallerClient();

            var tableLibre = new Table();

            var restaurant = new Restaurant(tableLibre, tableOccupée);

            // QUAND on recherche une table
            var tableChoisie = restaurant
                .RechercherTablesLibres()
                .Single();

            // ALORS la table encore libre est renvoyée
            Assert.AreSame(tableLibre, tableChoisie);
        }

        public void NoFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, toutes occupées
            var tableOccupées = new Table[] { new Table(), new Table() };
            foreach (var tableOccupée in tableOccupées)
                tableOccupée.InstallerClient();

            var restaurant = new Restaurant(tableOccupées);

            // QUAND on recherche une table libre
            var tablesLibres = restaurant.RechercherTablesLibres();

            // ALORS une collection vide est renvoyée
            Assert.IsEmpty(tablesLibres);
        }
    }
}
