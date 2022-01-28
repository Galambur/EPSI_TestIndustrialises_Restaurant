using MySqlConnector;
using System;

namespace LeGrandRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
              DB_Restaurant.GetAllRestaurant();
            }
            catch (Exception e)
            {
              Console.WriteLine("Error: " + e);
              Console.WriteLine(e.StackTrace);
            }
          }
    }
}
