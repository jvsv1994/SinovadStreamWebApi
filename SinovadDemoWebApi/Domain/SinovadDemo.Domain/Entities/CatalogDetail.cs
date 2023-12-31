﻿using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class CatalogDetail : BaseEntity
{
    public int CatalogId { get; set; }

    public string Name { get; set; } = null!;

    public string? TextValue { get; set; }

    public int? NumberValue { get; set; }

    public virtual Catalog Catalog { get; set; } = null!;
}
