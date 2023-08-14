namespace SinovadDemo.Domain.Entities;

public class MediaServer: BaseEntity
{
    public string IpAddress { get; set; }
    public string PublicIpAddress { get; set; }
    public string SecurityIdentifier { get; set; }
    public int? UserId { get; set; }
    public int StateCatalogId { get; set; }
    public int StateCatalogDetailId { get; set; }
    public string? FamilyName { get; set; }
    public string DeviceName { get; set; }
    public int Port { get; set; }
    public string Url { get; set; }
    public virtual User? User { get; set; } = null!;

}
