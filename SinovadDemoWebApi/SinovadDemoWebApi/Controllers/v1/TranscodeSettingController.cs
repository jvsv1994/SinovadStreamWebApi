using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/transcodeSettings")]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class TranscodeSettingController : Controller
    {
        private readonly ITranscodeSettingService _transcodeSettingService;

        public TranscodeSettingController(ITranscodeSettingService transcodeSettingService)
        {
            _transcodeSettingService = transcodeSettingService;
        }

        [HttpGet("GetByAccountServerAsync/{accountServerId}")]
        public async Task<ActionResult> GetByAccountServerAsync(int accountServerId)
        {
            var response = await _transcodeSettingService.GetByAccountServerAsync(accountServerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationByAccountServerAsync/{accountServerId}")]
        public async Task<ActionResult> GetAllWithPaginationByAccountServerAsync(int accountServerId,[FromQuery] int page = 1,[FromQuery] int take = 1000)
        {
            var response = await _transcodeSettingService.GetAllWithPaginationByAccountServerAsync(accountServerId, page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] TranscodeSettingDto seasonDto)
        {
            var response = _transcodeSettingService.Create(seasonDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<TranscodeSettingDto> list)
        {
            var response = _transcodeSettingService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] TranscodeSettingDto seasonDto)
        {
            var response = _transcodeSettingService.Update(seasonDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{transcodeSettingId}")]
        public ActionResult Delete(int transcodeSettingId)
        {
            var response = _transcodeSettingService.Delete(transcodeSettingId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _transcodeSettingService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
