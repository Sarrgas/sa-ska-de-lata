using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaSkaDetLata.Models;

namespace SaSkaDetLata.Pages
{
    public class NewSongModel : PageModel
    {
        [BindProperty]
        public Song NewSong { get; set; }
        public void OnGet()
        {
            NewSong = new Song();
        }

        public void OnPost()
        {
            // All data finns i NewSong variabeln!
        }

    }
}