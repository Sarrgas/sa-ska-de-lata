using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaSkaDetLata.Models;

namespace SaSkaDetLata.Controllers
{
    [Route("newsong")]
    [ApiController]
    public class SubmitController : ControllerBase
    {
        [HttpPost("submit")]
        public IActionResult Submit([FromForm]SongTEMP test)
        {
            return View();
        }
    }
}