using MusicWasp.Models;
using MySqlConnector;

namespace MusicWasp.Data
{
    public class UserData : DatabaseConnection
    {
        // Returns the User if credentials are valid, otherwise null.
        public User? Authenticate(string username, string password)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM USER WHERE username = @username AND password = @password";
            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserID = (int)reader["user_id"],
                        Username = (string)reader["username"],
                        EmailAddress = (string)reader["email_address"],
                        Password = (string)reader["password"],
                        DateJoined = DateOnly.FromDateTime(((DateTime)reader["date_joined"])),
                        IsAdmin = Convert.ToBoolean(reader["is_admin"])
                    };
                }
                //connection.Close(); Replaced by using
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Authenticate error: {ex.Message}");
            }
            return null;
        }

        // Creates a new (non-admin) user account, returns the new user_id, or -1 on failure.
        public int RegisterUser(string username, string email, string password)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT INTO USER (username, email_address, password, date_joined, is_admin) " +
                           "VALUES (@username, @email, @password, @dateJoined, 0)";
            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@dateJoined", DateTime.Today);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return (int)command.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RegisterUser error: {ex.Message}");
                return -1;
            }
        }

        // Checks if a username already exists (useful for sign up).
        public bool UsernameExists(string username)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT COUNT(*) FROM USER WHERE username = @username";
            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);

            try
            {
                connection.Open();
                long count = (long)command.ExecuteScalar()!;
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UsernameExists error: {ex.Message}");
                return false;
            }
        }
    }
}