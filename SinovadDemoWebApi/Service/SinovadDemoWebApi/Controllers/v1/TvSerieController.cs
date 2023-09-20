using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.TvSerie;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/tvseries")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = false)]
    public class TvSerieController : ControllerBase
    {
        private readonly ITvSerieService _tvSerieService;

        public TvSerieController(ITvSerieService tvSerieService)
        {
            _tvSerieService = tvSerieService;
        }

        [HttpGet("GetAsync/{id:int}", Name = "getTvSerie")]
        public async Task<ActionResult<Response<TvSerieWithGenresDto>>> GetAsync(int id)
        {
            var response = await _tvSerieService.GetAsync(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<Response<List<TvSerieDto>>>> GetAllAsync()
        {
            var response = await _tvSerieService.GetAllAsync();
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<TvSerieDto>>>> GetAllWithPaginationAsync([FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _tvSerieService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromBody] TvSerieCreationDto tvSerieCreationDto)
        {
            var response = await _tvSerieService.CreateAsync(tvSerieCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getTvSerie", new { id = response.Data.Id }, response.Data);
        }

        [HttpPut("UpdateAsync/{tvSerieId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int tvSerieId,[FromBody] TvSerieCreationDto tvSerieCreationDto)
        {
            var exists = await _tvSerieService.CheckExistAsync(tvSerieId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _tvSerieService.UpdateAsync(tvSerieId, tvSerieCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
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
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync(string listIds)
        {
            var response = await _tvSerieService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

    }

}
