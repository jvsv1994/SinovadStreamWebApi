using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class Storage : BaseEntity
{
    public int MediaServerId { get; set; }
    public string PhysicalPath { get; set; }
    public int MediaTypeCatalogId { get; set; }
    public int MediaTypeCatalogDetailId { get; set; }

    public virtual MediaServer MediaServer { get; set; } = null!;
}
