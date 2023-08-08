#nullable disable


using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Application.DTO
{
    public class StorageDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int MediaServerId { get; set; }
        public string PhysicalPath { get; set; }
        public int MediaTypeCatalogId { get; set; }
        public int MediaTypeCatalogDetailId { get; set; }
        public string Name { get; set; }
        public List<string> ListPaths { get; set; }

    }
}
