using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _dbProvider = dbProvider;
        }
        public void OnGet()
        {
            NewSong = new Song();
            NewSong.Populate();
        }

        public RedirectToPageResult OnPost()
        {
            _dbProvider.SaveToDatabase(NewSong);
            System.Threading.Thread.Sleep(1000);
            ModelState.Clear();
            return RedirectToPage("NewSong");
        }

    }
}