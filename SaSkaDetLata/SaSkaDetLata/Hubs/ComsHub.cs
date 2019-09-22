namespace SaSkaDetLata.Hubs
{
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;
    using SaSkaDetLata.Models;
    using SaSkaDetLata.Utils;

    public class ComsHub : Hub
    {
        private readonly ISessionHandler session;

        public ComsHub(ISessionHandler session)
        {
            this.session = session;
        }

        public async Task OpenPanel(string number)
        {
            int index = int.Parse(number);
            int squareNumber = index - 1;
            Panel panelInfo = this.session.CurrentSong.Panels[squareNumber];
            await this.Clients.All.SendAsync("OpenPanel", panelInfo);
        }

        public async Task NextSong()
        {
            this.session.NextSong();
            if (this.session.CurrentSong != null)
            {
                await this.Clients.All.SendAsync("CurrentSong", this.session.CurrentSong);
                await this.Clients.All.SendAsync("NextSong");
            }
            else
            {
                await this.Clients.All.SendAsync("OutOfSongs");
            }
        }

        public async Task Reset()
        {
            this.session.Reset();
            await this.Clients.All.SendAsync("Reset");
            await this.Clients.All.SendAsync("SongCount", this.session.SongCount);
            await this.Clients.All.SendAsync("CurrentSong", this.session.CurrentSong);
        }

        public async Task GiveScore(string team, int increment){
            await this.Clients.All.SendAsync("GiveScore", team, increment);
        }

        public async Task Initialize()
        {
            await this.Clients.All.SendAsync("CurrentSong", this.session.CurrentSong);
            await this.Clients.All.SendAsync("SongCount", this.session.SongCount);
        }

        public async Task CheckAnswer(string input)
        {
            string regex = "[^a-z]";

            string filteredInput = Regex.Replace(input.ToLower(), regex, string.Empty);
            string filteredAnswer = Regex.Replace(this.session.CurrentSong.SongName.ToLower(), regex, string.Empty);

            bool answerWasCorrect = filteredInput == filteredAnswer;

            await this.Clients.All.SendAsync("Answer", answerWasCorrect);
        }
    }
}
