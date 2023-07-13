using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/storages")]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("GetAllWithPaginationByMediaServerAsync/{mediaServerId}")]
        public async Task<ActionResult> GetAllWithPaginationByMediaServerAsync(int mediaServerId, [FromQuery] int page = 1,[FromQuery] int take = 1000)
        {
            var response = await _storageService.GetAllWithPaginationByMediaServerAsync(mediaServerId, page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] StorageDto storageDto)
        {
            var response = _storageService.Create(storageDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<StorageDto> list)
        {
            var response = _storageService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] StorageDto seasonDto)
        {
            var response = _storageService.Update(seasonDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{storageId}")]
        public ActionResult Delete(int storageId)
        {
            var response = _storageService.Delete(storageId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _storageService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
