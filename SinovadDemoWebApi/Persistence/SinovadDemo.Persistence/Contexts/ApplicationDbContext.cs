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

    public virtual DbSet<Catalog> Catalogs { get; set; }

    public virtual DbSet<CatalogDetail> CatalogDetails { get; set; }

    public virtual DbSet<Episode> Episodes { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<RoleMenu> RoleMenus { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<LinkedAccount> LinkedAccounts { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<TvSerie> TvSeries { get; set; }

    public virtual DbSet<TvSerieGenre> TvSerieGenres { get; set; }

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
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
        });

        modelBuilder.Entity<Menu>().HasData(
        new Menu { Id = 1, ParentId = 0, SortOrder = 1,Title="General",Guid=Guid.NewGuid(), Enabled = true },
        new Menu { Id = 2, ParentId = 0, SortOrder = 2,Title = "Movie Data Base", Guid = Guid.NewGuid(), Enabled = true },    
        new Menu { Id = 3, ParentId = 1, SortOrder = 1, Title = "Roles", Path = "/manage/roles", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-list-check", Enabled = true, Guid = Guid.NewGuid() },
        new Menu { Id = 4, ParentId = 1, SortOrder = 2, Title = "Usuarios", Path = "/manage/users", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-user", Enabled = true, Guid = Guid.NewGuid() },
        new Menu { Id = 5, ParentId = 1, SortOrder = 3, Title = "Menu", Path = "/manage/menus", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-list-check", Enabled = true, Guid = Guid.NewGuid() },
        new Menu { Id = 6, ParentId = 1, SortOrder = 3, Title = "Catálogos", Path = "/manage/catalogs", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-list-check", Enabled = true, Guid = Guid.NewGuid() },
        new Menu { Id = 7, ParentId = 2, SortOrder = 1, Title = "Peliculas", Path = "/manage/movies", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-film", Enabled = true, Guid = Guid.NewGuid() },
        new Menu { Id = 8, ParentId = 2, SortOrder = 2, Title = "Series", Path = "/manage/tvseries", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-tv", Enabled = true, Guid = Guid.NewGuid() },
        new Menu { Id = 9, ParentId = 2, SortOrder = 3, Title = "Generos", Path = "/manage/genres", IconTypeCatalogId = (int)CatalogEnum.IconType, IconTypeCatalogDetailId = (int)IconType.FontAwesome, IconClass = "fa-solid fa-list-check", Enabled = true, Guid = Guid.NewGuid()});

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
        });

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Administrador Principal", Enabled = true, Guid = Guid.NewGuid() },
            new Role { Id = 2, Name = "Administrador de Medios", Enabled = true, Guid = Guid.NewGuid() });

        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catalog__3214EC275C8D2947");

            entity.ToTable("Catalog");
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
            entity.Property(e => e.Id);
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        //modelBuilder.Entity<Catalog>().HasData(
        //   new Catalog { Id = 1, Name = "Estado del Servidor Multimedia", Guid = Guid.NewGuid() },
        //   new Catalog { Id = 2, Name = "Tipos de contenido Multimedia ", Guid = Guid.NewGuid() },
        //   new Catalog { Id = 3, Name = "Tipos de transmisión de Video", Guid = Guid.NewGuid() },
        //   new Catalog { Id = 4, Name = "Preajuste del transcodificador", Guid = Guid.NewGuid() },
        //   new Catalog { Id = 5, Name = "Tipo de Icono", Guid = Guid.NewGuid() },
        //   new Catalog { Id = 6, Name = "Proveedor de Cuenta Vinculada", Guid = Guid.NewGuid() });

        modelBuilder.Entity<CatalogDetail>(entity =>
        {
            entity.HasKey(e => new { e.CatalogId, e.Id }).HasName("PK__CatalogD__5C6FE914EF292CEC");

            entity.ToTable("CatalogDetail");
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
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

        //modelBuilder.Entity<CatalogDetail>().HasData(
        //new CatalogDetail { CatalogId = 1, Id = 1, Name = "Iniciado", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 1, Id = 2, Name = "Pausado", Guid = Guid.NewGuid() },

        //new CatalogDetail { CatalogId = 2, Id = 1, Name = "Película", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 2, Id = 2, Name = "Serie de TV", Guid = Guid.NewGuid() },

        //new CatalogDetail { CatalogId = 3, Id = 1, Name = "Normal", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 3, Id = 2, Name = "MPEG-DASH", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 3, Id = 3, Name = "HLS", Guid = Guid.NewGuid() },

        //new CatalogDetail { CatalogId = 4, Id = 1, Name = "ultrafast",TextValue= "ultrafast", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 4, Id = 2, Name = "superfast",TextValue= "superfast", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 4, Id = 3, Name = "veryfast", TextValue = "veryfast", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 4, Id = 4, Name = "faster", TextValue = "faster", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 4, Id = 5, Name = "fast", TextValue = "fast", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 4, Id = 6, Name = "medium", TextValue = "medium", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 4, Id = 7, Name = "slow", TextValue = "slow", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 4, Id = 8, Name = "slower", TextValue = "slower", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 4, Id = 9, Name = "veryslow", TextValue = "veryslow", Guid = Guid.NewGuid() },

        //new CatalogDetail { CatalogId = 5, Id = 1, Name = "Imagen", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 5, Id = 2, Name = "Font Awesome", Guid = Guid.NewGuid() },

        //new CatalogDetail { CatalogId = 6, Id = 1, Name = "Google", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 6, Id = 2, Name = "Facebook", Guid = Guid.NewGuid() },
        //new CatalogDetail { CatalogId = 6, Id = 3, Name = "Apple", Guid = Guid.NewGuid() });

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
           new RoleMenu { RoleId = 2, MenuId = 2 },
           new RoleMenu { RoleId = 2, MenuId = 7 },
           new RoleMenu { RoleId = 2, MenuId = 8 },
           new RoleMenu { RoleId = 2, MenuId = 9 });


        modelBuilder.Entity<MediaServer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MediaServer__3214EC27FF56ACAD");

            entity.ToTable("MediaServer");

            entity.HasOne(d => d.User).WithMany(p => p.MediaServers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MediaServer_User_ID");
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
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
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC274FE83434");

            entity.ToTable("Genre");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
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
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
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
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
        });

        modelBuilder.Entity<LinkedAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LinkedAccount__3214EC27B7871CE4");

            entity.ToTable("LinkedAccount");

            entity.HasOne(d => d.User).WithMany(p => p.LinkedAccounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinkedAccount_User_ID");
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
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
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
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
            entity.Property(e => e.Guid).HasDefaultValueSql("NewId()");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
