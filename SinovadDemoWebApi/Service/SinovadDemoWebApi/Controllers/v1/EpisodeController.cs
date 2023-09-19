using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Episode;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/seasons/{seasonId:int}/episodes")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        private readonly ISeasonService _seasonService;

        public EpisodeController(IEpisodeService episodeService, ISeasonService seasonService)
        {
            _episodeService = episodeService;
            _seasonService = seasonService;
        }

        [HttpGet("GetAsync/{episodeId}", Name = "getEpisode")]
        public async Task<ActionResult<Response<EpisodeDto>>> GetAsync([FromRoute] int episodeId)
        {
            var response = await _episodeService.GetAsync(episodeId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }


        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<Response<List<EpisodeDto>>>> GetAllAsync()
        {
            var response = await _episodeService.GetAllAsync();
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<EpisodeDto>>>> GetAllWithPaginationAsync([FromRoute] int seasonId, [FromQuery] int page = 1, [FromQuery] int take = 1000,
            [FromQuery] string sortBy = "EpisodeNumber", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "",
            [FromQuery] string searchBy = "")
        {
            var response = await _episodeService.GetAllWithPaginationBySeasonAsync(seasonId, page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromRoute] int seasonId, [FromBody] EpisodeCreationDto episodeCreationDto)
        {
            var exists = await _seasonService.CheckExistAsync(seasonId);
            if (!exists)
            {
                return NotFound("Temporada no encontrada");
            }
            var response = await _episodeService.CreateAsync(seasonId, episodeCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getEpisode", new { seasonId = response.Data.SeasonId, episodeId = response.Data.Id }, response.Data);
        }

        [HttpPost("CreateListAsync")]
        public async Task<ActionResult> CreateListAsync([FromRoute]int seasonId,[FromBody] List<EpisodeCreationDto> list)
        {
            var exists = await _seasonService.CheckExistAsync(seasonId);
            if (!exists)
            {
                return NotFound("Temporada no encontrada");
            }
            var response = await _episodeService.CreateListAsync(seasonId,list);
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();   
        }

        [HttpPut("UpdateAsync/{episodeId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute]int episodeId,[FromBody] EpisodeCreationDto episodeCreationDto)
        {
            var exists = await _episodeService.CheckExistAsync(episodeId);
            if (!exists)
            {
                return NotFound("Episodio no encontrado");
            }
            var response = await _episodeService.UpdateAsync(episodeId, episodeCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{episodeId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int episodeId)
        {
            var response = await _episodeService.DeleteAsync(episodeId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync([FromRoute] string listIds)
        {
            var response =await _episodeService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        //[HttpPost("ChangeSeasonInEpisodeList")]
        //public async Task<ActionResult<Episode>> ChangeSeasonInEpisodeList([FromBody] RequestData request)
        //{
        //    if (request == null)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (request.ListItemsIds != null && request.ListItemsIds.Length > 0)
        //    {
        //        var listEpisodes = (from d in _unitOfWork.Episodes.GetAsync().Result where request.ListItemsIds.Contains(d.Id) select d);
        //        foreach (var episode in listEpisodes)
        //        {
        //            episode.SeasonId = request.SeasonID;
        //        }
        //        await _unitOfWork.SaveAsync();
        //    }
        //    return Ok();
        //}
    }
}
