using Generic.Core.Models;
using SinovadDemo.Domain.Common;

public class RoleMenu: BaseAuditableEntity
{
    public int RoleId { get; set; }
    public int MenuId { get; set; }
    public bool Enabled { get; set; }
    public bool AllowRead { get; set; }
    public bool AllowCreate { get; set; }
    public bool AllowUpdate { get; set; }
    public bool AllowDelete { get; set; }
    public virtual Role Role { get; set; }
    public virtual Menu Menu { get; set; }
}