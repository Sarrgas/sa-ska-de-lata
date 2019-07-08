using SaSkaDetLata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaSkaDetLata.Utils
{
    public class DatabaseClient : IDbProvider
    {
        private IEnumerable<Song> AllSongs { get; set; }

        public IEnumerable<Song> GetAllSongs()
        {
            if (AllSongs == null)
            {
                AllSongs = ReadFromDatabase();
            }

            return AllSongs;
        }

        private IEnumerable<Song> ReadFromDatabase()
        {
            IEnumerable<Song> songs = GetSongs();
            return songs;
        }

        private IEnumerable<Song> GetSongs()
        {
            List<Song> songs = new List<Song>
            {
                GenerateDummySong1(),
                GenerateDummySong2(),
                GenerateDummySong3()
            };
            return songs;
        }

        private Song GenerateDummySong1() //PLACEHOLDER
        {
            Panel panel1 = new Panel()
            {
                Number = 1,
                Red = true,
                Word = "Avundsjuk"
            };

            Panel panel2 = new Panel()
            {
                Number = 2,
                Red = false,
                Word = "jag"
            };

            Panel panel3 = new Panel()
            {
                Number = 3,
                Red = false,
                Word = "är"
            };

            Panel panel4 = new Panel()
            {
                Number = 4,
                Red = false,
                Word = "så"
            };

            Panel panel5 = new Panel()
            {
                Number = 5,
                Red = true,
                Word = "avundsjuk"
            };

            Panel panel6 = new Panel()
            {
                Number = 6,
                Red = false,
                Word = "jä jävlar"
            };

            Song song = new Song()
            {
                ArtistName = "Nanne Grönwall",
                SongName = "Avundsjuk",
                Lyrics = "För jag är avundsjuk, jag är så avundsjuk Det finns så mycket jag behöver: Karlar och en massa klöver Avundsjuk, jag är så avundsjuk",
                Panels = new List<Panel>() {
                    panel1,
                    panel2,
                    panel3,
                    panel4,
                    panel5,
                    panel6
                }
            };

            return song;
        }

        private Song GenerateDummySong2() //PLACEHOLDER
        {
            Panel panel1 = new Panel()
            {
                Number = 1,
                Red = false,
                Word = "Jag"
            };

            Panel panel2 = new Panel()
            {
                Number = 2,
                Red = false,
                Word = "är"
            };

            Panel panel3 = new Panel()
            {
                Number = 3,
                Red = false,
                Word = "en"
            };

            Panel panel4 = new Panel()
            {
                Number = 4,
                Red = true,
                Word = "jävel"
            };

            Panel panel5 = new Panel()
            {
                Number = 5,
                Red = false,
                Word = "på"
            };

            Panel panel6 = new Panel()
            {
                Number = 6,
                Red = true,
                Word = "kärlek"
            };

            Song song = new Song()
            {
                ArtistName = "Glennmark Eriksson Strömstedt",
                SongName = "Jävel Gå Kärlek",
                Lyrics = "Jag är en jävel på kärlek, jag är jävel på att kyssa flickorna. Jag är en jävel på kärlek, och det finns ingen som kan slå mig på fingrarna där.",
                Panels = new List<Panel>() {
                    panel1,
                    panel2,
                    panel3,
                    panel4,
                    panel5,
                    panel6
                }
            };

            return song;
        }


        private Song GenerateDummySong3() //PLACEHOLDER
        {
            Panel panel1 = new Panel()
            {
                Number = 1,
                Red = false,
                Word = "Och"
            };

            Panel panel2 = new Panel()
            {
                Number = 2,
                Red = true,
                Word = "slåss"
            };

            Panel panel3 = new Panel()
            {
                Number = 3,
                Red = false,
                Word = "för"
            };

            Panel panel4 = new Panel()
            {
                Number = 4,
                Red = false,
                Word = "den"
            };

            Panel panel5 = new Panel()
            {
                Number = 5,
                Red = true,
                Word = "jag"
            };

            Panel panel6 = new Panel()
            {
                Number = 6,
                Red = false,
                Word = "är"
            };

            Song song = new Song()
            {
                ArtistName = "Glennmark Eriksson Strömstedt",
                SongName = "Jävel Gå Kärlek",
                Lyrics = "Jag är en jävel på kärlek, jag är jävel på att kyssa flickorna. Jag är en jävel på kärlek, och det finns ingen som kan slå mig på fingrarna där.",
                Panels = new List<Panel>() {
                    panel1,
                    panel2,
                    panel3,
                    panel4,
                    panel5,
                    panel6
                }
            };

            return song;
        }
    }
}
