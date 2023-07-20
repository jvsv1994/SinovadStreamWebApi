namespace SinovadDemo.Domain.Entities;

public class MediaServer: BaseEntity
{
    public string IpAddress { get; set; }
    public int UserId { get; set; }
    public int StateCatalogId { get; set; }
    public int StateCatalogDetailId { get; set; }
    public string? Name { get; set; }
    public int? Port { get; set; }
    public string Url { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();
    public virtual TranscoderSettings? TranscoderSettings { get; set; }

}
