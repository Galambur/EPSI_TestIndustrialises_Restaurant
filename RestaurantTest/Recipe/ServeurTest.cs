using LeGrandRestaurant;
using NUnit.Framework;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    public partial class ServeurTest
    {
        /*
            On a 2 serveur dans un restaurant avec 3 tables
            Le service commence
            Un client arrive dans le restaurant, il va sur la table 1
            Le serveur 1 prend la commande de la table 1
            La table 2 se rempli
            Le serveur 2 prend la commande de la deuxième table
            La table 1 se libère, puis se re remplie
            Le serveur 2 prend la commande de la table 1
            La table 3 se remplie 
            Le serveur 1 prend la commande de la table 3
            Le chiffre d’affaires du serveur 1 est égal à l’addition des montants des commandes de la table 1 et 3 (commande 1 et 4)
        */
        [Test]
        public void SimulationService()
        {
            var serveur1 = new ServeurBuilder().Build();
            var serveur2 = new ServeurBuilder().Build();
            var table1 = new Table();
            var table2 = new Table();
            var table3 = new Table();
            var restaurant = new Restaurant(table1, table2, table3);

            // commande 1
            restaurant.debuterService();
            table1.installerClient();
            var commande1 = new Commande(12);
            serveur1.PrendCommande(commande1);

            // commande 2
            table2.installerClient();
            var commande2 = new Commande(25);
            serveur2.PrendCommande(commande2);

            // la table 1 se libère, et de nouveaux clients arrivent
            table1.liberer();
            table1.installerClient();
            var commande3 = new Commande(8.5);
            serveur2.PrendCommande(commande3);


            // commande 4
            table3.installerClient();
            var commande4 = new Commande(25);
            serveur1.PrendCommande(commande4);

            var montantTotal = commande1.getMontant() + commande4.getMontant();
            Assert.AreEqual(serveur1.getChiffreDAffaire(), montantTotal);
        }

    }
}
