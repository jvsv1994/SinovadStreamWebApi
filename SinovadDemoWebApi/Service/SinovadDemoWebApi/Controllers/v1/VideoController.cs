﻿using Microsoft.AspNetCore.Authorization;
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
        public ActionResult Get([Required]int userId,[Required] int profileId,[Required] bool searchMovies,[Required] bool searchTvSeries)
        {
            var response = _videoService.GetVideosOrganized(userId, profileId, searchMovies, searchTvSeries);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("SearchTvPrograms")]
        public ActionResult Search([Required] int userId, [Required] bool searchMovies, [Required] bool searchTvSeries, [Required] string searchText)
        {
            var response = _videoService.GetVideosByFilters(userId, searchMovies, searchTvSeries, searchText);
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

        [HttpGet("GetMovieDataByUser")]
        public async Task<ActionResult> GetMovieDataByUser([Required] int userId,[Required] int movieId)
        {
            var response = await _videoService.GetMovieDataByUser(userId, movieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetTvSerieDetail")]
        public async Task<ActionResult> GetTvSerieDetail([Required] int userId,[Required] int tvSerieId)
        {
            var response = await _videoService.GetTvSerieDetail(userId, tvSerieId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetTvSerieDataByUser")]
        public async Task<ActionResult> GetTvSerieDataByUser([Required] int userId, [Required] int tvSerieId)
        {
            var response = await _videoService.GetTvSerieDataByUser(userId, tvSerieId);
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
