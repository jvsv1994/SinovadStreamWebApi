using SinovadDemo.Domain.Entities;

namespace Generic.Core.Models
{
    public class Menu : BaseEntity
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public int IconTypeCatalogId { get; set; }
        public int IconTypeCatalogDetailId { get; set; }
        public int ParentId { get; set; }   
        public int Status { get; set; }    
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }       
        
    }
}