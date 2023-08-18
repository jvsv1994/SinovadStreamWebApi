using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Application.DTO
{
    public class LinkedAccountDto
    {
        public string AccessToken { get; set; }
        public int LinkedAccountProviderCatalogId { get; set; }
        public LinkedAccountProvider LinkedAccountProviderCatalogDetailId { get; set; }
        public int UserId { get; set; }

    }
}
