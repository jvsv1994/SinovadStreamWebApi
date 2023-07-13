using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class Catalog: BaseEntity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<CatalogDetail> CatalogDetails { get; set; } = new List<CatalogDetail>();
}
