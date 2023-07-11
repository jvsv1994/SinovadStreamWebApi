using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Catalog__3214EC275C8D2947", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TMDbID = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genre__3214EC274FE83434", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adult = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    TMDbID = table.Column<int>(type: "int", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    OriginalTitle = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Overview = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    BackdropPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Directors = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Actors = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    IMDBID = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movie__3214EC27293CDB91", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TranscodeVideoProcess",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    TranscodeAudioVideoProcessID = table.Column<int>(type: "int", nullable: false),
                    TranscodeSubtitlesProcessID = table.Column<int>(type: "int", nullable: true),
                    WorkingDirectoryPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    AccountServer_ID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transcod__3214EC27DF052101", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TvSerie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TMDbID = table.Column<int>(type: "int", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    OriginalName = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Overview = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    BackdropPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    FirstAirDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAirDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Directors = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Actors = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TvSerie__3214EC27895BB3B8", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    PhysicalPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    AccountStorage_ID = table.Column<int>(type: "int", nullable: true),
                    Movie_ID = table.Column<int>(type: "int", nullable: true),
                    Episode_ID = table.Column<int>(type: "int", nullable: true),
                    TvSerie_ID = table.Column<int>(type: "int", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: true),
                    SeasonNumber = table.Column<int>(type: "int", nullable: true),
                    Subtitle = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Video__3214EC2725862FD1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountServer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Account_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    State_Catalog_ID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((3))"),
                    State_Catalog_Detail_ID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((2))"),
                    HostUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AccountS__3214EC27FF56ACAD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountServer_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    PINCode = table.Column<int>(type: "int", nullable: true),
                    AvatarPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profile__3214EC27B7871CE4", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Profile_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CatalogDetail",
                columns: table => new
                {
                    Catalog_ID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    TextValue = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    NumberValue = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CatalogD__5C6FE914EF292CEC", x => new { x.Catalog_ID, x.ID });
                    table.ForeignKey(
                        name: "FK_CatalogDetail_Catalog_ID",
                        column: x => x.Catalog_ID,
                        principalTable: "Catalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movie_ID = table.Column<int>(type: "int", nullable: false),
                    Genre_ID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MovieGen__3214EC277F0023A9", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_ID",
                        column: x => x.Genre_ID,
                        principalTable: "Genre",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_ID",
                        column: x => x.Movie_ID,
                        principalTable: "Movie",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonNumber = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Summary = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    TvSerie_ID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Season__3214EC27FB52A288", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Season_TvSerie_ID",
                        column: x => x.TvSerie_ID,
                        principalTable: "TvSerie",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TvSerieGenre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TvSerie_ID = table.Column<int>(type: "int", nullable: false),
                    Genre_ID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TvSerieG__3214EC276D0EA328", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TvSerieGenre_Genre_ID",
                        column: x => x.Genre_ID,
                        principalTable: "Genre",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TvSerieGenre_TvSerie_ID",
                        column: x => x.TvSerie_ID,
                        principalTable: "TvSerie",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AccountStorage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountServer_ID = table.Column<int>(type: "int", nullable: false),
                    PhisicalPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    AccountStorageType_ID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AccountS__3214EC27C8AEFD60", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountStorage_AccountServer_ID",
                        column: x => x.AccountServer_ID,
                        principalTable: "AccountServer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TranscodeSettings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountServer_ID = table.Column<int>(type: "int", nullable: false),
                    Transmission_Method_Catalog_ID = table.Column<int>(type: "int", nullable: false),
                    Transmission_Method_Catalog_Detail_ID = table.Column<int>(type: "int", nullable: false),
                    Preset_Catalog_ID = table.Column<int>(type: "int", nullable: false),
                    Preset_Catalog_Detail_ID = table.Column<int>(type: "int", nullable: false),
                    DirectoryPhysicalPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ConstantRateFactor = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transcod__3214EC279D19B237", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TranscodeSettings_AccountServer_ID",
                        column: x => x.AccountServer_ID,
                        principalTable: "AccountServer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "VideoProfile",
                columns: table => new
                {
                    Video_ID = table.Column<int>(type: "int", nullable: false),
                    Profile_ID = table.Column<int>(type: "int", nullable: false),
                    DurationTime = table.Column<double>(type: "float", nullable: false),
                    CurrentTime = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoProfile", x => new { x.Video_ID, x.Profile_ID });
                    table.ForeignKey(
                        name: "FK_VideoProfileProfile",
                        column: x => x.Profile_ID,
                        principalTable: "Profile",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_VideoProfileVideo",
                        column: x => x.Video_ID,
                        principalTable: "Video",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Summary = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Season_ID = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Episode__3214EC27EA0C7DAB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Episode_Season_ID",
                        column: x => x.Season_ID,
                        principalTable: "Season",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountServer_Account_ID",
                table: "AccountServer",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountStorage_AccountServer_ID",
                table: "AccountStorage",
                column: "AccountServer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_Season_ID",
                table: "Episode",
                column: "Season_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_Genre_ID",
                table: "MovieGenre",
                column: "Genre_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_Movie_ID",
                table: "MovieGenre",
                column: "Movie_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Account_ID",
                table: "Profile",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Season_TvSerie_ID",
                table: "Season",
                column: "TvSerie_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TranscodeSettings_AccountServer_ID",
                table: "TranscodeSettings",
                column: "AccountServer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TvSerieGenre_Genre_ID",
                table: "TvSerieGenre",
                column: "Genre_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TvSerieGenre_TvSerie_ID",
                table: "TvSerieGenre",
                column: "TvSerie_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoProfile_Profile_ID",
                table: "VideoProfile",
                column: "Profile_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountStorage");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CatalogDetail");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "TranscodeSettings");

            migrationBuilder.DropTable(
                name: "TranscodeVideoProcess");

            migrationBuilder.DropTable(
                name: "TvSerieGenre");

            migrationBuilder.DropTable(
                name: "VideoProfile");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "AccountServer");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "TvSerie");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
