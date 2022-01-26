using LeGrandRestaurant;
using NUnit.Framework;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    public class ServeurTest
    {
        #region Tests unitaires
        [Test]
        public void GetServeurChiffreDAffaire_ReturnsZero()
        {
            // etant donné un nouveau serveur
            var serveur = new Serveur();

            // quand on récupère son chiffre d'affaire
            var chiffreAffaire = serveur.getChiffreDAffaire();

            // alors celui ci est a 0
            Assert.That(chiffreAffaire, Is.EqualTo(0));
        }

        [Test]
        public void ServeurGetCommande_GetChiffreDAffaireReturnsCommande()
        {
            // etant donné un nouveau serveur
            var serveur = new Serveur();

            // quand il prend une commande 
            var commande = new Commande(20);
            serveur.prendCommande(commande);

            // alors son chiffre d'affaire est le montant de celle-ci
            Assert.That(serveur.getChiffreDAffaire(), Is.EqualTo(commande.getMontant()));
        }

        [Test]
        public void GetChiffreDAffaireReturnsCommande()
        {
            //ÉTANT DONNÉ un serveur ayant déjà pris une commande
            var serveur = new Serveur();
            var commande1 = new Commande(5);
            serveur.prendCommande(commande1);

            //QUAND il prend une nouvelle commande
            var commande2 = new Commande(10);
            serveur.prendCommande(commande2);

            //ALORS son chiffre d'affaires est la somme des deux commandes
            var sommeCommandes = commande1.getMontant() + commande2.getMontant();
            Assert.That(serveur.getChiffreDAffaire(), Is.EqualTo(sommeCommandes));
        }
        #endregion

        #region Tests de recette 
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
        public void UserStoryServeur()
        {
            var serveur1 = new Serveur();
            var serveur2 = new Serveur();
            var table1 = new Table();
            var table2 = new Table();
            var table3 = new Table();
            var restaurant = new Restaurant(table1, table2, table3);

            // commande 1
            restaurant.debuterService();
            table1.installerClient();
            var commande1 = new Commande(12);
            serveur1.prendCommande(commande1);

            // commande 2
            table2.installerClient();
            var commande2 = new Commande(25);
            serveur2.prendCommande(commande2);

            // la table 1 se libère, et de nouveaux clients arrivent
            table1.liberer();
            table1.installerClient();
            var commande3 = new Commande(8.5);
            serveur2.prendCommande(commande3);


            // commande 4
            table3.installerClient();
            var commande4 = new Commande(25);
            serveur1.prendCommande(commande4);

            var montantTotal = commande1.getMontant() + commande4.getMontant();
            Assert.AreEqual(serveur1.getChiffreDAffaire(), montantTotal);
        }

        #endregion
    }
}
