

using LeGrandRestaurant;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS
{
	[TestClass]
	class TestDebutService
	{
		public Table MaitreHotel()
		{
			//ÉTANT DONNE un restaurant ayant 3 tables
			var restaurant = new Restaurant();
			var table = new Table();
			int x = 3;


			return table;




			//QUAND le service commence


			restaurant.debuterService();

			//ALORS elles sont toutes affectées au Maître d'Hôtel



			//ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
			//QUAND le service débute
			//ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel

			//ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
			//QUAND le service débute
			//ALORS il n'est pas possible de modifier le serveur affecté à la table

			//ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
			//ET ayant débuté son service
			//QUAND le service se termine
			//ET qu'une table est affectée à un serveur
			//ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel
		}
	}
}
