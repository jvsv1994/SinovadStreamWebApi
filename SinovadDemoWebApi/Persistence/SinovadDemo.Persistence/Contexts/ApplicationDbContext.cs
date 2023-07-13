using Generic.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinovadDemo.Domain.Enums;
using SinovadDemo.Persistence.Interceptors;

namespace SinovadDemo.Domain.Entities;

public partial class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public virtual DbSet<MediaServer> MediaServers { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<Catalog> Catalogs { get; set; }

    public virtual DbSet<CatalogDetail> CatalogDetails { get; set; }

    public virtual DbSet<Episode> Episodes { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<RoleMenu> RoleMenus { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<TranscoderSettings> TranscoderSettings { get; set; }

    public virtual DbSet<TranscodingProcess> TranscodingProcesses { get; set; }

    public virtual DbSet<TvSerie> TvSeries { get; set; }

    public virtual DbSet<TvSerieGenre> TvSerieGenres { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    public virtual DbSet<VideoProfile> VideoProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
       optionsBuilder.EnableSensitiveDataLogging();
       //optionsBuilder.UseSqlServer("Add connection String");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");
        });

        modelBuilder.Entity<Menu>().HasData(
        new Menu { Id = 1, ParentId = 0, SortOrder = 1,Title="Media" },
        new Menu { Id = 2, ParentId = 0, SortOrder = 2,Title = "Almacenamiento" },
        new Menu { Id = 3, ParentId = 0, SortOrder = 3, Title = "Mantenimiento" },
        new Menu { Id = 4, ParentId = 1, SortOrder = 1, Title = "Inicio",Path="/home",IconTypeCatalogId= (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-house", Enabled=true},
        new Menu { Id = 5, ParentId = 1, SortOrder = 2, Title = "Peliculas",Path = "/movies", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-film", Enabled = true },
        new Menu { Id = 6, ParentId = 1, SortOrder = 3, Title = "Series",Path = "/tvseries", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-tv", Enabled = true },
        new Menu { Id = 7, ParentId = 2, SortOrder = 1, Title = "Almacenamiento", Path = "/storages", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-database", Enabled = true },
        new Menu { Id = 8, ParentId = 2, SortOrder = 2, Title = "Transcodificacion", Path = "/transcoder", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-database", Enabled = true },
        new Menu { Id = 9, ParentId = 3, SortOrder = 1, Title = "Peliculas", Path = "/movies-maintenance", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-film", Enabled = true },
        new Menu { Id = 10, ParentId = 3, SortOrder = 2, Title = "Series", Path = "/tvseries-maintenance", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-tv", Enabled = true },
        new Menu { Id = 11, ParentId = 3, SortOrder = 3, Title = "Generos", Path = "/genres-maintenance", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-list-check", Enabled = true },
        new Menu { Id = 12, ParentId = 3, SortOrder = 4, Title = "Roles", Path = "/roles-maintenance", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-list-check", Enabled = true },
        new Menu { Id = 13, ParentId = 3, SortOrder = 5, Title = "Usuarios", Path = "/users-maintenance", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-user", Enabled = true },
        new Menu { Id = 14, ParentId = 3, SortOrder = 6, Title = "Opciones", Path = "/options-maintenance", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-list-check", Enabled = true });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
        });

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Administrador", Enable = true});

        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catalog__3214EC275C8D2947");

            entity.ToTable("Catalog");

            entity.Property(e => e.Id)
                .ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Catalog>().HasData(
           new Catalog { Id = 1, Name = "Estado del Servidor Multimedia" },
           new Catalog { Id = 2, Name = "Tipos de contenido Multimedia " },
           new Catalog { Id = 3, Name = "Tipos de transmisión de Video" },
           new Catalog { Id = 4, Name = "Preajuste del transcodificador" },
           new Catalog { Id = 5, Name = "Tipo de Icono" });

        modelBuilder.Entity<CatalogDetail>(entity =>
        {
            entity.HasKey(e => new { e.CatalogId, e.Id }).HasName("PK__CatalogD__5C6FE914EF292CEC");

            entity.ToTable("CatalogDetail");

            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.TextValue)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Catalog).WithMany(p => p.CatalogDetails)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CatalogDetail_Catalog_ID");
        });

        modelBuilder.Entity<CatalogDetail>().HasData(
        new CatalogDetail { CatalogId = 1, Id = 1, Name = "Iniciado"},
        new CatalogDetail { CatalogId = 1, Id = 2, Name = "Pausado" },

        new CatalogDetail { CatalogId = 2, Id = 1, Name = "Película" },
        new CatalogDetail { CatalogId = 2, Id = 2, Name = "Serie de TV"},

        new CatalogDetail { CatalogId = 3, Id = 1, Name = "Normal"},
        new CatalogDetail { CatalogId = 3, Id = 2, Name = "MPEG-DASH" },
        new CatalogDetail { CatalogId = 3, Id = 3, Name = "HLS" },

        new CatalogDetail { CatalogId = 4, Id = 1, Name = "ultrafast",TextValue= "ultrafast" },
        new CatalogDetail { CatalogId = 4, Id = 2, Name = "superfast",TextValue= "superfast" },
        new CatalogDetail { CatalogId = 4, Id = 3, Name = "veryfast", TextValue = "veryfast" },
        new CatalogDetail { CatalogId = 4, Id = 4, Name = "faster", TextValue = "faster" },
        new CatalogDetail { CatalogId = 4, Id = 5, Name = "fast", TextValue = "fast" },
        new CatalogDetail { CatalogId = 4, Id = 6, Name = "medium", TextValue = "medium" },
        new CatalogDetail { CatalogId = 4, Id = 7, Name = "slow", TextValue = "slow" },
        new CatalogDetail { CatalogId = 4, Id = 8, Name = "slower", TextValue = "slower" },
        new CatalogDetail { CatalogId = 4, Id = 9, Name = "veryslow", TextValue = "veryslow" },

        new CatalogDetail { CatalogId = 5, Id = 1, Name = "Font Awesome" },
        new CatalogDetail { CatalogId = 5, Id = 2, Name = "Imagen" });


        modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
        {
            entity.ToTable("UserClaim");
        });

        modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
        {
            entity.ToTable("UserLogin");
        });

        modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
        {
            entity.ToTable("RoleClaim");
        });

        modelBuilder.Entity<IdentityUserToken<int>>(entity =>
        {
            entity.ToTable("UserToken");
        });

        modelBuilder.Entity<UserRole>(userRole =>
        {
            userRole.ToTable("UserRole");

            userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();


            userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });

        modelBuilder.Entity<RoleMenu>(roleMenu =>
        {
            roleMenu.ToTable("RoleMenu");

            roleMenu.HasKey(rm => new { rm.RoleId, rm.MenuId });

            roleMenu.HasOne(rm => rm.Role)
                .WithMany(r => r.RoleMenus)
                .HasForeignKey(rm => rm.RoleId)
                .IsRequired();

            roleMenu.HasOne(rm => rm.Menu)
                .WithMany(m => m.RoleMenus)
                .HasForeignKey(rm => rm.MenuId)
                .IsRequired();
        });


        modelBuilder.Entity<RoleMenu>().HasData(
           new RoleMenu { RoleId = 1, MenuId = 1 },
           new RoleMenu { RoleId = 1, MenuId = 2 },
           new RoleMenu { RoleId = 1, MenuId = 3 },
           new RoleMenu { RoleId = 1, MenuId = 4 },
           new RoleMenu { RoleId = 1, MenuId = 5 },
           new RoleMenu { RoleId = 1, MenuId = 6 },
           new RoleMenu { RoleId = 1, MenuId = 7 },
           new RoleMenu { RoleId = 1, MenuId = 8 },
           new RoleMenu { RoleId = 1, MenuId = 9 },
           new RoleMenu { RoleId = 1, MenuId = 10 },
           new RoleMenu { RoleId = 1, MenuId = 11 },
           new RoleMenu { RoleId = 1, MenuId = 12 },
           new RoleMenu { RoleId = 1, MenuId = 13 },
           new RoleMenu { RoleId = 1, MenuId = 14 });


        modelBuilder.Entity<MediaServer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MediaServer__3214EC27FF56ACAD");

            entity.ToTable("MediaServer");

            entity.HasOne(d => d.User).WithMany(p => p.MediaServers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MediaServer_User_ID");
            entity.HasOne(d => d.TranscoderSettings).WithOne(p => p.MediaServer)
                .HasForeignKey<TranscoderSettings>(d => d.MediaServerId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_MediaServer_User_ID");
        });

        modelBuilder.Entity<TranscoderSettings>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transcod__3214EC279D19B237");

            entity.HasOne(d => d.MediaServer).WithOne(p => p.TranscoderSettings)
                .HasForeignKey<TranscoderSettings>(d => d.MediaServerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TranscoderSettings_MediaServer_ID");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storage__3214EC27C8AEFD60");

            entity.ToTable("Storage");

            entity.Property(e => e.PhysicalPath)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.MediaServer).WithMany(p => p.Storages)
                .HasForeignKey(d => d.MediaServerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Storage_MediaServer_ID");
        });



        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Episode__3214EC27EA0C7DAB");

            entity.ToTable("Episode");

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Summary)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Season).WithMany(p => p.Episodes)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Episode_Season_ID");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC274FE83434");

            entity.ToTable("Genre");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC27293CDB91");

            entity.ToTable("Movie");

            entity.Property(e => e.Actors)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Adult).HasDefaultValueSql("((0))");
            entity.Property(e => e.BackdropPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Directors)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Imdbid)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OriginalLanguage)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OriginalTitle)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Overview)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.PosterPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity.HasKey(mg => new { mg.MovieId, mg.GenreId });

            entity.ToTable("MovieGenre");


            entity.HasOne(d => d.Genre).WithMany(p => p.MovieGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieGenre_Genre_ID");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieGenres)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieGenre_Movie_ID");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profile__3214EC27B7871CE4");

            entity.ToTable("Profile");

            entity.Property(e => e.AvatarPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profile_User_ID");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Season__3214EC27FB52A288");

            entity.ToTable("Season");

            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Summary)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.TvSerie).WithMany(p => p.Seasons)
                .HasForeignKey(d => d.TvSerieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Season_TvSerie_ID");
        });


        modelBuilder.Entity<TranscodingProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transcod__3214EC27DF052101");

            entity.ToTable("TranscodingProcess");

        });

        modelBuilder.Entity<TvSerie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TvSerie__3214EC27895BB3B8");

            entity.ToTable("TvSerie");

            entity.Property(e => e.Actors)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.BackdropPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Directors)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FirstAirDate).HasColumnType("datetime");
            entity.Property(e => e.LastAirDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OriginalLanguage)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OriginalName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Overview)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.PosterPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TvSerieGenre>(entity =>
        {
            entity.HasKey(tvg => new { tvg.TvSerieId, tvg.GenreId });

            entity.ToTable("TvSerieGenre");

            entity.HasOne(d => d.Genre).WithMany(p => p.TvSerieGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TvSerieGenre_Genre_ID");

            entity.HasOne(d => d.TvSerie).WithMany(p => p.TvSerieGenres)
                .HasForeignKey(d => d.TvSerieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TvSerieGenre_TvSerie_ID");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Video__3214EC2725862FD1");

            entity.ToTable("Video");

            entity.Property(e => e.PhysicalPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Subtitle)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VideoProfile>(entity =>
        {
            entity.HasKey(e => new { e.VideoId, e.ProfileId });

            entity.ToTable("VideoProfile");

            entity.HasOne(d => d.Profile).WithMany(p => p.VideoProfiles)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VideoProfileProfile");

            entity.HasOne(d => d.Video).WithMany(p => p.VideoProfiles)
                .HasForeignKey(d => d.VideoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VideoProfileVideo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
