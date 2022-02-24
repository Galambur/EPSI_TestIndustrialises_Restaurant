using LeGrandRestaurant;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandCommande
{
	public class DB_Commande : Commande,DB_ITable
	{
		public DB_Commande(string v, double v) 
		{

		}
    private string prenom;

		public string Prenom
		{
			get { return prenom; }
			set { prenom = value; }
		}

    private string nom;

    public string Nom
    {
      get { return nom; }
      set { nom = value; }
    }

    private int id;

		public int Id
		{
			get { return id; }
			private set { id = value; }
		}

    private static DB_Commande read(DbDataReader reader)
		{
      var commande = new DB_Commande();
      commande.Id = reader.GetInt32(reader.GetOrdinal("id"));
      commande.Prenom = reader.GetString(reader.GetOrdinal("prenom"));
      commande.Nom = reader.GetString(reader.GetOrdinal("nom"));
      return commande;
		}

		public static void DeleteCommandeByName(string nom)
		{
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
      try
      {
        string sql = "DELETE FROM `commande` WHERE nom = @Nom";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;


        cmd.Parameters.Add("@Nom", DbType.String).Value = nom;

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

		public static void GetAllCommande()
    {
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
			try
			{
        string sql = "SELECT * FROM `commande`";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;

        List<DB_Commande> commandes = new List<DB_Commande>();
        using (DbDataReader reader = cmd.ExecuteReader())
        {
          if (reader.HasRows)
          {
            while (reader.Read())
            {
              var commande = read(reader);
              commandes.Add(commande);

              Console.WriteLine(commande);
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


    public static DB_Commande InsertCommande(DB_Commande commande)
    {
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
      try
      {
        string sql = "INSERT INTO `commande`(`nom`,`prenom`) VALUES (@Nom, @prenom)";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;

        // Ajoutez le paramètre @highSalary (Écrire plus court).
        MySqlParameter prenomParam = cmd.Parameters.Add("@Prenom", DbType.String);
        prenomParam.Value = commande.Prenom;

        // Ajoutez le paramètre @highSalary (Écrire plus court).
        MySqlParameter nomParam = cmd.Parameters.Add("@Nom", DbType.String);
        nomParam.Value = commande.Nom;

        // Exécutez la Commande (Utilisez pour supprimer, insérer, mettre à jour).
        int rowCount = cmd.ExecuteNonQuery();
        commande.Id = (int)cmd.LastInsertedId;

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
      if (commande.Id != null)
        return commande;
      else
        return commande;

    }


    public override string ToString()
		{
			return 
        "--------------" +
        "\nId  : " + this.Id +
        "\nNom : " + this.Prenom;
		}
	}
}
