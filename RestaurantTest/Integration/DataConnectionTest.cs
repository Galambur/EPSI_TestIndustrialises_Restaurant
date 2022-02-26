using MySqlConnector;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeGrandRestaurant;

namespace LeGrandRestaurantTest
{
	[TestFixture]
	class DataConnectionTest
	{
		[Test]
		public void DBConnection()
		{
      // ÉTANT DONNÉ une base de donnée restaurant
      MySqlConnection conn = DBUtils.GetDBConnection();

      // QUAND on ouvre la connection
      conn.Open();

      // ALORS l'état de connection est ouverte
      Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);

      // Fin du programme
      conn.Close();
      conn.Dispose();
		}

    [Test]
    public void DB_Restaurant_Insert_Test()
    {
      
      // ÉTANT DONNÉ une donnée un restaurant à enregistrer et aucune exception
      var restaurant = new DB_Restaurant("testRestaurant");
      
      Exception ex = null;

      // QUAND on insère le restaurant;
      TestDelegate act = () => DB_Restaurant.InsertRestaurant(restaurant);


      // ALORS aucune erreur est détecté.
      Assert.AreEqual(null, ex);
      Assert.DoesNotThrow(act);

      // Fin du programme
      DB_Restaurant.DeleteRestaurantById(restaurant.Id);
    }

  }
}
