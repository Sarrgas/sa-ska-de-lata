﻿using SaSkaDetLata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaSkaDetLata.Utils
{
    public interface ISessionHandler
    {
        int SongCount { get; set; }
        Song CurrentSong { get; set; }
        void NextSong();
        void Reset();
    }
}
