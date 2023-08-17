using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _170820231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropTable(
                name: "TranscoderSettings");

            migrationBuilder.DropTable(
                name: "TranscodingProcess");

            migrationBuilder.DropTable(
                name: "VideoProfile");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.CreateTable(
                name: "LinkedAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedAccountTypeCatalodId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedAccountTypeCatalodDetailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LinkedAccount__3214EC27B7871CE4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkedAccount_User_ID",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("c8f31cf0-2357-4238-8690-ea2d557f13c6"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("36310ba7-2098-4045-a485-c1b4052728b7"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("dd0f8237-48cb-478b-8a19-c0dffb024e33"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("bb6eb004-f2cd-46d1-9af2-96c1fa9c5f4c"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("2b011404-c57e-496e-920d-64c2dfc29b5a"));

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "Guid", "LastModified", "LastModifiedBy", "Name" },
                values: new object[] { 6, null, null, null, new Guid("f711044e-4039-4962-bfd3-6be2097adb87"), null, null, "Tipo de Cuenta Vinculada" });

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("ee57babe-3f5e-4e37-a4c4-a58b92b5da2e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("8c42a6ca-c583-4b4c-9050-a376555007dc"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("e89173f9-81fc-48d8-94f2-24cecc46e378"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("9f8b0bc7-29ee-42ee-a002-a653db0ed87d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("30084389-9fc1-4c2b-a8b2-dc1768235df3"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("9d1921b4-6757-43e3-9e08-cbaf2191a478"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("1ede8d58-ce69-4581-95f5-d001195ca8f8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("46ac6b68-40a5-498e-b951-dd81149a25c8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("31505fb1-cb31-4e6d-9d88-4d2fe9beb480"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("18439b82-9d54-40fc-bc36-698af6a72fc3"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("f3d1fca4-8a47-4cc3-b426-35fdeb32d70d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("820ed7be-a117-4f83-bc44-f1eee303a3db"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("d5a45b56-a918-4983-99a3-19619bd51463"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("f541e71d-6579-464b-9fa6-8aa829f31329"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("09a1b6b9-e64f-439a-83a1-774d6b82389b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("1b67ee7d-8fda-4586-bb69-dfc62ca337f1"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("fcc6a47f-2457-461f-9cbf-1dafb02fc48f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("87344eb7-2c32-4376-8011-67586f03e97a"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("26c6008e-126e-430c-9a5a-a427115a9d12"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("ffb15d7e-02cd-4c7e-ad95-77ae37af14fc"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("896f7322-50a0-48d3-a636-6a7fb6f4e422"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("28c87df8-8165-4615-bf27-cf49c1215475"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("5b2d0deb-c3e6-4553-8b01-23480563f9d5"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("7fc386fc-a097-4f9a-b54d-38b3ba5be951"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("ae02ecf7-4992-4046-b79e-f27d816e19c6"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("943b14da-15bf-47be-8f3f-2b4b1848019a"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("9bc12046-6047-4277-8793-9f273dc3f705"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("652ff748-46d1-4fd8-9160-1ed1bb53fef5"));

            migrationBuilder.InsertData(
                table: "CatalogDetail",
                columns: new[] { "CatalogId", "Id", "Created", "CreatedBy", "Deleted", "Guid", "LastModified", "LastModifiedBy", "Name", "NumberValue", "TextValue" },
                values: new object[,]
                {
                    { 6, 1, null, null, null, new Guid("c3650018-1664-4cd0-a896-15e734eb68e9"), null, null, "Google", null, null },
                    { 6, 2, null, null, null, new Guid("7c07e311-13c6-46d3-8629-58ce11c02191"), null, null, "Facebook", null, null },
                    { 6, 3, null, null, null, new Guid("3a205464-62ea-4339-bf2c-d5cbffe47875"), null, null, "Apple", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkedAccount_UserId",
                table: "LinkedAccount",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkedAccount");

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaServerId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaTypeCatalogDetailId = table.Column<int>(type: "int", nullable: false),
                    MediaTypeCatalogId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Library__3214EC27C8AEFD60", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Library_MediaServer_ID",
                        column: x => x.MediaServerId,
                        principalTable: "MediaServer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TranscoderSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaServerId = table.Column<int>(type: "int", nullable: false),
                    ConstantRateFactor = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresetCatalogDetailId = table.Column<int>(type: "int", nullable: false),
                    PresetCatalogId = table.Column<int>(type: "int", nullable: false),
                    TemporaryFolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoTransmissionTypeCatalogDetailId = table.Column<int>(type: "int", nullable: false),
                    VideoTransmissionTypeCatalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transcod__3214EC279D19B237", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranscoderSettings_MediaServer_ID",
                        column: x => x.MediaServerId,
                        principalTable: "MediaServer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TranscodingProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalSystemProcessIdentifier = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    GeneratedTemporaryFolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaServerId = table.Column<int>(type: "int", nullable: false),
                    PendingDeletion = table.Column<bool>(type: "bit", nullable: false),
                    RequestGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemProcessIdentifier = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transcod__3214EC27DF052101", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    EpisodeId = table.Column<int>(type: "int", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibraryId = table.Column<int>(type: "int", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    PhysicalPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    SeasonNumber = table.Column<int>(type: "int", nullable: true),
                    Subtitle = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Title = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    TvSerieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Video__3214EC2725862FD1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoProfile",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentTime = table.Column<double>(type: "float", nullable: false),
                    DurationTime = table.Column<double>(type: "float", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoProfile", x => new { x.VideoId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_VideoProfileProfile",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoProfileVideo",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("1f75d17a-5a57-4ec7-93cd-c597f9640aeb"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("3b41269c-009a-4984-a221-9b6504742f77"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("8a450252-8b90-4e74-8de7-f37618ce7613"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("5842b00f-235a-4297-88a8-87256474ee5c"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("5e0e6da4-723b-4135-9634-8da9081a46ba"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("b1a82132-2787-4d85-bc48-40218f53e766"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("19cc48da-0277-4fbf-8d17-99864a323ae0"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("8c7cd77d-2e77-46e4-88c5-5245a6969b52"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("216e6945-41f6-4377-9232-06aeeb8a91cb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("1e13f6b4-5c7d-4300-8ccb-87a8edb8b360"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("7b4ab894-de3f-4273-a057-00c9e6a127df"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("f3341f4e-acc7-40be-98c3-9b768506797c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("26c54d22-b837-483d-9fc2-9af8c65f2ea2"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("89f5b423-cefe-40b6-9dce-1819810fc124"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("504f464f-9fe4-4974-af26-3205d895eb04"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("72710812-1b87-4902-82b0-1048ced60e9d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("67966112-8c37-48f9-9476-bdd57679e2bd"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("424b5859-0ef3-4731-b4f4-df72428eb4ad"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("c80ea90f-9de0-447d-82b9-cfb9bf3be85a"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("79165d46-06c7-4caf-9ee4-77c2e6a01e8f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("981da7a9-4d34-498a-bb34-cac85b83d86c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("44f1793f-dbed-4e5e-b5f1-261c8259e50e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("0a86e09a-e240-444f-a43b-15d6fbc94d70"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("694befb0-a138-46c8-a72a-7c41fb29edec"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("801ce7d4-2155-4bcc-b94c-dca2754397f3"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("d39f15e6-01cd-42ea-9d03-5822bd9a0153"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("e7372ce1-4843-4d0d-b0fe-f5b685c6b72f"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("bf7e38b3-64e6-48d1-9fc6-396c522cd7e2"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("26287ee4-dac0-43bd-82cf-6902a40e24a2"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("d72e404b-ac8d-46bf-8d4b-68c6ba8135ad"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("47db60a6-eda8-4923-8022-3ec02550d590"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("0b5c53bc-39a1-4226-8b40-6fff03e490f6"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("96153403-6b36-4444-bba7-42ba3c045e32"));

            migrationBuilder.CreateIndex(
                name: "IX_Library_MediaServerId",
                table: "Library",
                column: "MediaServerId");

            migrationBuilder.CreateIndex(
                name: "IX_TranscoderSettings_MediaServerId",
                table: "TranscoderSettings",
                column: "MediaServerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoProfile_ProfileId",
                table: "VideoProfile",
                column: "ProfileId");
        }
    }
}
