using MusicWasp.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Data
{
    public class SongData : DatabaseConnection
    {
        public int InsertSong(Song song)
        {
            string query = $"INSERT INTO SONG(song_id, title, duration_seconds, play_count) " +
                $"VALUES(NULL, '{song.Title}', {song.Duration}, {song.PlayCount});";
            return this.Insert(query);
        }

        public List<Song> GetAllSongs()
        {
            List<Song> songs = new List<Song>();
            using MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM SONG";
            using MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    songs.Add(new Song()
                    {
                        SongID = (int)reader["song_id"],
                        Title = (string)reader["title"],
                        Duration = (int)reader["duration_seconds"],
                        PlayCount = (int)reader["play_count"]
                    });
                }
                //connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return songs;
        }

        public Song? GetSongById(int songId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = $"SELECT * FROM SONG WHERE song_id = {songId}";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Song song = new Song()
                    {
                        SongID = (int)reader["song_id"],
                        Title = (string)reader["title"],
                        Duration = (int)reader["duration_seconds"],
                        PlayCount = (int)reader["play_count"]
                    };
                    connection.Close();
                    return song;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void UpdateSong(Song song)
        {
            string query = $"UPDATE SONG SET " +
                $"title = '{song.Title}', " +
                $"duration_seconds = {song.Duration}, " +
                $"play_count = {song.PlayCount} " +
                $"WHERE song_id = {song.SongID};";
            Execute(query);
        }

        public void DeleteSong(int songId)
        {
            string query = $"DELETE FROM SONG WHERE song_id = {songId};";
            Execute(query);
        }

        public List<Song> GetSongsByArtist(int artistId)
        {
            List<Song> songs = new List<Song>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = $"SELECT s.* FROM SONG s " +
                $"INNER JOIN SONG_ARTIST sa ON s.song_id = sa.song_id " +
                $"WHERE sa.artist_id = {artistId}";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    songs.Add(new Song()
                    {
                        SongID = (int)reader["song_id"],
                        Title = (string)reader["title"],
                        Duration = (int)reader["duration_seconds"],
                        PlayCount = (int)reader["play_count"]
                    });
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return songs;
        }
    }
}
