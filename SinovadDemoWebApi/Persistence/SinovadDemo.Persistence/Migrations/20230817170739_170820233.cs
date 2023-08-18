using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _170820233 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LinkedAccountTypeCatalogId",
                table: "LinkedAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LinkedAccountTypeCatalogDetailId",
                table: "LinkedAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("f4915287-faa5-4238-96e7-8ce2e4a2f26c"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("93b4e7f4-7a8c-400c-9a13-58b29bf64091"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("32060e41-77c5-41e5-b444-207b74328d16"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("c9118d6f-0a1f-481e-b6f5-468f0c166eb4"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("b2e0d861-34a9-4bc0-a6db-6e9fe7260448"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("418f5320-55ce-4b61-ada2-a053c946621b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("759170ad-9bbb-44b0-a86e-e17cdf21fca4"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("ff91af5e-24b2-4e60-aa72-cf263ff8d8a1"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("1daded7f-cd3e-49de-bb98-4154584ce2a6"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("814edefa-89f6-4012-8936-e085dc111724"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("f79ef84e-9108-4cbd-bde0-73396426cdf8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("9dd193ff-7e11-4034-b398-3149696895e1"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("a531d5d8-1365-45a9-ac74-e7e57a5fc723"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("7aec02fd-6f8d-4960-a4d9-0dfc242df9fb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("d2bb7efc-6b09-4ba6-9cc0-b2a444f9ee8c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("7e862346-d31e-41f1-ac29-df8e775b23ce"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("5535790d-e2d6-4cf7-8182-4793dc5e7224"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("bf5d5010-a20f-4cc8-ba16-28d7c9acb4dd"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("45583bb8-fe48-4711-a372-2863ad3bdda8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("d1248d7a-a056-4efb-86a6-8c26c8b2b979"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("bd641fdf-d549-44e2-bbdd-30aee0623a49"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("5842420d-0ca9-4d2f-81fd-81736c72790c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("ddc3dd39-ffa4-42c5-84e2-614ef19c63f4"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("e956fe50-27e9-4a1e-8500-b8435bad8769"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 1 },
                column: "Guid",
                value: new Guid("f18ef695-4d7d-4fd3-acd7-f1b5f3c19af8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 2 },
                column: "Guid",
                value: new Guid("4ec28411-35cb-4d9e-bec6-2c33676b501b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 3 },
                column: "Guid",
                value: new Guid("07d37b49-dab1-4288-ab8d-dda2766aa714"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("6200cfa5-3e2d-40c1-a147-3c9be6321ab9"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("b13f8eca-4251-4b69-9a2d-276bb09aadb7"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("d93f48e9-5770-4865-a0dd-d7aa3771d6ee"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("256b8adb-02b3-4967-8e97-efce8fc61223"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("5ffbbd47-b49c-4b2b-8ed2-8fecac717975"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("941b77be-5b31-4a13-ac0d-761fc6998755"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("c7d033eb-1b81-4be2-9294-0c5b25d35c5c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("79205ca7-33c8-4a7e-ae85-312c05f7e13b"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("9d802a65-5f62-4c56-8527-e2fc5b9cd5f8"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("d8210d29-28ac-47c2-95d4-f71e0f346cd3"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LinkedAccountTypeCatalogId",
                table: "LinkedAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LinkedAccountTypeCatalogDetailId",
                table: "LinkedAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
