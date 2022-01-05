using LeGrandRestaurant;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace MS
{
    [Test]
    class TestEpinglage
    {
        [Test]
        public void ServeurEpinglé()
        {
            // ÉTANT DONNE un serveur ayant pris une commande
            var serveur = new Serveur();
            var commande = new List<Commande> commande);

            // QUAND il la déclare comme non-payée
            var nonpayé = nonpayé;

            nonpayé.fixerPrix(commande);

            // ALORS cette commande est marquée comme épinglée
            var commande = commande;
            var epingler = epingler;
            Assert.AreEqual(epingler);





            //ÉTANT DONNE un serveur ayant épinglé une commande
            //QUAND elle date d'il y a au moins 15 jours
            //QALORS cette commande est marquée comme à transmettre gendarmerie

            //ÉTANT DONNE une commande à transmettre gendarmerie
            //QUAND on consulte la liste des commandes à transmettre du restaurant
            //ALORS elle y figure

            //ÉTANT DONNE une commande à transmettre gendarmerie
            //QUAND elle est marquée comme transmise à la gendarmerie
            //ALORS elle ne figure plus dans la liste des commandes à transmettre du restaurant
        }

    }
}
