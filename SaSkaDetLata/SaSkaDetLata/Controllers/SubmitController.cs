using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaSkaDetLata.Controllers
{
    [Route("onsubmit")]
    [ApiController]
    public class SubmitController : ControllerBase
    {
        public IActionResult Submit([FromBody] object formData)
        {

            return null;
        }
    }
}