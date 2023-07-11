using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class Season : BaseAuditableEntity
{
    public int Id { get; set; }

    public int? SeasonNumber { get; set; }

    public string? Name { get; set; }

    public string? Summary { get; set; }

    public int TvSerieId { get; set; }

    public virtual ICollection<Episode> Episodes { get; set; } = new List<Episode>();

    public virtual TvSerie TvSerie { get; set; } = null!;
}
