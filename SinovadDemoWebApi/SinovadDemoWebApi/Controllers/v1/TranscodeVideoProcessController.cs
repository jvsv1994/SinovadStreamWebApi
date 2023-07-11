using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/transcodeVideoProcesses")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class TranscodeVideoProcessController : ControllerBase
    {
        private readonly ITranscodeVideoProcessService _transcodeVideoProcessService;

        public TranscodeVideoProcessController(ITranscodeVideoProcessService transcodeVideoProcessService)
        {
            _transcodeVideoProcessService = transcodeVideoProcessService;
        }

        [HttpGet("GetAsync/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var response = await _transcodeVideoProcessService.GetAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllByAccountServerAsync/{accountServerId}")]
        public async Task<ActionResult> GetAllByAccountServerAsync(int accountServerId)
        {
            var response = await _transcodeVideoProcessService.GetAllByAccountServerAsync(accountServerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllByListGuidsAsync/{guids}")]
        public async Task<ActionResult> GetAllByListGuidsAsync(string guids)
        {
            var response = await _transcodeVideoProcessService.GetAllByListGuidsAsync(guids);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] TranscodeVideoProcessDto transcodeVideoProcessDto)
        {
            var response = _transcodeVideoProcessService.Create(transcodeVideoProcessDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<TranscodeVideoProcessDto> list)
        {
            var response = _transcodeVideoProcessService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] TranscodeVideoProcessDto transcodeVideoProcessDto)
        {
            var response = _transcodeVideoProcessService.Update(transcodeVideoProcessDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{transcodeVideoProcessId}")]
        public ActionResult Delete(int transcodeVideoProcessId)
        {
            var response = _transcodeVideoProcessService.Delete(transcodeVideoProcessId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _transcodeVideoProcessService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteByListGuids/{guids}")]
        public ActionResult DeleteByListGuids(string guids)
        {
            var response = _transcodeVideoProcessService.DeleteByListGuids(guids);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
