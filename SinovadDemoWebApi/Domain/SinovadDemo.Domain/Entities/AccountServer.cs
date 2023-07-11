using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class AccountServer: BaseAuditableEntity
{
    public int Id { get; set; }

    public string IpAddress { get; set; }

    public string AccountId { get; set; }

    public int StateCatalogId { get; set; }

    public int StateCatalogDetailId { get; set; }

    public string HostUrl { get; set; }

    public virtual AppUser Account { get; set; } = null!;

    public virtual ICollection<AccountStorage> AccountStorages { get; set; } = new List<AccountStorage>();

    public virtual ICollection<TranscodeSetting> TranscodeSettings { get; set; } = new List<TranscodeSetting>();
}
