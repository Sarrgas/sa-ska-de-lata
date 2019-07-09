using SaSkaDetLata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace SaSkaDetLata.Utils
{
    public class DatabaseClient : IDbProvider
    {
        private readonly IFirebaseClient _client;
        private readonly FirebaseConverter _firebaseConverter;
        public DatabaseClient()
        {
            IFirebaseConfig config = new FirebaseConfig()
            {
                AuthSecret = "JPVcYaQsp7Sc4cESsiki1Q7V8MDkHDEVsiw3VMND",
                BasePath = "https://sa-ska-det-lata.firebaseio.com/",
            };

            _client = new FireSharp.FirebaseClient(config);
            _firebaseConverter = new FirebaseConverter();
        }
        public IEnumerable<Song> ReadFromDatabase()
        {
            FirebaseResponse response = _client.Get("/Songs");
            
            var songs = _firebaseConverter.ToSongList(response);
            return songs;
        }

        public void SaveToDatabase(Song song)
        {
            _client.Push("/Songs", song);
        }

    }
}
