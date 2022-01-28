using MySqlConnector;
using System;

namespace LeGrandRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
