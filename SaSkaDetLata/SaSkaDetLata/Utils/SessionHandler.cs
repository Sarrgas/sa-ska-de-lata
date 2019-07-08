using SaSkaDetLata.Extensions;
using SaSkaDetLata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaSkaDetLata.Utils
{
    public class SessionHandler : ISessionHandler
    {
        public Song CurrentSong { get; set; }
        public Stack<Song> Playlist { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        private readonly IDbProvider _databaseClient;

        public SessionHandler(IDbProvider databaseClient)
        {
            _databaseClient = databaseClient;
            Playlist = GetPlaylist();
            CurrentSong = Playlist.Pop();
        }

        public void NextSong()
        {
            CurrentSong = Playlist.Pop();
        }

        public Stack<Song> GetPlaylist()
        {
            var allSongs = _databaseClient.ReadFromDatabase();
            return new Stack<Song>(allSongs.Randomize());
        }

        public void Reset()
        {
            Playlist = GetPlaylist();
            CurrentSong = Playlist.Pop();
        }
    }
}
