using MySqlConnector;

namespace MusicWasp.Data
{
    public class DatabaseConnection
    {
        protected string connectionString =
            "datasource = 127.0.0.1;" +
            "port = 3308;" +
            "username = root; password = ;" +
            "database = MusicWasp";

        protected int Insert(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return (int)command.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        protected void Execute(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}