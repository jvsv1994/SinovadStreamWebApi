using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update190720233 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Video",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "TvSerie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "TranscodingProcess",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "TranscoderSettings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Storage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Season",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Profile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Movie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "MediaServer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Genre",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Episode",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "CatalogDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Catalog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NewId()");

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("fad71ef9-f587-4af3-a3e9-13e15d8e7d60"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("dbfabeb8-efe5-43bb-9bfb-5fef586e85de"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("bf1634ac-0b8b-4684-b576-6284408e64fe"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("1e525b2e-982d-43a3-86dd-e58727fbe103"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("4be865c8-f0be-4652-abbb-6e32b43e0e8f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("785b62e7-3045-4fce-b5cf-35fe95b9c267"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("c38961a4-d23e-49be-bf09-0b9f2605c95e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("8bec5265-2be7-446d-91a6-a2b6cec42923"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("4f5393b0-314a-4c02-a294-2c4401c0205c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("483eb51d-1b7c-421a-931b-e59e111cadf3"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("0dc8151e-f94a-42ba-8a28-fda5db12212a"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("fb718431-aa2b-44c1-9d6f-96cf50b06552"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("cf054f37-cb44-45cf-8728-da02d25065ec"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("75cee602-820b-4237-9f87-4fd60d0886db"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("f74ca75b-21a9-4e09-8c7f-bbb0c0cdb7c5"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("29d02f96-6a7f-45b0-ab12-f9cd7dac0bec"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("e73fa192-104f-4e4f-83f9-69e36ac44e41"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("8081d93f-60f0-4521-8699-0a4285d5861c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("4b2bedb4-a2b7-4e14-9c88-2565cf7b12f4"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("a1bc31b4-5dbc-4e81-ab51-d0dc3dbf700d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("aabc6c40-f36b-432b-bd90-907657c3a419"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("40c49a76-5f11-4c50-8477-64ca33d7e79a"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("546e2ef7-679d-40df-b23d-771068763fc1"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("25d3c9f3-d205-48b0-b36f-93f46435ec57"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("bfdf19e0-777f-49e7-8197-d7f6562c156b"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("1e5c7abd-39c1-41d0-a2c1-e89653d41cf8"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("7886f331-b41b-4556-9c3f-9d9b70d8f090"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("52699d41-6993-4b47-87ba-2aa23299f5df"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("2df70803-eaeb-4af4-b51e-46a975b44088"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("17035891-3cfb-4c18-a76c-73dd45bd75be"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("97c841ac-4646-4f2a-ab98-8a3bf15c0397"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("bef624f9-502f-41a7-a745-62318f01b111"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 10,
                column: "Guid",
                value: new Guid("0c31e93c-ad43-4843-bc9a-575eea258123"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 11,
                column: "Guid",
                value: new Guid("55bde8d5-dbfe-462e-95a0-846b97cc12c1"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 12,
                column: "Guid",
                value: new Guid("41cee951-fcb6-4096-b4ed-42a0a806a696"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 13,
                column: "Guid",
                value: new Guid("cd1c8388-0848-4c71-850a-c4b58be5daf3"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 14,
                column: "Guid",
                value: new Guid("8ad27c40-3373-4f5c-8572-9f95a105dc56"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("f3e82bc7-5230-4e4a-84d4-166e32021764"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("0e4eb48d-90b3-4bed-8068-d54a921042b7"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "TvSerie");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "TranscodingProcess");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "TranscoderSettings");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "MediaServer");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "CatalogDetail");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Catalog");
        }
    }
}
