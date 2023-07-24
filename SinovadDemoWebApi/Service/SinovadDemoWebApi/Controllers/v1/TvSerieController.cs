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
        public async Task<ActionResult> GetAllWithPaginationAsync(int page = 1, int take = 1000)
        {
            var response = await _tvSerieService.GetAllWithPaginationAsync(page, take);
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
