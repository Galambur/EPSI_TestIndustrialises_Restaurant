using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
	public class DB_Table : Table
	{
		private int id;

		public int Id
		{
			get { return id; }
			private set { id = value; }
		}

    private static DB_Table read(DbDataReader reader)
		{
      var table = new DB_Table();
      table.Id = reader.GetInt32(reader.GetOrdinal("id"));
      return table;
		}

		public static void GetAllTable()
    {
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
			try
			{
        string sql = "SELECT * FROM `tablerestaurant`";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;

        List<DB_Table> tables = new List<DB_Table>();
        using (DbDataReader reader = cmd.ExecuteReader())
        {
          if (reader.HasRows)
          {
            while (reader.Read())
            {
              var table = read(reader);
              tables.Add(table);

              Console.WriteLine(table);
            }
          }
        }
      }
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
        conn.Close();
        conn.Dispose();
			}
    }

		public static void DeleteTableById(int id)
		{
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
      try
      {
        string sql = "DELETE FROM `tablerestaurant` WHERE id = @Id";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;


        cmd.Parameters.Add("@Id", DbType.Int32).Value = id;

        // Exécutez Command (Utilisez pour supprimer, insérer, mettre à jour).
        int rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine("Row Count affected = " + rowCount);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        conn.Close();
        conn.Dispose();
      }
    }

		public static DB_Table InsertTable()
    {
      DB_Table table = new DB_Table();
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
      try
      {
        string sql = "INSERT INTO `tablerestaurant`(`id`) VALUES (null)";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;

        // Exécutez la Commande (Utilisez pour supprimer, insérer, mettre à jour).
        int rowCount = cmd.ExecuteNonQuery();

        table.Id = (int)cmd.LastInsertedId;

        Console.WriteLine("Row Count affected = " + rowCount);

      }
      catch (Exception ex)
      {
        throw ex;
			}
			finally
			{
        conn.Close();
        conn.Dispose();
			}

      if (table.Id != null)
        return table;
      else
        return null;
    }


    public override string ToString()
		{
      return
        "--------------" +
        "\nId  : " + this.Id;
		}
	}
}
