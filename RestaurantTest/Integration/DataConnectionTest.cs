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
		public void DBMySQLUtilsTest()
		{
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
      try
      {
        Querrys.Employee(conn);
      }
      catch (Exception e)
      {
        Console.WriteLine("Error: " + e);
        Console.WriteLine(e.StackTrace);
      }
      finally
      {
        // Terminez la connexion.
        conn.Close();
        // Disposez un objet, libérez des ressources.
        conn.Dispose();
      }
		}
	}
}
