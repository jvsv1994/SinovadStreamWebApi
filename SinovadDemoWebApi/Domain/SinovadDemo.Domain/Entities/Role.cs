using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generic.Core.Models
{
    public class Role : IdentityRole<int>
    {
        public int Status { get; set; } = 1;
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
        [NotMapped]
        public virtual ICollection<Menu> Menus { get; set; }
        [NotMapped]
        public virtual ICollection<Menu> UnAssignedMenus { get; set; }

        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Deleted { get; set; }

    }
}