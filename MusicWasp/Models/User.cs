using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public static class CurrentUser
    {
        //public static User? User { get; set; }
        //public static bool IsLoggedIn => User != null;
        //public static bool IsAdmin => User?.IsAdmin == true;
        public static User? LoggedInUser { get; set; }
        public static bool IsLoggedIn => LoggedInUser != null;
        public static bool IsAdmin => LoggedInUser != null && LoggedInUser.IsAdmin;
    }

    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateOnly DateJoined { get; set; }
        public Image ProfileImage { get; set; }
        public bool IsAdmin { get; set; }

        public User()
        {
            
        }

        // Hardcoded list of fake users for testing.
        // Later, you can replace this with data from the database.
        public static List<User> FakeUsers = new List<User>
        {
            new User
            {
                UserID = 1,
                Username = "user",
                Password = "user123",
                EmailAddress = "user@test.com",
                IsAdmin = false
            },
            new User
            {
                UserID = 2,
                Username = "admin",
                Password = "admin123",
                EmailAddress = "admin@test.com",
                IsAdmin = true
            }
        };

        // Looks through the fake users list for a matching username + password.
        // Returns the user if found, otherwise null.
        public static User? Login(string username, string password)
        {
            foreach (User user in FakeUsers)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public Playlist AddPlaylist()
        {
            return new Playlist();
        }

        public void RemovePlaylist()
        {

        }

        public void AddGroup()
        {

        }

        public void RemoveGroup()
        {

        }

        public override string ToString()
        {
            return "This is a user";
        }
    }
}
