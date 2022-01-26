using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
	public class DBUtils
	{
    public static MySqlConnection GetDBConnection()
    {
      string host = "localhost";
      int port = 3306;
      string database = "restaurant";
      string username = "root";
      string password = "";

      return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
    }
  }
}
