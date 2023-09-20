using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/documents")]
    [Authorize]
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        //[HttpPost("Upload")]
        //[AllowAnonymous]
        //public IActionResult Upload([FromForm] DocumentDto document)
        //{
        //    var filePath = Path.Combine(document.LibraryPhysicalPath, document.File.FileName);
        //    var response = new Response<object>();
        //    try
        //    {
        //        using (FileStream newFile = System.IO.File.Create(filePath))
        //        {
        //            document.File.CopyTo(newFile);
        //            newFile.Flush();
        //        }
        //        response.IsSuccess = true;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }catch (Exception ex)
        //    {
        //        response.Message = ex.StackTrace;
        //        return BadRequest(response);
        //    }
        //}

        [HttpPost("UploadAvatarProfile")]
        public IActionResult Upload([FromForm] DocumentDto document)
        {
            var response = new Response<object>();
            try
            {
                _documentService.UploadAvatarProfile(document);
                response.IsSuccess = true;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                return BadRequest(response);
            }
        }


        [HttpGet("GetAvatarProfile/{profileId}")]
        [AllowAnonymous]
        public  IActionResult GetAvatarProfile([FromRoute] int profileId)
        {
            var stream =  _documentService.GetAvatarProfile(profileId);
            return File(stream, "image/jpeg");
        }

    }
}
