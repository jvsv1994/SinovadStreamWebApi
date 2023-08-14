using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class Profile : BaseEntity
{
    public int UserId { get; set; }

    public string FullName { get; set; }

    public bool Main { get; set; }

    public int? Pincode { get; set; }

    public string? AvatarPath { get; set; }

    public virtual User User { get; set; } = null!;

}
