using MySqlConnector;

namespace MusicWasp.Data
{
    public class DatabaseConnection
    {
        private string connectionString =
            "datasource = 127.0.0.1;" +
            "port = 3308;" +
            "username = root; password = ;" +
            "database = MusicWasp";

        public int Insert(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                int result = commandDatabase.ExecuteNonQuery();
                return (int)commandDatabase.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }
    }
}