using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class TvSerieGenre : BaseAuditableEntity
{
    public int TvSerieId { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual TvSerie TvSerie { get; set; } = null!;
}
