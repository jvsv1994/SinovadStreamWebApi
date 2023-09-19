using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Episode;
using SinovadDemo.Application.DTO.Season;
using SinovadDemo.Application.DTO.TvSerie;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/mediadb")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class MediaDataBaseController:ControllerBase
    {

        private readonly ITvSerieService _tvSerieService;

        private readonly ISeasonService _seasonService;

        private readonly IEpisodeService _episodeService;

        public MediaDataBaseController(ITvSerieService tvSerieService, ISeasonService seasonService, IEpisodeService episodeService)
        {
            _tvSerieService = tvSerieService;
            _seasonService = seasonService;
            _episodeService = episodeService;
        }

        [HttpGet("SearchTvSerieAsync")]
        public async Task<ActionResult<Response<TvSerieWithGenresDto>>> SearchTvSerieAsync([FromQuery] string query)
        {
            var response = await _tvSerieService.SearchAsync(query);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("SearchSeasonAsync")]
        public async Task<ActionResult<Response<SeasonDto>>> SearchSeasonAsync([FromQuery] int tvSerieId, [FromQuery] int seasonNumber)
        {
            var exists = await _tvSerieService.CheckExistAsync(tvSerieId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await _seasonService.GetTvSeasonAsync(tvSerieId, seasonNumber);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("SearchEpisodeAsync")]
        public async Task<ActionResult<Response<EpisodeDto>>> SearchEpisodeAsync([FromQuery] int tvSerieId, [FromQuery] int seasonNumber, [FromQuery] int episodeNumber)
        {
            var exists = await _tvSerieService.CheckExistAsync(tvSerieId);
            if (!exists)
            {
                return NotFound("Serie de Tv no encontrada");
            }
            var response = await _episodeService.GetTvEpisodeAsync(tvSerieId, seasonNumber, episodeNumber);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


    }
}
