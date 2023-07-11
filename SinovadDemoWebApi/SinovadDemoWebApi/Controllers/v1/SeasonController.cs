using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

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

        [HttpGet("GetAsync/{seasonId}")]
        public async Task<ActionResult> GetAsync(int seasonId)
        {
            var response = await _seasonService.GetAsync(seasonId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationByTvSerieAsync/{tvSerieId}")]
        public async Task<ActionResult> GetAllWithPaginationByTvSerieAsync(int tvSerieId,[FromQuery] int page = 1,[FromQuery] int take = 1000)
        {
            var response = await _seasonService.GetAllWithPaginationByTvSerieAsync(tvSerieId,page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPost("Create")]
        public ActionResult Create([FromBody] SeasonDto seasonDto)
        {
            var response = _seasonService.Create(seasonDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] SeasonDto seasonDto)
        {
            var response = _seasonService.Update(seasonDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{seasonId}")]
        public ActionResult Delete(int seasonId)
        {
            var response = _seasonService.Delete(seasonId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _seasonService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
