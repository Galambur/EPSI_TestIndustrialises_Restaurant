﻿using LeGrandRestaurant;
using NUnit.Framework;
using System.Linq;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    public partial class ServeurTest
    {
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
        public void GetChiffreDAffaireReturnsCommandes()
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
    }
}
