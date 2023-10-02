using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

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

        [HttpGet("GetAsync/{mediaServerId:int}",Name = "getMediaServer")]
        public async Task<ActionResult<Response<MediaServerDto>>> GetAsync([FromRoute] int mediaServerId)
        {
            var response = await _mediaServerService.GetAsync(mediaServerId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message); ;
            }
            return response;
        }

        [HttpGet("GetBySecurityIdentifierAsync/{sid}")]
        public async Task<ActionResult<Response<MediaServerDto>>> GetBySecurityIdentifierAsync([FromRoute] string sid)
        {
            var response = await _mediaServerService.GetBySecurityIdentifierAsync(sid);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetByGuidAsync/{guid}")]
        public async Task<ActionResult<Response<MediaServerDto>>> GetByGuidAsync([FromRoute] string guid)
        {
            var response = await _mediaServerService.GetByGuidAsync(guid);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message); ;
            }
            return response;
        }

        [HttpGet("GetByUserAndIpAddressAsync")]
        public async Task<ActionResult<Response<MediaServerDto>>> GetByUserAndIpAddressAsync([FromQuery] int userId, [FromQuery] string ipAddress)
        {
            var response = await _mediaServerService.GetByUserAndIpAddressAsync(userId, ipAddress);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message); ;
            }
            return response;
        }

        [HttpGet("GetAllByUserAsync/{userId:int}")]
        public async Task<ActionResult<Response<List<MediaServerDto>>>> GetAllByUserAsync([FromRoute] int userId)
        {
            var response = await _mediaServerService.GetAllByUserAsync(userId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message); ;
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationByUserAsync/{userId:int}")]
        public async Task<ActionResult<ResponsePagination<List<MediaServerDto>>>> GetAllWithPaginationByUserAsync([FromRoute]int userId,[FromQuery] int page = 1,[FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _mediaServerService.GetAllWithPaginationByUserAsync(userId, page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message); ;
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult<Response<MediaServerDto>>> CreateAsync([FromBody] MediaServerCreationDto mediaServerDto)
        {
            var response = await _mediaServerService.CreateAsync(mediaServerDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getMediaServer",new {mediaServerId=response.Data.Id},response);
        }

        [HttpPut("UpdateAsync/{mediaServerId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute]int mediaServerId,[FromBody] MediaServerCreationDto mediaServerDto)
        {
            var exists = await _mediaServerService.CheckIfExistsAsync(mediaServerId);
            if(!exists)
            {
                return NotFound("Servidor no encontrado");
            }
            var response = await _mediaServerService.UpdateAsync(mediaServerId,mediaServerDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{mediaServerId:int}")]
        public async Task<ActionResult> DeleteAsync(int mediaServerId)
        {
            var response = await _mediaServerService.DeleteAsync(mediaServerId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent() ;
        }

    }
}
