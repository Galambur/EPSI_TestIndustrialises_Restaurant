using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
	public class Querrys
	{
		public static void Employee(MySqlConnection conn)
		{

      string sql = "SELECT * FROM `restaurant`";

      // Créez un objet Command.
      MySqlCommand cmd = new MySqlCommand();

      // Établissez la connexion de la commande.
      cmd.Connection = conn;
      cmd.CommandText = sql;

      using (DbDataReader reader = cmd.ExecuteReader())
      {
        if (reader.HasRows)
        {

          while (reader.Read())
          {
            // Récupérez l'indexe (index) de colonne Emp_ID dans l'instruction de requête SQL.
            int empIdIndex = reader.GetOrdinal("id"); // 0


            long empId = Convert.ToInt64(reader.GetValue(0));

            // La colonne Emp_No a l'indexe = 1.
            string empNo = reader.GetString(1);
            int empNameIndex = reader.GetOrdinal("nom");// 2
            string empName = reader.GetString(empNameIndex);

            Console.WriteLine("--------------------");
            Console.WriteLine("empIdIndex:" + empIdIndex);
            Console.WriteLine("EmpName:" + empName);
          }
        }
      }

    }
  }
}
