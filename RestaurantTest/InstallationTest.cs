using NUnit.Framework;
using LeGrandRestaurant;
using System;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    class InstallationTest
    {
        [Test]
        public void AffectationClient()
        {
            // ÉTANT DONNE une table dans un restaurant ayant débuté son service
            var table = new Table();
            var restaurant = new Restaurant(0);
            restaurant.debuterService();

            // QUAND un client est affecté à une table
            table.installerClient();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.True(restaurant.estDisponible(table));
        }

        [Test]
        public void desaffectationClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            var restaurant = new Restaurant(0, table);

            restaurant.debuterService();
            table.installerClient();

            // QUAND la table est libérée
            table.liberer();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.True(restaurant.estDisponible(table));
        }

        [Test]
        public void AlreadyPresentClient()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            table.installerClient();

            // QUAND on veut installer un client
            void Act() => table.installerClient();

            // ALORS une exception est lancée
            Assert.Throws<InvalidOperationException>(Act);
        }
    }
}
