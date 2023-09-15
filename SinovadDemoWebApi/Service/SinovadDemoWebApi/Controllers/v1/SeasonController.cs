using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/seasons")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _seasonService;

        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        [HttpGet("GetTvSeasonAsync")]
        public async Task<ActionResult<Response<SeasonDto>>> GetTvSeasonAsync([FromQuery] int tvSerieId, [FromQuery] int seasonNumber)
        {
            var response = await _seasonService.GetTvSeasonAsync(tvSerieId,seasonNumber);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{seasonId:int}")]
        public async Task<ActionResult<Response<SeasonDto>>> GetAsync(int seasonId)
        {
            var response = await _seasonService.GetAsync(seasonId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationByTvSerieAsync/{tvSerieId:int}")]
        public async Task<ActionResult<ResponsePagination<List<SeasonDto>>>> GetAllWithPaginationByTvSerieAsync([FromRoute]int tvSerieId, [FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "SeasonNumber", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _seasonService.GetAllWithPaginationByTvSerieAsync(tvSerieId,page, take, sortBy, sortDirection, searchText, searchBy);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPost("CreateAsync")]
        public async Task<ActionResult<Response<object>>> CreateAsync([FromBody] SeasonDto seasonDto)
        {
            var response = await _seasonService.CreateAsync(seasonDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPut("UpdateAsync/{seasonId:int}")]
        public async Task<ActionResult<Response<object>>> UpdateAsync([FromRoute]int seasonId, [FromBody] SeasonDto seasonDto)
        {
            var exists = await _seasonService.CheckExistAsync(seasonId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _seasonService.UpdateAsync(seasonDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpDelete("DeleteAsync/{seasonId:int}")]
        public async Task<ActionResult<Response<object>>> DeleteAsync(int seasonId)
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
            return response;
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult<Response<object>>> DeleteListAsync(string listIds)
        {
            var response = await _seasonService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

    }
}
