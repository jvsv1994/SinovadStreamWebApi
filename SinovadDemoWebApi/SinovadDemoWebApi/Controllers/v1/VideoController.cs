using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using System.ComponentModel.DataAnnotations;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/videos")]
    [Authorize]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet("GetAllTvProgramsOrganized")]
        public ActionResult Get([Required]string accountId,[Required] int profileId,[Required] bool searchMovies,[Required] bool searchTvSeries)
        {
            var response = _videoService.GetVideosOrganized(accountId, profileId, searchMovies, searchTvSeries);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("SearchTvPrograms")]
        public ActionResult Search([Required] string accountId, [Required] bool searchMovies, [Required] bool searchTvSeries, [Required] string searchText)
        {
            var response = _videoService.GetVideosByFilters(accountId, searchMovies, searchTvSeries, searchText);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetMovieDetail")]
        public async Task<ActionResult> GetMovieDetail([Required]int movieId)
        {
            var response = await _videoService.GetMovieDetail(movieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetMovieDataByAccount")]
        public async Task<ActionResult> GetMovieDataByAccount([Required] string accountId,[Required] int movieId)
        {
            var response = await _videoService.GetMovieDataByAccount(accountId, movieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetTvSerieDetail")]
        public async Task<ActionResult> GetTvSerieDetail([Required] string accountId,[Required] int tvSerieId)
        {
            var response = await _videoService.GetTvSerieDetail(accountId, tvSerieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetTvSerieDataByAccount")]
        public async Task<ActionResult> GetTvSerieDataByAccount([Required] string accountId, [Required] int tvSerieId)
        {
            var response = await _videoService.GetTvSerieDataByAccount(accountId, tvSerieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("UpdateVideoProfile")]
        public ActionResult UpdateVideoProfile([FromBody] VideoProfileDto videoProfileDto)
        {
            var response = _videoService.UpdateVideoProfile(videoProfileDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("UpdateVideosInListStorages")]
        public ActionResult UpdateVideosInListStorages([FromBody] UpdateStorageVideosDto videoRequest)
        {
            var response = _videoService.UpdateVideosInListStorages(videoRequest);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
