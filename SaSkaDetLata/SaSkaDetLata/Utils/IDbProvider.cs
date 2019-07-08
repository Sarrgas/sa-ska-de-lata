using SaSkaDetLata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaSkaDetLata.Utils
{
    public interface IDbProvider
    {
        IEnumerable<Song> GetAllSongs();
    }
}
