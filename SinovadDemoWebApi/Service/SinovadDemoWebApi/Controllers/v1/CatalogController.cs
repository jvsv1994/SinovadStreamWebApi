using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Catalog;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;
using System.ComponentModel.DataAnnotations;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/catalogs")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = false)]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("GetAsync/{catalogId:int}",Name ="getCatalog")]
        public async Task<ActionResult<Response<CatalogDto>>> GetAllWithPaginationAsync([FromRoute] int catalogId)
        {
            var response = await _catalogService.GetAsync(catalogId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }


        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<CatalogDto>>>> GetAllWithPaginationAsync([FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _catalogService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromBody] CatalogCreationDto catalogCreationDto)
        {
            var response = await _catalogService.CreateAsync(catalogCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getCatalog", new { catalogId = response.Data.Id }, response.Data);
        }

        [HttpPut("UpdateAsync/{catalogId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute]int catalogId, [FromBody] CatalogCreationDto seasonDto)
        {
            var exists = await _catalogService.CheckIfExistsAsync(catalogId);
            if(!exists)
            {
                return NotFound("Catálogo no encontrado");
            }
            var response = await _catalogService.UpdateAsync(catalogId, seasonDto);
            if (!response.IsSuccess)
            {
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{catalogId}")]
        public async Task<ActionResult> DeleteAsync(int catalogId)
        {
            var response = await _catalogService.DeleteAsync(catalogId);
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync(string listIds)
        {
            var response = await _catalogService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpGet("GetAllCatalogDetailsByCatalogIds")]
        public async Task<ActionResult<Response<List<CatalogDetailDto>>>> GetAllCatalogDetailsByCatalogIds([Required] string catalogIds)
        {
            var response = await _catalogService.GetAllCatalogDetailsByCatalogIds(catalogIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetCatalogDetailAsync/{catalogId}/{catalogDetailId}")]
        public async Task<ActionResult<Response<CatalogDetailDto>>> GetCatalogDetailAsync(int catalogId, int catalogDetailId)
        {
            var response = await _catalogService.GetCatalogDetailAsync(catalogId, catalogDetailId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetDetailsByCatalogAsync/{catalogId}")]
        public async Task<ActionResult<Response<List<CatalogDetailDto>>>> GetDetailsByCatalogAsync(int catalogId)
        {
            var response = await _catalogService.GetDetailsByCatalogAsync(catalogId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllCatalogDetailsWithPaginationByCatalogIdsAsync")]
        public async Task<ActionResult<ResponsePagination<List<CatalogDetailDto>>>> GetAllCatalogDetailsWithPaginationByCatalogIdsAsync([Required] string catalogIds, int page = 1, int take = 1000)
        {
            var response = await _catalogService.GetAllCatalogDetailsWithPaginationByCatalogIdsAsync(catalogIds, page, take);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

    }
}
