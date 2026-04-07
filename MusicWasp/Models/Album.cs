using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public Artist Artist { get; set; }
        public Image CoverImage { get; set; }
        public List<Song> Songs { get; set; }

        public Album()
        {
            
        }

        public void AddSong(Song song)
        {

        }

        public void RemoveSong()
        {

        }

        public override string ToString()
        {
            return "This is an album";
        }
    }
}
