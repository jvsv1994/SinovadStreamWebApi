using SinovadDemo.Application.DTO.Catalog;

namespace SinovadDemo.Application.DTO.CatalogDetail
{
    public class CatalogDetailDto
    {
        public int CatalogId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TextValue { get; set; }
        public int? NumberValue { get; set; }
        public CatalogDto Catalog { get; set; }
    }
}
