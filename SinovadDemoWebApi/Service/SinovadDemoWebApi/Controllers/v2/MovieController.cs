using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using SinovadDemo.Application.DTO.Movie;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v2

{
    [Route("api/v{version:apiVersion}/movies")]
    [ApiController]
    [EnableRateLimiting("fixedWindow")]
    [Authorize]
    [ApiVersion("2.0")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPut("Update/{movieId}")]
        public async Task<ActionResult> Update(int movieId,[FromBody] MovieCreationDto movieDto)
        {
            var exists = await _movieService.CheckExistAsync(movieId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _movieService.UpdateAsync(movieId,movieDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
      
    }

}
