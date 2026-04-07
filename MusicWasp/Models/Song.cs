using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string FilePath { get; set; }
        public List<Artist> Artists { get; set; } = new();
        public Genre Genre { get; set; }
        public int PlayCount { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public Song()
        {
            
        }
    }
}
