using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class Movie : BaseAuditableEntity
{
    public int Id { get; set; }

    public bool? Adult { get; set; }

    public int? TmdbId { get; set; }

    public string? OriginalLanguage { get; set; }

    public string? OriginalTitle { get; set; }

    public string? Overview { get; set; }

    public double? Popularity { get; set; }

    public string? PosterPath { get; set; }

    public string? BackdropPath { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string Title { get; set; } = null!;

    public string? Directors { get; set; }

    public string? Actors { get; set; }

    public string? Imdbid { get; set; }

    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}
