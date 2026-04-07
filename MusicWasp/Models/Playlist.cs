using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public string Name { get; set; }
        public DateOnly CreatedDate { get; set; }
        public bool IsPublic { get; set; }
        public User Owner { get; set; }
        public Image CoverImage { get; set; }
        public List<Song> Songs {  get; set; }

        public Playlist()
        {
            
        }

        public void AddSong(Song song)
        {

        }

        public void RemoveSong(Song song)
        {

        }

        public List<Song> Shuffle(List<Song> playlist)
        {
            return new List<Song>();
        }

        public int GetSongCount()
        {
            return Songs.Count;
        }

        public int GetTotalDuration(Song song)
        {
            return song.Duration;
        }

        public override string ToString()
        {
            return "This is a playlist";
        }
    }
}
