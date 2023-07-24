using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/transcoderSettings")]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class TranscoderSettingsController : Controller
    {
        private readonly ITranscoderSettingsService _transcoderSettingsService;

        public TranscoderSettingsController(ITranscoderSettingsService transcoderSettingsService)
        {
            _transcoderSettingsService = transcoderSettingsService;
        }

        [HttpGet("GetByMediaServerAsync/{mediaServerId}")]
        public async Task<ActionResult> GetByMediaServerAsync(int mediaServerId)
        {
            var response = await _transcoderSettingsService.GetByMediaServerAsync(mediaServerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetByMediaServerGuidAsync/{mediaServerGuid}")]
        public async Task<ActionResult> GetByMediaServerGuidAsync(string mediaServerGuid)
        {
            var response = await _transcoderSettingsService.GetByMediaServerGuidAsync(mediaServerGuid);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationByMediaServerAsync/{mediaServerId}")]
        public async Task<ActionResult> GetAllWithPaginationByMediaServerAsync(int mediaServerId,[FromQuery] int page = 1,[FromQuery] int take = 1000)
        {
            var response = await _transcoderSettingsService.GetAllWithPaginationByMediaServerAsync(mediaServerId, page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] TranscoderSettingsDto transcoderSettingsDto)
        {
            var response = _transcoderSettingsService.Create(transcoderSettingsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<TranscoderSettingsDto> list)
        {
            var response = _transcoderSettingsService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] TranscoderSettingsDto transcoderSettingsDto)
        {
            var response = _transcoderSettingsService.Update(transcoderSettingsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Save")]
        public async Task<ActionResult> Save([FromBody] TranscoderSettingsDto transcoderSettingsDto)
        {
            if (transcoderSettingsDto == null)
            {
                return BadRequest();
            }
            var response = await _transcoderSettingsService.Save(transcoderSettingsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{transcoderSettingsId}")]
        public ActionResult Delete(int transcoderSettingsId)
        {
            var response = _transcoderSettingsService.Delete(transcoderSettingsId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _transcoderSettingsService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
