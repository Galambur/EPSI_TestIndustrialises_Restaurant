using LeGrandRestaurant;
using NUnit.Framework;
using System.Collections.Generic;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    class CommandeTest
    {
        #region Tests de système 

        [Test]
        public void CommandePlat()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            var serveur = new Serveur();
            var restaurant = new Restaurant();
            var plat = new Plat();
            var listePlat = new List<Plat>();
            var commande = new Commande(45);

            // QUAND il prend une commande 
            serveur.prendCommande(commande);

            // ALORS cette commande apparaît dans la liste de plat
            var listePlat = plat.ListePlat();
            Assert.Contains(commande, listePlat);
        }

        public void CommandeBoissons()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            var serveur = new Serveur();
            var restaurant = new Restaurant();
            var commandeboissons = new Commande(15);


            // QUAND il prend une commande de boissons
            serveur.prendCommande(commandeboissons);

            // ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant
            restaurant.TerminerService();

            Assert.AreNotSame(restaurant, commandeboissons);
        }




        #endregion
    }
}
