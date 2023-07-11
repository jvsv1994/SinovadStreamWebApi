using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/genres")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("GetAsync/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var response = await _genreService.GetAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult> GetAllAsync()
        {
            var response = await _genreService.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult> GetAllWithPaginationAsync(int page = 1, int take = 1000)
        {
            var response = await _genreService.GetAllWithPaginationAsync(page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPost("Create")]
        public ActionResult Create([FromBody] GenreDto genreDto)
        {
            var response = _genreService.Create(genreDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] GenreDto genreDto)
        {
            var response = _genreService.Update(genreDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{genreId}")]
        public ActionResult Delete(int genreId)
        {
            var response = _genreService.Delete(genreId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _genreService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPost("CheckAndRegisterGenres")]
        public ActionResult CheckAndRegisterGenres()
        {
            var response = _genreService.CheckAndRegisterGenres();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
