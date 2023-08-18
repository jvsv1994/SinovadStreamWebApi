using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _170820232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdToken",
                table: "LinkedAccount");

            migrationBuilder.RenameColumn(
                name: "LinkedAccountTypeCatalodId",
                table: "LinkedAccount",
                newName: "LinkedAccountTypeCatalogId");

            migrationBuilder.RenameColumn(
                name: "LinkedAccountTypeCatalodDetailId",
                table: "LinkedAccount",
                newName: "LinkedAccountTypeCatalogDetailId");

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("cb9e7875-16de-4a6c-853a-316fe961d100"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("2ac21f1b-dfbb-4bea-94ca-39227cd46acb"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("5478d4af-e7b2-4fef-ad9d-623061f2be4e"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("2cf33662-b1ed-4d21-8d81-130af7d67446"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("64688ce0-6271-4f9f-a4c2-501556befe33"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("450ecf02-3df0-420b-b64e-4af3f7318e71"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("decb1efb-8672-42f3-8343-97f96980ebc5"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("106baeb0-c8db-4cda-b02c-25c3c3550470"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("ba40adab-2c96-43f4-8f23-e60d7a78dc4c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("148c92a7-3628-4e4d-aaa8-1a4b4b22f76b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("94f83734-022c-470e-b2ea-29095e679dd7"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("53e2e951-cf87-490e-b7c9-3ae3a45b5cf0"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("06ff0c1e-3f6a-4d50-b5de-ede2d224eb1c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("ac9cf7eb-4151-4700-8ccc-d2456140f2eb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("95643227-895b-4c8a-b0af-f37cd5f0fba7"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("52b0fad1-ef5f-4b8c-8a06-04c2768e6b41"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("69ae6368-4615-4ce3-a8e8-b59408ee7996"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("71f9f215-f8c7-481f-a5b4-03dc27c1efae"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("ad81aa89-1956-4b50-9947-84dc3c67cc70"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("c57562ce-8fcd-49aa-b17d-247d6a811b63"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("b8229599-1a2c-4b30-8e7f-0628254f2b7f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("b9c9b08d-6387-464d-acfa-9f40b75098c3"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("ddc12cde-c230-489f-ab23-7d5814a40d4f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("a501837b-5f13-450a-aab0-8740f01fdb2a"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 1 },
                column: "Guid",
                value: new Guid("34d37fb3-ee4e-46f4-a599-515c712e5e79"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 2 },
                column: "Guid",
                value: new Guid("6b4ed960-5b82-49e0-9c8d-3cddafe20d17"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 3 },
                column: "Guid",
                value: new Guid("fc3ad82f-1cfd-4da8-9d83-d145f1b595aa"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("c0c51d5b-d720-4e69-81fb-caf2e35ec1f1"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("ec28a69e-ea0b-436d-a39c-9f1879bc23a6"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("1045ec6d-ff83-461d-857b-33b1be03901f"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("d0a2a3a3-4bfc-4510-a015-c02c4e5161d8"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("350d6777-7411-4de3-a250-463b6f960019"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("ac36ab75-f680-4002-880f-52b506d5ea8e"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("a215bf4b-84e2-4a36-a3ca-afe8c01b0257"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("86c65d2b-5bcf-430f-a53b-01b1e8e64646"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("caf1897a-055e-4ef0-802d-cff8c85bde95"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("c22be4b2-a2b5-4c55-8a9d-28852e5f6d0d"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkedAccountTypeCatalogId",
                table: "LinkedAccount",
                newName: "LinkedAccountTypeCatalodId");

            migrationBuilder.RenameColumn(
                name: "LinkedAccountTypeCatalogDetailId",
                table: "LinkedAccount",
                newName: "LinkedAccountTypeCatalodDetailId");

            migrationBuilder.AddColumn<string>(
                name: "IdToken",
                table: "LinkedAccount",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("f711044e-4039-4962-bfd3-6be2097adb87"));

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
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 1 },
                column: "Guid",
                value: new Guid("c3650018-1664-4cd0-a896-15e734eb68e9"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 2 },
                column: "Guid",
                value: new Guid("7c07e311-13c6-46d3-8629-58ce11c02191"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 3 },
                column: "Guid",
                value: new Guid("3a205464-62ea-4339-bf2c-d5cbffe47875"));

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
        }
    }
}
