#nullable disable

namespace SinovadDemo.Application.DTO
{
    public partial class MenuDto
    {
        public int Id { get; set; }
        public string? Path { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string? IconUrl { get; set; }
        public string? IconClass { get; set; }
        public int? IconTypeCatalogId { get; set; }
        public int? IconTypeCatalogDetailId { get; set; }
        public int ParentId { get; set; }
        public bool Enabled { get; set; }
        public List<MenuDto> ChildMenus { get; set; }

    }
}
