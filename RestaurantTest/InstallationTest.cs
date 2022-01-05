
using LeGrandRestaurant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LeGrandRestaurantTest
{
    [TestClass]
    class TestInstallation
    {
        [TestMethod]
        public void AffectationClient()
        {
            // ÉTANT DONNE une table dans un restaurant ayant débuté son service
            var table = new Table();
            var restaurant = new Restaurant(table);
            restaurant.debuterService();

            // QUAND un client est affecté à une table
            table.installerClient();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.IsFalse(table.estLibre);
        }

        [TestMethod]
        public void DesaffectationClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            var restaurant = new Restaurant(table);

            restaurant.debuterService();
            table.installerClient();

            // QUAND la table est libérée
            table.liberer();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.IsTrue(table.estLibre);
        }

        [TestMethod]
        public void AlreadyPresentClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            table.installerClient();

            // QUAND on veut installer un client
            void Act() => table.installerClient();

            // ALORS une exception est lancée
            Assert.ThrowsException<InvalidOperationException>(Act);
        }

        [TestMethod]
        public void NextFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, dont une occupée
            var tableOccupée = new Table();
            tableOccupée.installerClient();

            var tableLibre = new Table();

            var restaurant = new Restaurant(tableLibre, tableOccupée);

            // QUAND on recherche une table
            var tableChoisie = restaurant
                .rechercherTablesLibres()
                .Single();

            // ALORS la table encore libre est renvoyée
            Assert.AreEqual(tableLibre, tableChoisie);
        }

        [TestMethod]
        public void ServiceEnd()
        {
            // ÉTANT DONNE un restaurant ayant une table occupée par un client
            var table = new Table();
            table.installerClient();

            var restaurant = new Restaurant(table);

            // QUAND le service est terminé
            restaurant.TerminerService();

            // ALORS elle est libérée
            Assert.IsTrue(table.estLibre);
        }

        [TestMethod]
        public void NoFreeTable()
        {
            // ÉTANT DONNÉ un restaurant ayant deux tables, toutes occupées
            var tableOccupées = new Table[] { new Table(), new Table() };
            foreach (var tableOccupée in tableOccupées)
                tableOccupée.installerClient();

            var restaurant = new Restaurant(tableOccupées);

            // QUAND on recherche une table libre
            var tablesLibres = restaurant.rechercherTablesLibres();

            // ALORS une collection vide est renvoyée
            Assert.IsNull(tablesLibres);
        }
    }
}
