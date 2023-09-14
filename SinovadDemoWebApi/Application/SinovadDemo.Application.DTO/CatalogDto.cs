namespace SinovadDemo.Application.DTO
{
    public class CatalogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CatalogDetailDto> ListCatalogDetail { get; set; }
    }
}
