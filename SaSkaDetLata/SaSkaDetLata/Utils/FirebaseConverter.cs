using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SaSkaDetLata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaSkaDetLata.Utils
{
    public class FirebaseConverter
    {
        public IEnumerable<Song> ToSongList(FirebaseResponse response)
        {
            dynamic songsFromDb = JsonConvert.DeserializeObject<dynamic>(response.Body);
            List<Song> songList = new List<Song>();
            foreach (var item in songsFromDb)
            {
                string value = ((JProperty)item).Value.ToString();
                Song song = JsonConvert.DeserializeObject<Song>(value);
                songList.Add(song);
            }

            return songList;
        }
    }
}
