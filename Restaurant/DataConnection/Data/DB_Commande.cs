using LeGrandRestaurant;
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
	public class DB_Commande : ICommande
	{
		#region Propriété
		public int Id { get; set; }
		public int IdServeur { get; set; }
		public int IdTable { get; set; }
		public double Montant { get ; set ; }
    public IList<Plat> ListePlat { get ; set ; }
		#endregion

		#region Constructeur
		public DB_Commande() { }
		public DB_Commande(int vidServeur, int vidTable, int vmontant)
		{
      IdServeur = vidServeur;
      IdTable = vidTable;
      Montant = vmontant;
		}
		#endregion

		#region Interface 

		public double getMontant()
    {
      var selfCommande = DB_Commande.GetCommandeById(Id);
      return selfCommande.Montant; ;
    }

    public void setListPLat(IList<Plat> plats)
    {
      throw new NotImplementedException();
    }

    public IList<Plat> getListePlats()
    {
      throw new NotImplementedException();
    }
    #endregion

    #region Private Method
    private static DB_Commande read(DbDataReader reader)
    {
      var commande = new DB_Commande();
      commande.Id = reader.GetInt32(reader.GetOrdinal("id"));
      commande.IdServeur = reader.GetInt32(reader.GetOrdinal("idServeur"));
      commande.IdTable = reader.GetInt32(reader.GetOrdinal("idTable"));
      commande.Montant = reader.GetDouble(reader.GetOrdinal("montant"));
      return commande;
    }
    #endregion

    #region CRUD
    public static void DeleteAllCommandeByIdServeur(int idServeur)
		{
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
      try
      {
        string sql = "DELETE FROM `commande` WHERE idServeur = @IdServeur";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;


        cmd.Parameters.Add("@IdServeur", DbType.Int32).Value = idServeur;

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

		public static DB_Commande GetCommandeById(int id)
    {
      DB_Commande commande = new DB_Commande();
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
			try
			{
        string sql = "SELECT * FROM `commande` where id=@pId";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;

        // Ajoutez le paramètre @highSalary (Écrire plus court).
        MySqlParameter idServeurParam = cmd.Parameters.Add("@pId", DbType.Int32);
        idServeurParam.Value = id;

        
        using (DbDataReader reader = cmd.ExecuteReader())
        {
          if (reader.HasRows)
          {
            reader.Read();
            commande = read(reader);
            Console.WriteLine(commande);
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
      return commande;
    }


    public static DB_Commande InsertCommande(DB_Commande commande)
    {
      MySqlConnection conn = DBUtils.GetDBConnection();
      conn.Open();
      try
      {
        string sql = "INSERT INTO `commande`(`idServeur`,`idTable`,`montant`) VALUES (@idServeur, @idTable,@montant)";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connexion de la commande.
        cmd.Connection = conn;
        cmd.CommandText = sql;

        // Ajoutez le paramètre @highSalary (Écrire plus court).
        MySqlParameter idServeurParam = cmd.Parameters.Add("@idServeur", DbType.Int32);
        idServeurParam.Value = commande.IdServeur;

        // Ajoutez le paramètre @highSalary (Écrire plus court).
        MySqlParameter idTableParam = cmd.Parameters.Add("@idTable", DbType.Int32);
        idTableParam.Value = commande.IdTable;

        // Ajoutez le paramètre @highSalary (Écrire plus court).
        MySqlParameter montantParam = cmd.Parameters.Add("@montant", DbType.Int32);
        montantParam.Value = commande.Montant;


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
         "\nId  : " + this.IdServeur +
         "\nId  : " + this.IdTable +
         "\nId  : " + this.Montant;
    }

		#endregion

	}
}
