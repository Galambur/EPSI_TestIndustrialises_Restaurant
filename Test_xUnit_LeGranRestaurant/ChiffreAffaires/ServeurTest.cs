﻿using LeGrandRestaurant;
using Xunit;

namespace Text_xUnit_LeGranRestaurant
{
	public class ServeurTest
	{
		[Fact]
		public void GetServeurChiffreDAffaire_ReturnsZero()
		{
			// etant donné un nouveau serveur
			var serveur = new Serveur();

			// quand on récupère son chiffre d'affaire
			var chiffreAffaire = serveur.getChiffreDAffaire();
			// alors celui ci est a 0
			Assert.Equal(0, chiffreAffaire);
		}

		[Fact]
		public void ServeurGetCommande_GetChiffreDAffaireReturnsCommande()
		{
			// etant donné un nouveau serveur
			var serveur = new Serveur();

			// quand il prend une commande 
			var commande = new Commande(20);
			serveur.prendCommande(commande);

			// alors son chiffre d'affaire est le montant de celle-ci
			Assert.Equal(serveur.getChiffreDAffaire(), commande.getMontant());
		}

		[Fact]
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
			Assert.Equal(serveur.getChiffreDAffaire(), sommeCommandes);
		}
	}
}
