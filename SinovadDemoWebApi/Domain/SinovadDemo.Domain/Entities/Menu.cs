using SinovadDemo.Domain.Entities;

namespace Generic.Core.Models
{
    public class Menu : BaseEntity
    {
        public string? Path { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string? IconUrl { get; set; }
        public string? IconClass { get; set; }
        public int? IconTypeCatalogId { get; set; }
        public int? IconTypeCatalogDetailId { get; set; }
        public int ParentId { get; set; }   
        public bool Enabled { get; set; }    
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }       
        
    }
}