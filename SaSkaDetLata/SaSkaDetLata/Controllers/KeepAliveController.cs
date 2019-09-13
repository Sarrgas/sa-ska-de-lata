namespace SaSkaDetLata.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class KeepAliveController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Session extended";
        }
    }
}