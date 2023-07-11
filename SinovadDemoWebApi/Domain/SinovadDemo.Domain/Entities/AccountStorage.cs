using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class AccountStorage : BaseAuditableEntity
{
    public int Id { get; set; }

    public int AccountServerId { get; set; }

    public string? PhisicalPath { get; set; }

    public int AccountStorageTypeId { get; set; }

    public virtual AccountServer AccountServer { get; set; } = null!;
}
