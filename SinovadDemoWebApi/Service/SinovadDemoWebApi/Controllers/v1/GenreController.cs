using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Genre;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/genres")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsMediaAdmin")]
    [ApiVersion("1.0", Deprecated = false)]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("GetAsync/{id}",Name ="getGenre")]
        public async Task<ActionResult<Response<GenreDto>>> GetAsync(int id)
        {
            var response = await _genreService.GetAsync(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<Response<List<GenreDto>>>> GetAllAsync()
        {
            var response = await _genreService.GetAllAsync();
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<GenreDto>>>> GetAllWithPaginationAsync([FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _genreService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }


        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromBody] GenreCreationDto genreCreationDto)
        {
            var response = await _genreService.CreateAsync(genreCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getGenre", new { id = response.Data.Id }, response.Data);
        }

        [HttpPut("UpdateAsync/{genreId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int genreId,[FromBody] GenreCreationDto genreCreationDto)
        {
            var exists=await _genreService.CheckExistAsync(genreId);
            if(!exists)
            {
                return NotFound("Género no encontrado");
            }
            var response = await _genreService.UpdateAsync(genreId, genreCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteASync/{genreId}")]
        public async Task<ActionResult> DeleteAsync(int genreId)
        {
            var response = await _genreService.DeleteAsync(genreId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent() ;
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync(string listIds)
        {
            var response = await _genreService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

    }
}
