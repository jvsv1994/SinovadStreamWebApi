using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/accountStorages")]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class AccountStorageController : Controller
    {
        private readonly IAccountStorageService _accountStorageService;

        public AccountStorageController(IAccountStorageService accountStorageService)
        {
            _accountStorageService = accountStorageService;
        }

        [HttpGet("GetAllWithPaginationByAccountServerAsync/{accountServerId}")]
        public async Task<ActionResult> GetAllWithPaginationByAccountServerAsync(int accountServerId, [FromQuery] int page = 1,[FromQuery] int take = 1000)
        {
            var response = await _accountStorageService.GetAllWithPaginationByAccountServerAsync(accountServerId, page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] AccountStorageDto accountStorageDto)
        {
            var response = _accountStorageService.Create(accountStorageDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<AccountStorageDto> list)
        {
            var response = _accountStorageService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] AccountStorageDto seasonDto)
        {
            var response = _accountStorageService.Update(seasonDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{accountStorageId}")]
        public ActionResult Delete(int accountStorageId)
        {
            var response = _accountStorageService.Delete(accountStorageId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _accountStorageService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
