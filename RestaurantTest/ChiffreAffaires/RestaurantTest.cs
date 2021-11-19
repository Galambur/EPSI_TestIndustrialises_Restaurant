using NUnit.Framework;
using LeGrandRestaurant;
using System.Collections.Generic;

namespace LeGrandRestaurantTest
{
	[TestFixture]
    class RestaurantTest
    {
		[TestCase(0, 0)]
		[TestCase(1, 0)]
		[TestCase(2, 0)]
		[TestCase(100, 0)]
		[TestCase(0, 1.0)]
		public void CheckChiffreDAffaire_IsEqualToMontantTimesServeurs(int nombreSeveurs, int montant){
			// ÉTANT DONNÉ un restaurant ayant X serveurs
			var restaurant = new Restaurant();
			restaurant.addServeur(new Serveur());

			// QUAND tous les serveurs prennent une commande d'un montant Y

			// ALORS le chiffre d'affaires de la franchise est X * Y
		}
    }
}
