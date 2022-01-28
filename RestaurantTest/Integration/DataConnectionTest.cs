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
    public void DB()
    {
      // ÉTANT DONNÉ un restaurant enregistré
      MySqlConnection conn = DBUtils.GetDBConnection();

      // QUAND on ouvre la connection
      conn.Open();

      // ALORS l'état de connection est ouverte
      Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);

      // Fin du programme
      conn.Close();
      conn.Dispose();
    }


  }
}
