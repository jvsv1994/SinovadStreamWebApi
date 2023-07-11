using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using System.ComponentModel.DataAnnotations;

namespace SinovadDemoWebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/accountServers")]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class AccountServerController : Controller
    {
        private readonly IAccountServerService _accountServerService;

        public AccountServerController(IAccountServerService accountServerService)
        {
            _accountServerService = accountServerService;
        }

        [HttpGet("GetByAccountAndIpAddressAsync")]
        public async Task<ActionResult> Get([Required] string accountId, [Required] string ipAddress)
        {
            var response = await _accountServerService.GetByAccountAndIpAddressAsync(accountId, ipAddress);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message); ;
        }

        [HttpGet("GetAllWithPaginationByAccountAsync/{accountId}")]
        public async Task<ActionResult> GetAllWithPaginationByAccountAsync(string accountId,[FromQuery] int page = 1,[FromQuery] int take = 1000)
        {
            var response = await _accountServerService.GetAllWithPaginationByAccountAsync(accountId, page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message); ;
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] AccountServerDto accountServerDto)
        {
            if (accountServerDto == null)
            {
                return BadRequest();
            }
            var response = _accountServerService.Create(accountServerDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<AccountServerDto> list)
        {
            if (list == null)
            {
                return BadRequest();
            }
            var response = _accountServerService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] AccountServerDto accountServerDto)
        {
            if (accountServerDto == null)
            {
                return BadRequest();
            }
            var response = _accountServerService.Update(accountServerDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{accountServerId}")]
        public ActionResult Delete(int accountServerId)
        {
            if (accountServerId == 0)
            {
                return BadRequest();
            }
            var response = _accountServerService.Delete(accountServerId);
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
            var response = _accountServerService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
