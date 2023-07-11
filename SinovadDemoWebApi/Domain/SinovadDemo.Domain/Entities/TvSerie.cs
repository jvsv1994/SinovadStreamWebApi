using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class TvSerie : BaseAuditableEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TmdbId { get; set; }

    public string? OriginalLanguage { get; set; }

    public string? OriginalName { get; set; }

    public string? Overview { get; set; }

    public double? Popularity { get; set; }

    public string? PosterPath { get; set; }

    public string? BackdropPath { get; set; }

    public DateTime? FirstAirDate { get; set; }

    public DateTime? LastAirDate { get; set; }

    public string? Directors { get; set; }

    public string? Actors { get; set; }

    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();

    public virtual ICollection<TvSerieGenre> TvSerieGenres { get; set; } = new List<TvSerieGenre>();
}
