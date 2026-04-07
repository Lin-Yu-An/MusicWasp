using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateOnly DateJoined { get; set; }
        public Image ProfileImage { get; set; }
        public bool isAdmin { get; set; }

        public User()
        {
            
        }

        public void Register()
        {

        }

        public void Login()
        {

        }

        public void Logout()
        {

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
