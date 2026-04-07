using MusicWasp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Data
{
    public class SongData : DatabaseConnection
    {
        public int InsertSong(Song song)
        {
            string query = $"INSERT INTO SONG(song_id, title, duration_seconds, play_count) " 
                + $"VALUES(NULL, " + $"{song.SongID}, '{song.Title}', {song.Duration}, {song.PlayCount});";
            return this.Insert(query);
        }
    }
}
