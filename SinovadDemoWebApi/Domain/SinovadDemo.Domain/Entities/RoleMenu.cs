using Generic.Core.Models;
using SinovadDemo.Domain.Common;
using SinovadDemo.Domain.Entities;

public class RoleMenu: BaseAuditableEntity
{
    public int RoleId { get; set; }
    public int MenuId { get; set; }
    public virtual Role Role { get; set; }
    public virtual Menu Menu { get; set; }
}