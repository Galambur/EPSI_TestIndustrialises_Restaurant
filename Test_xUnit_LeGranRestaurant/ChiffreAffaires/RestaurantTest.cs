using LeGrandRestaurant;
using System.Collections.Generic;
using Xunit;

namespace Text_xUnit_LeGranRestaurant
{

	class RestaurantTest
	{
		[InlineData(0, 0)]
		[InlineData(1, 0)]
		[InlineData(2, 0)]
		[InlineData(100, 0)]
		[InlineData(0, 1.0)]
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
			Assert.Equal(franchise.getChiffreDAffaire(), nombreSeveurs * montant);
		}
	}
}
