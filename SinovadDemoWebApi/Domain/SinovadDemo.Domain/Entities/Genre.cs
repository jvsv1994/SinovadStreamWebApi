using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class Genre : BaseAuditableEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TmdbId { get; set; }

    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    public virtual ICollection<TvSerieGenre> TvSerieGenres { get; set; } = new List<TvSerieGenre>();
}
