using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/tvseries")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class TvSerieController : ControllerBase
    {
        private readonly ITvSerieService _tvSerieService;

        public TvSerieController(ITvSerieService tvSerieService)
        {
            _tvSerieService = tvSerieService;
        }

        [HttpGet("SearchAsync/{query}")]
        public async Task<ActionResult> SearchAsync(string query)
        {
            var response = await _tvSerieService.SearchAsync(query);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{tvSerieId}")]
        public async Task<ActionResult> GetAsync(int tvSerieId)
        {
            var response = await _tvSerieService.GetAsync(tvSerieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult> GetAllAsync()
        {
            var response = await _tvSerieService.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult> GetAllWithPaginationAsync([FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _tvSerieService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] TvSerieDto TvSerieDto)
        {
            var response = _tvSerieService.Create(TvSerieDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] TvSerieDto TvSerieDto)
        {
            var response = _tvSerieService.Update(TvSerieDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{tvSerieId}")]
        public ActionResult Delete(int tvSerieId)
        {
            var response = _tvSerieService.Delete(tvSerieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _tvSerieService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }

}
