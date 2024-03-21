using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vibro.API.Controllers
{
    // https://localhost:portnumber/api/vibes
    [Route("api/[controller]")]
    [ApiController]
    public class VibesController : ControllerBase
    {
        // GET: https://localhost:portnumber/api/vibes
        [HttpGet]
        public IActionResult GetAllVibes()
        {
            string[] vibeNames = 
        }
    }
}
