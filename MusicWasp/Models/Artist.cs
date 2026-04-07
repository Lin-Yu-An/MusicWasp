using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public Image ProfileImage { get; set; }

        public Artist()
        {
            
        }

        public override string ToString()
        {
            return "This is an artist";
        }
    }
}
