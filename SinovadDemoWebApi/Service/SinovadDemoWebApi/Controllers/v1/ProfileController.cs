﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.UseCases.MediaServers;
using System.ComponentModel.DataAnnotations;

namespace SinovadDemoWebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/profiles")]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("GetAsync/{profileId}")]
        public async Task<ActionResult> GetAsync(int profileId)
        {
            var response = await _profileService.GetAsync(profileId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetByGuidAsync/{guid}")]
        public async Task<ActionResult> GetByGuidAsync([Required] string guid)
        {
            var response = await _profileService.GetByGuidAsync(guid);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message); ;
        }

        [HttpGet("GetAllWithPaginationByUserAsync/{userId}")]
        public async Task<ActionResult> GetAll(int userId,[FromQuery] int page = 1,[FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _profileService.GetAllWithPaginationByUserAsync(userId, page, take, sortBy, sortDirection, searchText, searchBy);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] ProfileDto dto)
        {
            var response = _profileService.Create(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<ProfileDto> list)
        {
            var response = _profileService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] ProfileDto dto)
        {
            var response = _profileService.Update(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{profileId}")]
        public ActionResult Delete(int profileId)
        {
            var response = _profileService.Delete(profileId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _profileService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
