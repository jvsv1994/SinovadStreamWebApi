using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinovadDemo.Persistence.Interceptors;

namespace SinovadDemo.Domain.Entities;

public partial class ApplicationDbContext : IdentityDbContext
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

    public DbSet<AppUser> Accounts { get; set; }

    public virtual DbSet<AccountServer> AccountServers { get; set; }

    public virtual DbSet<AccountStorage> AccountStorages { get; set; }

    public virtual DbSet<Catalog> Catalogs { get; set; }

    public virtual DbSet<CatalogDetail> CatalogDetails { get; set; }

    public virtual DbSet<Episode> Episodes { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<TranscodeSetting> TranscodeSettings { get; set; }

    public virtual DbSet<TranscodeVideoProcess> TranscodeVideoProcesses { get; set; }

    public virtual DbSet<TvSerie> TvSeries { get; set; }

    public virtual DbSet<TvSerieGenre> TvSerieGenres { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    public virtual DbSet<VideoProfile> VideoProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
       optionsBuilder.EnableSensitiveDataLogging();
        //optionsBuilder.UseSqlServer("Add Connection String");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AccountServer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountS__3214EC27FF56ACAD");

            entity.ToTable("AccountServer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.HostUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.IpAddress)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.StateCatalogDetailId)
                .HasDefaultValueSql("((2))")
                .HasColumnName("State_Catalog_Detail_ID");
            entity.Property(e => e.StateCatalogId)
                .HasDefaultValueSql("((3))")
                .HasColumnName("State_Catalog_ID");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountServers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountServer_Account_ID");
        });

        modelBuilder.Entity<AccountStorage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountS__3214EC27C8AEFD60");

            entity.ToTable("AccountStorage");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountServerId).HasColumnName("AccountServer_ID");
            entity.Property(e => e.AccountStorageTypeId).HasColumnName("AccountStorageType_ID");
            entity.Property(e => e.PhisicalPath)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountServer).WithMany(p => p.AccountStorages)
                .HasForeignKey(d => d.AccountServerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountStorage_AccountServer_ID");
        });

        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catalog__3214EC275C8D2947");

            entity.ToTable("Catalog");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CatalogDetail>(entity =>
        {
            entity.HasKey(e => new { e.CatalogId, e.Id }).HasName("PK__CatalogD__5C6FE914EF292CEC");

            entity.ToTable("CatalogDetail");

            entity.Property(e => e.CatalogId).HasColumnName("Catalog_ID");
            entity.Property(e => e.Id).HasColumnName("ID");
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

        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Episode__3214EC27EA0C7DAB");

            entity.ToTable("Episode");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.SeasonId).HasColumnName("Season_ID");
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

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TmdbId).HasColumnName("TMDbID");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC27293CDB91");

            entity.ToTable("Movie");

            entity.Property(e => e.Id).HasColumnName("ID");
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
                .IsUnicode(false)
                .HasColumnName("IMDBID");
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
            entity.Property(e => e.TmdbId).HasColumnName("TMDbID");
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MovieGen__3214EC277F0023A9");

            entity.ToTable("MovieGenre");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GenreId).HasColumnName("Genre_ID");
            entity.Property(e => e.MovieId).HasColumnName("Movie_ID");

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

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.AvatarPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Pincode).HasColumnName("PINCode");

            entity.HasOne(d => d.Account).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profile_Account_ID");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Season__3214EC27FB52A288");

            entity.ToTable("Season");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Summary)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.TvSerieId).HasColumnName("TvSerie_ID");

            entity.HasOne(d => d.TvSerie).WithMany(p => p.Seasons)
                .HasForeignKey(d => d.TvSerieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Season_TvSerie_ID");
        });

        modelBuilder.Entity<TranscodeSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transcod__3214EC279D19B237");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountServerId).HasColumnName("AccountServer_ID");
            entity.Property(e => e.DirectoryPhysicalPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.PresetCatalogDetailId).HasColumnName("Preset_Catalog_Detail_ID");
            entity.Property(e => e.PresetCatalogId).HasColumnName("Preset_Catalog_ID");
            entity.Property(e => e.TransmissionMethodCatalogDetailId).HasColumnName("Transmission_Method_Catalog_Detail_ID");
            entity.Property(e => e.TransmissionMethodCatalogId).HasColumnName("Transmission_Method_Catalog_ID");

            entity.HasOne(d => d.AccountServer).WithMany(p => p.TranscodeSettings)
                .HasForeignKey(d => d.AccountServerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TranscodeSettings_AccountServer_ID");
        });

        modelBuilder.Entity<TranscodeVideoProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transcod__3214EC27DF052101");

            entity.ToTable("TranscodeVideoProcess");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountServerId).HasColumnName("AccountServer_ID");
            entity.Property(e => e.Guid)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("GUID");
            entity.Property(e => e.TranscodeAudioVideoProcessId).HasColumnName("TranscodeAudioVideoProcessID");
            entity.Property(e => e.TranscodeSubtitlesProcessId).HasColumnName("TranscodeSubtitlesProcessID");
            entity.Property(e => e.WorkingDirectoryPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TvSerie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TvSerie__3214EC27895BB3B8");

            entity.ToTable("TvSerie");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.Property(e => e.TmdbId).HasColumnName("TMDbID");
        });

        modelBuilder.Entity<TvSerieGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TvSerieG__3214EC276D0EA328");

            entity.ToTable("TvSerieGenre");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GenreId).HasColumnName("Genre_ID");
            entity.Property(e => e.TvSerieId).HasColumnName("TvSerie_ID");

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

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountStorageId).HasColumnName("AccountStorage_ID");
            entity.Property(e => e.EpisodeId).HasColumnName("Episode_ID");
            entity.Property(e => e.MovieId).HasColumnName("Movie_ID");
            entity.Property(e => e.PhysicalPath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Subtitle)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.TvSerieId).HasColumnName("TvSerie_ID");
        });

        modelBuilder.Entity<VideoProfile>(entity =>
        {
            entity.HasKey(e => new { e.VideoId, e.ProfileId });

            entity.ToTable("VideoProfile");

            entity.Property(e => e.VideoId).HasColumnName("Video_ID");
            entity.Property(e => e.ProfileId).HasColumnName("Profile_ID");

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
