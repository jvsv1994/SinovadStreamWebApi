using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class Episode : BaseEntity
{
    public int EpisodeNumber { get; set; }

    public string? Title { get; set; }

    public string? Summary { get; set; }

    public int SeasonId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Season Season { get; set; } = null!;
}
