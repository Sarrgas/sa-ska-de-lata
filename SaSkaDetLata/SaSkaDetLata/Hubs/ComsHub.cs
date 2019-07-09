﻿using Microsoft.AspNetCore.SignalR;
using SaSkaDetLata.Models;
using SaSkaDetLata.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaSkaDetLata.Hubs
{
    public class ComsHub : Hub
    {
        private readonly ISessionHandler _session;

        public ComsHub(ISessionHandler session)
        {
            _session = session;
        }

        public async Task OpenPanel(string number)
        {
            int index = int.Parse(number);
            int squareNumber = index - 1;
            Panel panelInfo = _session.CurrentSong.Panels[squareNumber];
            await Clients.All.SendAsync("OpenPanel", panelInfo);
        }
        public async Task NextSong()
        {
            _session.NextSong();
            if (_session.CurrentSong != null)
            {
                await Clients.All.SendAsync("CurrentSong", _session.CurrentSong);
                await Clients.All.SendAsync("NextSong");
            }
            else
            {
                await Clients.All.SendAsync("OutOfSongs");
            }
        }

        public async Task Reset()
        {
            _session.Reset();
            await Clients.All.SendAsync("Reset");
        }

        public async Task GiveScore(string team, int increment){
            await Clients.All.SendAsync("GiveScore", team, increment);
        }

        public async Task GetCurrentSong()
        {
            await Clients.All.SendAsync("CurrentSong", _session.CurrentSong);
        }
    }
}
