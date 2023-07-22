using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update220720232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FamilyName",
                table: "MediaServer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("b6b03f21-cb73-4156-a58d-4b109306a826"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("973fbd7c-c687-4d33-a77a-a8ebf50181b7"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("55dc7649-144c-4931-8e65-f0608fcb110d"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("49a193e7-437f-4d00-ab4c-5b20a2581a25"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("9bc1c152-0d1b-4ee5-83eb-e32d680f7a5d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("6e7e3e5c-1a23-4535-9c48-9128bd69c838"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("18d84c55-3c95-4482-bf56-dcc6f2787bd8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("2bc96452-5fd8-4a0d-806a-64d40b7bc9be"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("457e0f5d-be5a-4161-bd34-5801d3f37ca2"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("9277edd3-eb4a-4286-a835-0f2e786c8571"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("28de8cf1-d9b2-47b5-a1b3-74eb69563e35"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("ddd76eac-a961-43d3-a96b-00c883f62554"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("ae2114a2-b8d6-49ab-a763-fea5127522b5"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("b8216f53-b647-47c7-baf0-2f6e08dbe521"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("11171add-78d3-4bdf-90d8-a70401995ffe"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("6042372c-9549-40bf-9244-7574da0c09d0"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("c2688654-8ec4-4cb6-b936-5197e3c7db09"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("165328f1-e69d-4309-bd0b-9d4a72580135"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("4f228d30-234a-4144-b872-71744a46c796"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("d26181dc-147c-48c8-8be2-1f1f4745413e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("e93514bf-7ed3-4bcd-912b-ac270dbb41aa"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("142acd5a-8b53-405c-a838-bdb774391305"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("6d2d5dae-51c5-4267-8cee-2b7f97116e8e"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("0a10e335-b830-46ea-be08-1430ce73e258"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("1c5583d4-a310-4d11-b5f7-3c04986301fb"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("55ccda43-1ee2-413a-89e6-a0d6064fa80d"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("984de055-77a3-43d8-a859-1f1dfd137d3f"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("7bcb308a-39e1-42f3-a578-9fbdec14fabd"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("40cddb4d-b9b1-4bed-87fd-8827d49efaa8"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("52084db1-54e4-4ce1-8895-080c0fc99e2c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("151b2cef-1161-474e-aa83-8f371e6f5cd7"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("3e0eaf3f-d6c4-48fc-a6d2-1e0a98227ca9"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 10,
                column: "Guid",
                value: new Guid("5fbce551-4034-4457-8e8f-389f044fa878"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 11,
                column: "Guid",
                value: new Guid("aae42be3-eedf-4e05-b561-d4157c43dddd"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 12,
                column: "Guid",
                value: new Guid("fe94f3e6-0743-4e7a-9c77-fc066ffb677e"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 13,
                column: "Guid",
                value: new Guid("c5a7c44a-9e88-4624-858e-8563a3ed642a"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 14,
                column: "Guid",
                value: new Guid("378c81d2-7613-45d5-8839-31bff4191f1e"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("4aa23f7c-79c5-4444-b798-c643acdee46c"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("7ae9550f-ff90-4f95-ae6b-76ed9335f2eb"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FamilyName",
                table: "MediaServer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("4eff010c-1be5-4d32-85b0-e57e69ae9ad1"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("49d70579-7ed4-4a06-893e-a333e7fb29fb"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("d1685812-1c71-476e-bd93-41fccb7be8e2"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("37006dca-7e76-4449-8009-eb86089de0eb"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("c324d027-6d1a-4e7c-a4b0-114615609a9f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("87dd9826-98a1-435b-b8ea-62ac4d093a6d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("2691242c-36f1-4025-a3d4-ffcd97ad3b06"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("3e6bd150-a0d5-46e5-9c86-d709fad583b9"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("05a76edf-12a0-4514-8399-8c7af92caa60"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("9bded78a-35a5-4152-a232-cf0451d91ba9"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("a6a1e266-80ac-46e5-bffe-3a3a7bc36f11"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("8b3bf34a-1441-45a4-9709-f2d30ba90d96"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("58c4697d-015a-498c-91be-3e95bc34d2d3"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("c126f8cd-749c-427d-ba93-763c34efdcfb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("b8843133-1a6b-429f-9840-e5c43575e8f7"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("595548da-a4ef-4b35-804c-297083d4f56b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("b6f0a401-c5e3-4895-8fd0-80290a8a5da6"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("7464bacd-9ca3-4e1c-97a7-6d3ecd1089a6"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("dc72c960-61be-4b62-aa69-f143b71d4e05"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("9c25e6c8-5ab2-4279-9a8f-5c75d52bb916"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("9a4808b4-355e-4f3e-b4bf-49046195742f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("0ab438df-ffcb-4f09-a1c1-16b998f11874"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("56405f7c-2f93-4583-9ee1-7a38119a9384"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("9ab69fe5-d632-41c8-8304-8c212318ff0c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("ea78ff9c-0db9-495e-923e-b68bbd659c3c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("067fb782-41af-4ff6-9fdc-ff43f884ec7d"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("2f83f452-2de9-426a-919a-fdc5dc94d1f7"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("16a5ba1d-45eb-417c-a428-718abc605714"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("28fa2ade-efb3-4350-bbd5-5185891be231"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("6355805b-5485-461f-b48a-fc0dea577c09"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("93cd3dac-11fc-4074-9c1a-af3eb05791ee"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("6f2d806a-6550-4439-8fb0-73f775b16879"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 10,
                column: "Guid",
                value: new Guid("fcbd3e7b-3fab-425a-9ece-8a1e598e4fd4"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 11,
                column: "Guid",
                value: new Guid("3bc9fa4a-b932-447c-9c75-c162d17453c1"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 12,
                column: "Guid",
                value: new Guid("c8d62935-a736-45f6-a9f1-0736509a02e9"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 13,
                column: "Guid",
                value: new Guid("d91a8adc-7523-4dc8-b8dc-de3567e660bd"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 14,
                column: "Guid",
                value: new Guid("5ef356c7-e3b1-4300-986f-3738e7c5ae3d"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("8933a543-9be6-463b-9e47-9c96c89b1ff6"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("965a419d-ece6-4a93-8e3a-672620de82f7"));
        }
    }
}
