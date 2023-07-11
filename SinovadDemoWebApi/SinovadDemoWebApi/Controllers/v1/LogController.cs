using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.Builder;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/logs")]
    [Authorize]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class LogController : Controller
    {

        private readonly SearchMediaLogBuilder _searchMediaLogBuilder;

        public LogController(SearchMediaLogBuilder searchMediaLogBuilder)
        {
            _searchMediaLogBuilder = searchMediaLogBuilder;
        }

        [HttpGet]
        public ActionResult GetLog(string identifier)
        {
            var response = new Response<object>();
            try
            {
                var searchMediaLog = _searchMediaLogBuilder.getSearchMediaLog(identifier);
                if(searchMediaLog!=null)
                {
                    response.Data = searchMediaLog.GetLogWithSeparationLines();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return Ok(response);
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                return BadRequest(response);
            }
        }

    }
}
