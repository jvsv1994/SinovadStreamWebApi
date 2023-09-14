using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1

{
    [Route("api/v{version:apiVersion}/movies")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAsync/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var response = await _movieService.GetAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult> GetAllAsync()
        {
            var response = await _movieService.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult> GetAllWithPaginationAsync([FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _movieService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] MovieDto movieDto)
        {
            var response = await _movieService.Create(movieDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] MovieDto movieDto)
        {
            var response = await _movieService.Update(movieDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{movieId}")]
        public async Task<ActionResult> Delete(int movieId)
        {
            var response = await _movieService.Delete(movieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public async Task<ActionResult> DeleteList(string listIds)
        {
            var response = await _movieService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }

}
