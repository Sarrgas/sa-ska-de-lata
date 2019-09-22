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
        public int SongCount { get; set; }
        public Song CurrentSong { get; set; }
        public Stack<Song> Playlist { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        private readonly IDbProvider _databaseClient;

        public SessionHandler(IDbProvider databaseClient)
        {
            this._databaseClient = databaseClient;
            this.Playlist = this.GetPlaylist();
            this.CurrentSong = this.Playlist.Pop();
        }

        public void NextSong()
        {
            if (this.Playlist.Count > 0)
            {
                this.CurrentSong = this.Playlist.Pop(); 
            }
            else
            {
                this.CurrentSong = null;
            }
        }

        public Stack<Song> GetPlaylist()
        {
            var allSongs = this._databaseClient.ReadFromDatabase();
            this.SongCount = allSongs.Count();
            return new Stack<Song>(allSongs.Randomize());
        }

        public void Reset()
        {
            this.Playlist = this.GetPlaylist();
            this.CurrentSong = this.Playlist.Pop();
        }
    }
}
