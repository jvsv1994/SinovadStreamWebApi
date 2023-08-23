using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using System.ComponentModel.DataAnnotations;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/catalogs")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult> GetAllAsync(int page = 1, int take = 1000)
        {
            var response = await _catalogService.GetAllWithPaginationAsync(page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] CatalogDto seasonDto)
        {
            var response = _catalogService.Create(seasonDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] CatalogDto seasonDto)
        {
            var response = _catalogService.Update(seasonDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{catalogId}")]
        public ActionResult Delete(int catalogId)
        {
            var response = _catalogService.Delete(catalogId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _catalogService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetCatalogDetailAsync/{catalogId}/{catalogDetailId}")]
        public async Task<ActionResult> GetCatalogDetailAsync(int catalogId,int catalogDetailId)
        {
            var response = await _catalogService.GetCatalogDetailAsync(catalogId, catalogDetailId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetDetailsByCatalogAsync/{catalogId}")]
        public async Task<ActionResult> GetDetailsByCatalogAsync(int catalogId)
        {
            var response = await _catalogService.GetDetailsByCatalogAsync(catalogId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllCatalogDetailsWithPaginationByCatalogIdsAsync")]
        public async Task<ActionResult> GetAllCatalogDetailsWithPaginationByCatalogIdsAsync([Required]string catalogIds, int page = 1, int take = 1000)
        {
            var response = await _catalogService.GetAllCatalogDetailsWithPaginationByCatalogIdsAsync(catalogIds, page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllCatalogDetailsByCatalogIds")]
        public async Task<ActionResult> GetAllCatalogDetailsByCatalogIds([Required] string catalogIds)
        {
            var response = await _catalogService.GetAllCatalogDetailsByCatalogIds(catalogIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
