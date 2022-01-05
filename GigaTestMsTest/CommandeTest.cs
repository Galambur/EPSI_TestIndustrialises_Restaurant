using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Le_Grand_Restaurant;

namespace GigaTestMsTest
{
    [TestClass]
    public class CommandeTest
    {
        
        public void CommandeNourriture()
        {
            // ETANT DONNE un serveur dans un restaurant
            var serveur = new Serveur();
            var restaurant = new Restaurant();

            // QUAND il prend une commande de nourriture
            serveur.CommanderNourriture();

            // ALORS cette commande apparait dans la liste de tâche de la cuisine de ce restaurant
        }

        public void CommandeBoisson()
        {
            // ETANT DONNE un serveur dans un restaurant
            var serveur = new Serveur();
            var restaurant = new Restaurant();

            // QUAND il prend une commande de boisson
            serveur.CommanderBoisson();

            // ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant
        }

    }
}
