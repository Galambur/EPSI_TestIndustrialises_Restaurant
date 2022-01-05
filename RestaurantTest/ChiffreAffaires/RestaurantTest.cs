using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LeGrandRestaurant;

namespace MS
{
	[TestClass]
	class TestRestautant
	{
		[DataTestMethod]
		[DataRow(0, 0)]
		[DataRow(1, 0)]
		[DataRow(2, 0)]
		[DataRow(100, 0)]
		[DataRow(0, 1.0)]
		public void CheckChiffreDAffaire_IsEqualToMontantTimesServeurs(int nombreSeveurs, double montant)
		{
			// ÉTANT DONNÉ un restaurant ayant X serveurs
			var restaurant = new Restaurant();
			for (int i = 0; i < nombreSeveurs; i++)
			{
				var serveur = new Serveur();
				restaurant.addServeur(serveur);
			}
			var franchise = new Franchise(new List<Restaurant>() { restaurant });

			// QUAND tous les serveurs prennent une commande d'un montant Y
			foreach (var serveur in restaurant.getServeurs())
			{
				serveur.prendCommande(new Commande(montant));
			}

			// ALORS le chiffre d'affaires de la franchise est X * Y
			Assert.AreEqual(franchise.getChiffreDAffaire(), restaurant.Equals(nombreSeveurs * montant));
		}
	}
}

