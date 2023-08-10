using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/episodes")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }


        [HttpGet("GetAsync/{episodeId}")]
        public async Task<ActionResult> GetAll(int episodeId)
        {
            var response = await _episodeService.GetAsync(episodeId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpGet("GetAllAsync")]
        public async Task<ActionResult> GetAllAsync()
        {
            var response = await _episodeService.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationBySeasonAsync/{seasonId}")]
        public async Task<ActionResult> GetAllWithPaginationBySeasonAsync(int seasonId, [FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "EpisodeNumber", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _episodeService.GetAllWithPaginationBySeasonAsync(seasonId, page, take, sortBy, sortDirection, searchText, searchBy);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] EpisodeDto dto)
        {
            var response = _episodeService.Create(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("CreateList")]
        public ActionResult CreateList([FromBody] List<EpisodeDto> list)
        {
            var response = _episodeService.CreateList(list);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] EpisodeDto dto)
        {
            var response = _episodeService.Update(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{episodeId}")]
        public ActionResult Delete(int episodeId)
        {
            var response = _episodeService.Delete(episodeId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteList/{listIds}")]
        public ActionResult DeleteList(string listIds)
        {
            var response = _episodeService.DeleteList(listIds);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        //[HttpPost("ChangeSeasonInEpisodeList")]
        //public async Task<ActionResult<Episode>> ChangeSeasonInEpisodeList([FromBody] RequestData request)
        //{
        //    if (request == null)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (request.ListItemsIds != null && request.ListItemsIds.Length > 0)
        //    {
        //        var listEpisodes = (from d in _unitOfWork.Episodes.GetAsync().Result where request.ListItemsIds.Contains(d.Id) select d);
        //        foreach (var episode in listEpisodes)
        //        {
        //            episode.SeasonId = request.SeasonID;
        //        }
        //        await _unitOfWork.SaveAsync();
        //    }
        //    return Ok();
        //}
    }
}
