using Microsoft.AspNetCore.Http;

namespace SinovadDemo.Application.DTO
{
    public class DocumentDto
    {
        public int ProfileId { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile File { get; set; }

    }
}
