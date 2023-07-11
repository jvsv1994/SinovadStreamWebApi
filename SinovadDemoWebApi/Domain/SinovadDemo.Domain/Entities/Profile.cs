using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class Profile : BaseAuditableEntity
{
    public int Id { get; set; }

    public string AccountId { get; set; }

    public string FullName { get; set; }

    public bool Main { get; set; }

    public int? Pincode { get; set; }

    public string? AvatarPath { get; set; }

    public virtual AppUser Account { get; set; } = null!;

    public virtual ICollection<VideoProfile> VideoProfiles { get; set; } = new List<VideoProfile>();
}
