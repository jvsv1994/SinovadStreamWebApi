using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.CatalogDetail;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/catalogs/{catalogId:int}/details")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = false)]
    public class CatalogDetailsController:ControllerBase
    {
        private readonly ICatalogDetailService _catalogDetailService;

        public CatalogDetailsController(ICatalogDetailService catalogDetailService)
        {
            _catalogDetailService = catalogDetailService;
        }

        [HttpGet("GetAsync/{catalogDetailId:int}", Name = "getCatalogDetail")]
        public async Task<ActionResult<Response<CatalogDetailDto>>> GetAllWithPaginationAsync([FromRoute] int catalogId, [FromRoute]int catalogDetailId)
        {
            var response = await _catalogDetailService.GetAsync(catalogId, catalogDetailId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }


        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<CatalogDetailDto>>>> GetAllWithPaginationAsync([FromRoute] int catalogId, [FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _catalogDetailService.GetAllWithPaginationAsync(catalogId,page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromRoute] int catalogId, [FromBody] CatalogDetailCreationDto catalogDetailCreationDto)
        {
            var response = await _catalogDetailService.CreateAsync(catalogId,catalogDetailCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getCatalogDetail", new { catalogId =response.Data.CatalogId,catalogDetailId = response.Data.Id }, response.Data);
        }

        [HttpPut("UpdateAsync/{catalogDetailId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int catalogId, [FromRoute] int catalogDetailId, [FromBody] CatalogDetailCreationDto catalogDetailCreationDto)
        {
            var exists = await _catalogDetailService.CheckIfExistsAsync(catalogId, catalogDetailId);
            if (!exists)
            {
                return NotFound("Detalle de Catálogo no encontrado");
            }
            var response = await _catalogDetailService.UpdateAsync(catalogId, catalogDetailId, catalogDetailCreationDto);
            if (!response.IsSuccess)
            {
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{catalogDetailId:int}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int catalogId,[FromRoute] int catalogDetailId)
        {
            var response = await _catalogDetailService.DeleteAsync(catalogId, catalogDetailId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync([FromRoute] int catalogId, [FromRoute] string listIds)
        {
            var response = await _catalogDetailService.DeleteListAsync(catalogId,listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

    }
}
