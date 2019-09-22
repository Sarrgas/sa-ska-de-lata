using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaSkaDetLata.Models;
using SaSkaDetLata.Utils;

namespace SaSkaDetLata.Pages
{
    public class NewSongModel : PageModel
    {
        [BindProperty]
        public Song NewSong { get; set; }
        private readonly IDbProvider _dbProvider;

        public NewSongModel(IDbProvider dbProvider)
        {
            this._dbProvider = dbProvider;
        }
        public void OnGet()
        {
            this.NewSong = new Song();
            this.NewSong.Populate();
        }

        public RedirectToPageResult OnPost()
        {
            // _dbProvider.SaveToDatabase(NewSong);
            this.SaveToDatabase(this.NewSong);
            System.Threading.Thread.Sleep(1000);
            this.ModelState.Clear();
            return this.RedirectToPage("NewSong");
        }

        private void SaveToDatabase(Song song) // FUL-LÖSNING!
        {
            IFirebaseConfig config = new FirebaseConfig()
            {
                AuthSecret = "JPVcYaQsp7Sc4cESsiki1Q7V8MDkHDEVsiw3VMND",
                BasePath = "https://sa-ska-det-lata.firebaseio.com/",
            };

            IFirebaseClient _client = new FireSharp.FirebaseClient(config);
            _client.Push("/Songs", song);
        }

    }
}