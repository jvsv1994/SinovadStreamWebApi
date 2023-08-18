using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Application.DTO
{
    public class LinkedAccountDto
    {
        public string AccessToken { get; set; }
        public int LinkedAccountTypeCatalogId { get; set; }
        public LinkedAccountType LinkedAccountTypeCatalogDetailId { get; set; }
        public int UserId { get; set; }

    }
}
