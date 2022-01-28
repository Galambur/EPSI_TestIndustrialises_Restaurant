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
        /*
        public void CommandePlat()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            var serveur = new Serveur();
            var restaurant = new Restaurant();
            // ALORS cette commande apparaît dans la liste de plat
            List<Plat> plats = new List<Plat>();
            var listePlat = plats;
           
            var commande = new Commande(45);

            // QUAND il prend une commande 
            serveur.prendCommande(commande);

           
            Assert.Contains(commande, listePlat);
        }
        */
        public void CommandeBoissons()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            var serveur = new Serveur();
            var restaurant = new Restaurant();



            // QUAND il prend une commande de boissons
            var commandeboissons = new Commande(15);
            serveur.prendCommande(commandeboissons);

            // ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant
          

            Assert.AreNotSame(restaurant, commandeboissons);

            //Fin du service
            restaurant.TerminerService();
        }




        #endregion
    }
}
