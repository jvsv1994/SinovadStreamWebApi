using SinovadDemo.Application.DTO.CatalogDetail;

namespace SinovadDemo.Application.DTO.Catalog
{
    public class CatalogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CatalogDetailDto> ListCatalogDetail { get; set; }
    }
}
