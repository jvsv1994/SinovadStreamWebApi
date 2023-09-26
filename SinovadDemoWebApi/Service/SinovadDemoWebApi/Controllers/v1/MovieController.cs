using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Movie;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1

{
    [Route("api/v{version:apiVersion}/movies")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = "IsMediaAdmin")]
    [ApiVersion("1.0", Deprecated = false)]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAsync/{id}",Name ="getMovie")]
        public async Task<ActionResult<Response<MovieWithGenresDto>>> GetAsync(int id)
        {
            var response = await _movieService.GetAsync(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<Response<List<MovieDto>>>> GetAllAsync()
        {
            var response = await _movieService.GetAllAsync();
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<MovieDto>>>> GetAllWithPaginationAsync([FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _movieService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromBody] MovieCreationDto movieDto)
        {
            var response = await _movieService.CreateAsync(movieDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getMovie", new {id=response.Data.Id},response.Data);
        }

        [HttpPut("UpdateAsync/{movieId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int movieId, [FromBody] MovieCreationDto movieCreationDto)
        {
            var exists = await _movieService.CheckExistAsync(movieId);
            if (!exists)
            {
                return NotFound("Id de Película no existe");
            }
            var response = await _movieService.UpdateAsync(movieId,movieCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{movieId:int}")]
        public async Task<ActionResult> DeleteAsync(int movieId)
        {
            var exists = await _movieService.CheckExistAsync(movieId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _movieService.DeleteAsync(movieId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync(string listIds)
        {
            var response = await _movieService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

    }

}
