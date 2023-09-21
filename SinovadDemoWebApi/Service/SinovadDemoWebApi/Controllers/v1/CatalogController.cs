using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Catalog;
using SinovadDemo.Application.DTO.CatalogDetail;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

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
        public async Task<ActionResult> UpdateAsync([FromRoute]int catalogId, [FromBody] CatalogCreationDto catalogCreationDto)
        {
            var exists = await _catalogService.CheckIfExistsAsync(catalogId);
            if(!exists)
            {
                return NotFound("Catálogo no encontrado");
            }
            var response = await _catalogService.UpdateAsync(catalogId, catalogCreationDto);
            if (!response.IsSuccess)
            {
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{catalogId:int}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int catalogId)
        {
            var response = await _catalogService.DeleteAsync(catalogId);
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync([FromRoute] string listIds)
        {
            var response = await _catalogService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpGet("GetAllCatalogDetailsByCatalogIds")]
        public async Task<ActionResult<Response<List<CatalogDetailDto>>>> GetAllCatalogDetailsByCatalogIds([FromQuery] string catalogIds)
        {
            var response = await _catalogService.GetAllCatalogDetailsByCatalogIds(catalogIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

    }
}
