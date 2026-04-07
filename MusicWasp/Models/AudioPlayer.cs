using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public class AudioPlayer
    {
        public Song CurrentSong { get; set; }
        public List<Song> SongQueue { get; set; }
        public float Volumne { get; set; }
        public PlaybackState CurrentState { get; set; }
        public int QueueIndex { get; set; }

        public AudioPlayer()
        {
            
        }

        public void PlaySong(Song song)
        {

        }

        public void PlayQueue(List<Song> songs)
        {

        }

        public override string ToString()
        {
            return "This is an audioplayer";
        }
    }
}
