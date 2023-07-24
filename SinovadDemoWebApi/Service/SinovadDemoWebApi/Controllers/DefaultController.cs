using Microsoft.AspNetCore.Mvc;

namespace SinovadDemoWebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : Controller
    {

        [HttpGet]
        public string GetLog()
        {
            return "Running";
        }

    }
}
