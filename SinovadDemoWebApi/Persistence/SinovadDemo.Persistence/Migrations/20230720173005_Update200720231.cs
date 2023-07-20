using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update200720231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Storage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MediaServer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "MediaServer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("1e04530b-2c87-4a72-bfec-69ec88c83c2b"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("49717048-6dc6-4ae9-b49b-83ddf3983d07"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("f4003706-a27d-4aa2-94b7-44ce3495ce05"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("4f8c29e3-fcd4-4698-9951-94f3f54c77d4"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("7cc9ce41-f572-443c-8d11-ec190178e4f0"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("93f658bc-1ea3-4e2f-849d-2a52c277764b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("db14e7d3-f9bc-4a03-b614-6dd2d1629a11"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("30122e9f-eac2-429e-b288-1c40189bb64e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("82f8ebca-d477-4ea4-8177-44be3487a699"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("6292d623-5c55-455a-ba40-692daacc9c03"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("157fb985-1f89-4eb8-bb77-1f23ae816628"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("7f267e48-b09c-452e-ae3c-e66204f381a4"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("c4f8af5c-94fd-4bbe-b8b4-b003e2826f71"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("bcca679d-8b17-4d7b-8c0e-9f7ed3260289"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("e6ce86cd-55e9-4911-b01d-5c5114f47854"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("b28719da-dcd4-4e74-b784-a8e890b20502"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("04cc19ae-b99e-41e1-9e82-19f67bdceb85"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("b6d7a75b-be9f-4d60-a87c-1079e13d0294"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("dacfe5cb-927d-4229-9621-6b959835d9be"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("92015f65-500c-4825-94fc-bbfc403a7313"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("f55786de-a81a-4a09-a826-b726f0fae564"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("ad88d64f-0895-44b7-9436-82d3186a9d11"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("909c6f94-e0b2-4da2-b519-1bcb158a2308"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("6f1ac03d-8868-4517-8e44-fdc190d450cf"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("088e6ab3-be19-46d0-9c7f-fec6a9de8745"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("ae5042e0-711a-48dd-8a8e-501179f14044"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("dedcbc42-a060-473f-a7da-181dc732c192"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("426c0060-759c-426d-bfd5-7e65aad34a3c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("3980da6e-0efe-45d3-bb02-753ec37db3f3"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("c2139523-6952-44ef-8f59-e0d0e1e470db"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("983470f4-e8ba-4e1b-9c14-351d7d78e2aa"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("58f6cb12-b526-4045-bbe8-d6a97ad08883"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 10,
                column: "Guid",
                value: new Guid("b3582573-4b4d-4a42-9a58-9ff238b56c2c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 11,
                column: "Guid",
                value: new Guid("de78d687-36e9-4aed-b0af-528effa04d02"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 12,
                column: "Guid",
                value: new Guid("c1429eb4-5f73-466e-82eb-5a02afcc3606"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 13,
                column: "Guid",
                value: new Guid("477254fc-ecff-4b83-acdf-b5c5e378d393"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 14,
                column: "Guid",
                value: new Guid("2ecf74bd-5580-4077-9720-ac4a9086a64b"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("cc468b18-0d79-4b33-9d70-39e1e15fc7d7"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("885a1372-a4a2-458f-85cb-57deaf792c7a"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MediaServer");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "MediaServer");

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
    }
}
