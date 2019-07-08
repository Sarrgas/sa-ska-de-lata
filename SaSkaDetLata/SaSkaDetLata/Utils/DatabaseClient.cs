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
        public IEnumerable<Song> ReadFromDatabase()
        {
            IFirebaseConfig config = new FirebaseConfig()
            {
                AuthSecret = "JPVcYaQsp7Sc4cESsiki1Q7V8MDkHDEVsiw3VMND",
                BasePath = "https://sa-ska-det-lata.firebaseio.com/",
            };

            IFirebaseClient client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("/Songs");

            FirebaseConverter firebaseConverter = new FirebaseConverter();
            var songs = firebaseConverter.ToSongList(response);
            return songs;
        }

        private void SaveToDatabase()
        {
            // Detta sparar ny låt i databasen.
            // PushResponse response = client.Push("/Songs", songs.ToList()[2]);
        }

    }
}
