using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update200720232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MediaServer",
                newName: "FamilyName");

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "MediaServer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("f78cf970-7c47-4260-abed-0ab61931c0cf"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("33a7bc3b-3523-4fed-b7d2-a107943cb459"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("c5b0eb56-5ede-46ca-a286-6a9cecb37048"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("c94b93f2-7688-4808-ab53-f52c4a4bb7d9"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("542b5ac6-d3ec-4465-81d3-1202a3bb3529"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("9e3c6527-0d19-41fa-9d15-11afd7cb4b6d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("a5179b41-1989-43ff-b70c-a798bb6b57f4"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("b86ec780-9001-47a8-83f4-18cd6e836e2f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("cf63d507-5a04-4fa1-90b3-d788ebc52b7f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("58270862-ae91-45a8-a4eb-3cbfe2cbf07a"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("93ba6d99-9c5d-4277-aa9d-4dc879df4c92"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("472897cf-5688-4f83-9635-333b2905f94b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("234dd12f-cdb6-4f29-bdb1-38403484e705"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("0e8402a5-63a5-48da-896b-50d5619b86f9"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("8801b89d-fa95-447a-a7c0-b739c6e4c0ac"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("75aa8d10-e1d9-4b9c-a291-0b2959d494c6"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("3d1ebab0-51f4-4472-b656-dc0778b07a3a"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("5607ef7e-8034-42ef-a81b-bae8b75753ec"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("a03a0500-6a36-45de-9990-bf9c69ce6872"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("d6936fca-470e-4e7e-a551-3bcc086cf05d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("bdd06f81-294b-4b19-9cc3-4cecf9c3d27e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("057065e3-f59a-4dd2-b3c8-0445f5ee24c2"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("4f3209cf-e64c-4b32-8266-b77fc6dbdc51"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("c935ba56-b824-4ac2-9977-d58ef439eba0"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("f3097933-94a5-4765-b97c-b89aa9a4c908"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("ba7ef023-c3cf-42f5-861d-1b48037d186c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("203db5e5-1013-4118-bf7e-bba79c3e2220"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("4ca90f32-0266-4c82-89a7-ddfe1cab2c7a"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("668a115f-86ed-4eb0-a15e-8adad9914b01"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("b32e8394-493a-4db2-b3e4-6d5a9895f4c6"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("3e7f81cc-0b79-4fc1-94e6-4e1b68d3ae0b"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("c7afa879-18cf-485d-a5cb-0d1608e20790"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 10,
                column: "Guid",
                value: new Guid("fd73fc82-fc45-4046-9c1f-e5f30a8102a4"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 11,
                column: "Guid",
                value: new Guid("5b79d22f-af92-4937-9fb5-78742731fc4f"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 12,
                column: "Guid",
                value: new Guid("45325ddf-ea84-4bd6-bf6c-ce8521cceed1"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 13,
                column: "Guid",
                value: new Guid("be7aa772-0182-4beb-9718-839d17293765"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 14,
                column: "Guid",
                value: new Guid("cfd51490-6b1e-4faa-9036-a0167f70014f"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("977fa132-543e-4112-83fa-0a66037f3211"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("c72fdbe8-3777-4f46-9b37-7ffbdfaf7bde"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "MediaServer");

            migrationBuilder.RenameColumn(
                name: "FamilyName",
                table: "MediaServer",
                newName: "Name");

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
    }
}
