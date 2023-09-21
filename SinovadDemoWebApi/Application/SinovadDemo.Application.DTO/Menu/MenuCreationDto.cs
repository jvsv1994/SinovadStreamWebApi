using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.Menu
{
    public class MenuCreationDto
    {
        [Required(ErrorMessage ="El campo título es obligatorio")]
        public string Title { get; set; }
        public string Path { get; set; }
        public int SortOrder { get; set; }
        public string IconUrl { get; set; }
        public string IconClass { get; set; }
        public int? IconTypeCatalogId { get; set; }
        public int? IconTypeCatalogDetailId { get; set; }
        public int ParentId { get; set; }
        public bool Enabled { get; set; }
    }
}
