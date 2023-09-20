using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using System.ComponentModel.DataAnnotations;

namespace SinovadDemoWebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/mediaServers")]
    [Authorize]
    [ApiVersion("1.0", Deprecated = false)]
    public class MediaServerController : Controller
    {
        private readonly IMediaServerService _mediaServerService;

        public MediaServerController(IMediaServerService mediaServerService)
        {
            _mediaServerService = mediaServerService;
        }

        [HttpGet("GetBySecurityIdentifierAsync/{sid}")]
        public async Task<ActionResult> GetBySecurityIdentifierAsync([Required] string sid)
        {
            var response = await _mediaServerService.GetBySecurityIdentifierAsync(sid);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message); ;
        }

        [HttpGet("GetByGuidAsync/{guid}")]
        public async Task<ActionResult> GetByGuidAsync([Required] string guid)
        {
            var response = await _mediaServerService.GetByGuidAsync(guid);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message); ;
        }

        [HttpGet("GetByUserAndIpAddressAsync")]
        public async Task<ActionResult> Get([Required] int userId, [Required] string ipAddress)
        {
            var response = await _mediaServerService.GetByUserAndIpAddressAsync(userId, ipAddress);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message); ;
        }

        [HttpGet("GetAllByUserAsync/{userId}")]
        public async Task<ActionResult> GetAllByUserAsync(int userId)
        {
            var response = await _mediaServerService.GetAllByUserAsync(userId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message); ;
        }

        [HttpGet("GetAllWithPaginationByUserAsync/{userId}")]
        public async Task<ActionResult> GetAllWithPaginationByUserAsync([FromRoute]int userId,[FromQuery] int page = 1,[FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _mediaServerService.GetAllWithPaginationByUserAsync(userId, page, take, sortBy, sortDirection, searchText, searchBy);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message); ;
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] MediaServerDto mediaServerDto)
        {
            if (mediaServerDto == null)
            {
                return BadRequest();
            }
            var response = _mediaServerService.Create(mediaServerDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<MediaServerDto> list)
        {
            if (list == null)
            {
                return BadRequest();
            }
            var response = _mediaServerService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] MediaServerDto mediaServerDto)
        {
            if (mediaServerDto == null)
            {
                return BadRequest();
            }
            var response = _mediaServerService.Update(mediaServerDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Save")]
        public async Task<ActionResult> Save([FromBody] MediaServerDto mediaServerDto)
        {
            if (mediaServerDto == null)
            {
                return BadRequest();
            }
            var response = await _mediaServerService.Save(mediaServerDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{mediaServerId}")]
        public ActionResult Delete(int mediaServerId)
        {
            if (mediaServerId == 0)
            {
                return BadRequest();
            }
            var response = _mediaServerService.Delete(mediaServerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            if (string.IsNullOrEmpty(listIds))
            {
                return BadRequest();
            }
            var response = _mediaServerService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
