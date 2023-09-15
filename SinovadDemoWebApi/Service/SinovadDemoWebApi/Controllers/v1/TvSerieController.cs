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

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromBody] TvSerieDto TvSerieDto)
        {
            var response = await _tvSerieService.CreateAsync(TvSerieDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync/{tvSerieId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int tvSerieId,[FromBody] TvSerieDto TvSerieDto)
        {
            var exists = await _tvSerieService.CheckExistAsync(tvSerieId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _tvSerieService.UpdateAsync(TvSerieDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteAsync/{tvSerieId:int}")]
        public async Task<ActionResult> DeleteAsync([FromRoute]int tvSerieId)
        {
            var exists = await _tvSerieService.CheckExistAsync(tvSerieId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _tvSerieService.DeleteAsync(tvSerieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync(string listIds)
        {
            var response = await _tvSerieService.DeleteListAsync(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }

}
