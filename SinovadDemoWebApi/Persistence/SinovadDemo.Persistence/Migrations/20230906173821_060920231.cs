using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _060920231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("030d0509-9c58-447d-944d-b69ef7cfd17c"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("6327158a-7477-4243-b2b8-ab2af7c340d2"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("133b662b-796f-4c37-aa29-3f51948dc750"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("1ab88d51-b5f8-4371-86fa-ee4eb97a49d1"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("6c12656f-83a0-4b66-b8d3-516128f44561"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("2eeb26ea-b6f5-4e69-a97b-cbf1c5a35901"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("0b1d300f-c434-42dc-abd5-57ceb0d224f4"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("e4f10aba-51a1-4889-883e-53f86e125b0b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("4ec33e27-9d09-49a0-a874-3e598bbd897c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("731224a2-0a41-484e-b70f-0b4d0348b8b0"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("0b4925f9-2ba1-4f89-b0da-84317ff338ab"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("82e32d59-a730-4297-9419-5a5d763b3e7d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("888579c6-e55c-438f-a681-07f961004b87"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("da58628c-2317-42f5-bee6-57d2195f68f5"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("02680ac4-a437-4d5a-9946-b38c4a8b0462"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("2911ffc2-90eb-4c1c-b940-2185ea2efadc"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("65501cbf-c095-4456-9481-6e904fd2410e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("7060df73-a438-4087-bc0b-abe7c06427a8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("66320350-9c2a-458d-aa0d-ca862c8ad0d2"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("8521e6ec-76ae-4c72-8584-e2411ea30841"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("3553bfc4-7476-4a7d-8eed-9fc4a5af5b59"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("325580ca-4a09-4465-8d2c-083d606038ee"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("7d0fb815-b9fe-4757-a5e1-9b5c66b8442b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("916e6081-52d8-4d61-b82f-5ce65c4f8717"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 1 },
                column: "Guid",
                value: new Guid("4005bf98-4bf2-429a-acd7-4bd0b2e7daaf"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 2 },
                column: "Guid",
                value: new Guid("d65765ab-264d-4a60-92f5-5a47cd9f5a72"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 3 },
                column: "Guid",
                value: new Guid("3495d521-6fe9-476b-9ec5-59fb0b4294a3"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("140a7de4-3f58-47cd-bb49-535d9b3b6723"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("3edd25ed-d9fb-4725-aab8-60ab4f0650b3"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("878a0a31-fdcd-4da6-a128-9d63fea2b8db"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("4a24b13b-b9c0-4528-abf3-b8a0b6135f7a"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("94f3f76e-ff63-488c-a527-511fc4f888d4"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Guid", "IconClass", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("85f9d4ec-b8f1-45c9-89bf-971783001e74"), "fa-solid fa-list-check", 1, "/manage/catalogs", 3, "Catálogos" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("d8464166-1fb6-4487-9c3c-7a1d42424c10"), "fa-solid fa-film", "/manage/movies", 1, "Peliculas" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("eccd961d-d58a-4841-a7f5-1e5559eb91de"), "fa-solid fa-tv", "/manage/tvseries", 2, "Series" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "Enabled", "Guid", "IconClass", "IconTypeCatalogDetailId", "IconTypeCatalogId", "IconUrl", "LastModified", "LastModifiedBy", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[] { 9, null, null, null, true, new Guid("4b6ec269-d1a2-40a3-bbd0-f08d867e403a"), "fa-solid fa-list-check", 2, 5, null, null, null, 2, "/manage/genres", 3, "Generos" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("b665b5e1-9e7c-45b4-b014-12cadb74c36c"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("f6419f8e-91ee-4472-b197-52c2c9adeaac"));

            migrationBuilder.InsertData(
                table: "RoleMenu",
                columns: new[] { "MenuId", "RoleId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { 9, 1, null, null, null, null },
                    { 9, 2, null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("9af17122-46b4-477a-a2ff-ea0bdfa575ce"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("18d38bc9-4c22-4175-aeb0-53c5113f4ea4"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("cbe7b289-55fb-4200-90c3-3a3a0b128e49"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("d3d658eb-e514-4e4d-bb66-986aba485596"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("8761fed3-10fd-44d8-ae01-b40994b22c2d"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("d83ab247-fb90-4d1b-b464-120b3cd46b8f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("658e058a-c1c7-4bb3-99e5-8323900071ab"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("d96255af-8068-42cc-b361-d35566b6a2d8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("11eeb57f-648f-4bff-ac77-1b555a35dfb3"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("29744dce-2aac-4e52-bcdc-e57d88298acb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("4d8c6856-f170-473b-8c4e-c1c63a658cbe"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("2a4db853-5131-4427-955d-10577899cf4c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("e389c042-cc56-4d15-8457-8045c5523784"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("ec63938c-3e86-4823-9160-56a10d8d8ff0"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("1c7f53c2-a94e-41ce-ac34-3fa998878a9e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("009fadb5-c872-4e7c-9b46-8efc0ce160d1"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("dd5653b1-2aff-4b01-9e7a-2a4f38d56ed7"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("17337910-0137-4ecb-bee9-f15d8163a733"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("58adb308-c4a4-410c-b5a3-99ef236e5df9"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("5bb90e88-bf03-40ea-8f80-6bca66b77a1e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("0590af7d-2b0f-482d-b5d3-a234b5e37900"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("c41307a6-8986-42bd-8594-80dc46c5e892"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("e96d6a5b-8be0-4f6d-9d84-a1dd7d0b2fce"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("e2035e03-4653-437f-9666-e46c2a838ec8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 1 },
                column: "Guid",
                value: new Guid("366eeb0e-d179-43f2-a128-bc9ea6dfbed6"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 2 },
                column: "Guid",
                value: new Guid("0794a1ad-0ed8-436e-b7bf-f90a124da233"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 3 },
                column: "Guid",
                value: new Guid("73d51406-ffb9-410c-8197-c53382088de0"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("aa58da67-a399-4871-9d04-957b8bb0e8b7"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("37e2938d-46c9-44e4-94c5-a76c5f65dcad"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("7e3259aa-cf50-4ded-b560-7530ee2e37c0"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("761a7120-0b7b-4a05-896c-05a035c59925"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("b50b7e08-bffa-40e4-8851-c69d7b11d9a9"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Guid", "IconClass", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("ff9feafa-ab4f-48df-9915-fbef57f540bf"), "fa-solid fa-film", 2, "/manage/movies", 1, "Peliculas" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("72c89632-92d9-4ac7-a924-d4285d8fe29a"), "fa-solid fa-tv", "/manage/tvseries", 2, "Series" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("f3277224-e5bf-449a-9c68-ee57ee0a35ef"), "fa-solid fa-list-check", "/manage/genres", 3, "Generos" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("883df9bd-604b-4f33-bb70-0fd285c1897e"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("a2aa1348-7043-4223-9e6f-f7d1cd434767"));

            migrationBuilder.InsertData(
                table: "RoleMenu",
                columns: new[] { "MenuId", "RoleId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { 6, 2, null, null, null, null });
        }
    }
}
