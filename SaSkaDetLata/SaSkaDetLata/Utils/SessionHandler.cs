namespace SaSkaDetLata.Utils
{
    using System.Collections.Generic;
    using System.Linq;
    using SaSkaDetLata.Extensions;
    using SaSkaDetLata.Models;

    public class SessionHandler : ISessionHandler
    {
        private readonly IDbProvider databaseClient;
        public int SongCount { get; set; }

        public Song CurrentSong { get; set; }

        public Stack<Song> Playlist { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }


        public SessionHandler(IDbProvider databaseClient)
        {
            this.databaseClient = databaseClient;
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
            var allSongs = this.databaseClient.ReadFromDatabase();
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
