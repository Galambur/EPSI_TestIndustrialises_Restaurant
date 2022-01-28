using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeGrandRestaurant;
namespace LeGrandRestaurantTest
{
	public class DB_Restaurant_Test : IDisposable
	{
		public static string MockNom = "TestRestaurant";

		public DB_Restaurant GenerateMockRestaurant()
		{
			var MockRestaurant = new DB_Restaurant();
			MockRestaurant.Nom = MockNom;

			return MockRestaurant;
		}
		public void Dispose()
		{
			DB_Restaurant.DeleteRestaurantByName(MockNom);
		}
	}
}
