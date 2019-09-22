using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaSkaDetLata.Models
{
    public class Song
    {
        public List<Panel> Panels { get; set; }
        public string ArtistName { get; set; }
        public string SongName { get; set; }
        public string Lyrics { get; set; }

        public void Populate()
        {
            this.Panels = new List<Panel>();
            for (int i = 0; i < 6; i++)
            {
                this.Panels.Add(new Panel());
            }
        }
    }
}
