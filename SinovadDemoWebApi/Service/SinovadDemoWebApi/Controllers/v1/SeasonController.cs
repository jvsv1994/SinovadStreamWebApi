using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Season;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/tvseries/{tvSerieId:int}/seasons")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _seasonService;

        private readonly ITvSerieService _tvSerieService;

        public SeasonController(ISeasonService seasonService, ITvSerieService tvSerieService)
        {
            _seasonService = seasonService;
            _tvSerieService = tvSerieService;
        }

        [HttpGet("GetAsync/{seasonId:int}", Name = "getSeason")]
        public async Task<ActionResult<Response<SeasonDto>>> GetAsync([FromRoute] int seasonId)
        {
            var response = await _seasonService.GetAsync(seasonId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<SeasonDto>>>> GetAllWithPaginationByTvSerieAsync([FromRoute]int tvSerieId, [FromQuery] int page = 1, 
            [FromQuery] int take = 1000, [FromQuery] string sortBy = "SeasonNumber", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", 
            [FromQuery] string searchBy = "")
        {
            var exists = await _tvSerieService.CheckExistAsync(tvSerieId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _seasonService.GetAllWithPaginationByTvSerieAsync(tvSerieId,page, take, sortBy, sortDirection, searchText, searchBy);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromRoute] int tvSerieId, [FromBody] SeasonCreationDto seasonCreationDto)
        {
            var exists = await _tvSerieService.CheckExistAsync(tvSerieId);
            if (!exists)
            {
                return NotFound("Serie de Tv no encontrada");
            }
            var response = await _seasonService.CreateAsync(tvSerieId, seasonCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getSeason", new {tvSerieId = response.Data.TvSerieId,seasonId = response.Data.Id}, response.Data);
        }

        [HttpPut("UpdateAsync/{seasonId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute]int seasonId, [FromBody] SeasonCreationDto seasonCreationDto)
        {
            var exists = await _seasonService.CheckExistAsync(seasonId);
            if (!exists)
            {
                return NotFound("Temporada no encontrada");
            }
            var response = await _seasonService.UpdateAsync(seasonId, seasonCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{seasonId:int}")]
        public async Task<ActionResult> DeleteAsync(int seasonId)
        {
            var exists = await _seasonService.CheckExistAsync(seasonId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _seasonService.DeleteAsync(seasonId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync(string listIds)
        {
            var response = await _seasonService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

    }
}
