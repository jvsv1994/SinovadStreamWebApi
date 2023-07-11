using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class MovieGenre : BaseAuditableEntity
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
