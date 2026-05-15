using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MusicWasp.Models
{
    public class SongManager
    {
        public static ObservableCollection<Song> _DatabaseSong = new ObservableCollection<Song>() {
            new Song() { Title = "Never Gonna Give You Up", Duration = 213, Artists = new List<Artist>() { new Artist() { Name = "Rick Astley" } } },
            new Song() { Title = "We Lost", Duration = 513, Artists = new List<Artist>() { new Artist() { Name = "Lorien Testard" } } } };

        public static ObservableCollection<Song> GetSongs()
        {
            return _DatabaseSong;
        }

        public static void AddSong(Song song)
        {
            _DatabaseSong.Add(song);
        }
    }
}