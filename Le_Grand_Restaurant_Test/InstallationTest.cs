using Le_Grand_Restaurant;
using NUnit.Framework;
using System;
using System.Linq;

namespace Le_Grand_Restaurant_Test
    
{
    [TestFixture]
    public class InstallationTests
    {
        [Test]
        public void AffectationClient()
        {
            // �TANT DONNE une table dans un restaurant ayant d�but� son service
            var table = new Table();
            var restaurant = new Restaurant(table);
            restaurant.D�buterService();

            // QUAND un client est affect� � une table
            table.InstallerClient();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.False(restaurant.LaTableEstLibre(table));
        }

        [Test]
        public void DesaffectationClient()
        {
            // �TANT DONNE une table occup�e par un client
            var table = new Table();
            var restaurant = new Restaurant(table);

            restaurant.D�buterService();
            table.InstallerClient();

            // QUAND la table est lib�r�e
            table.Lib�rer();

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            Assert.True(restaurant.LaTableEstLibre(table));
        }

        [Test]
        public void AlreadyPresentClient()
        {
            // �TANT DONNE une table occup�e par un client
            var table = new Table();
            table.InstallerClient();

            // QUAND on veut installer un client
            void Act() => table.InstallerClient();

            // ALORS une exception est lanc�e
            Assert.Throws<InvalidOperationException>(Act);
        }

        public void ServiceEnd()
        {
            // �TANT DONNE un restaurant ayant une table occup�e par un client
            var table = new Table();
            table.InstallerClient();

            var restaurant = new Restaurant(table);

            // QUAND le service est termin�
            restaurant.TerminerService();

            // ALORS elle est lib�r�e
            Assert.True(table.EstLibre);
        }

        public void NextFreeTable()
        {
            // �TANT DONN� un restaurant ayant deux tables, dont une occup�e
            var tableOccup�e = new Table();
            tableOccup�e.InstallerClient();

            var tableLibre = new Table();

            var restaurant = new Restaurant(tableLibre, tableOccup�e);

            // QUAND on recherche une table
            var tableChoisie = restaurant
                .RechercherTablesLibres()
                .Single();
            
            // ALORS la table encore libre est renvoy�e
            Assert.AreSame(tableLibre, tableChoisie);
        }

        public void NoFreeTable()
        {
            // �TANT DONN� un restaurant ayant deux tables, toutes occup�es
            var tableOccup�es = new Table[] { new Table(), new Table() };
            foreach (var tableOccup�e in tableOccup�es)
                tableOccup�e.InstallerClient();

            var restaurant = new Restaurant(tableOccup�es);

            // QUAND on recherche une table libre
            var tablesLibres = restaurant.RechercherTablesLibres();

            // ALORS une collection vide est renvoy�e
            Assert.IsEmpty(tablesLibres);
        }
    }
}