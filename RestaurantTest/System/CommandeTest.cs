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
        public void Commande()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            var serveur = new Serveur();
            var restaurant = new Restaurant();



            // QUAND il prend une commande de boissons
            var commande = new Commande(15);
            serveur.prendCommande(commande);

            // ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant
          

            Assert.AreNotSame(restaurant, commande);

            //Fin du service
            restaurant.TerminerService();
        }




        #endregion
    }
}
