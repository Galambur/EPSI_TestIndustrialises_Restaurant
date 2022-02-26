

using MySqlConnector;

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
