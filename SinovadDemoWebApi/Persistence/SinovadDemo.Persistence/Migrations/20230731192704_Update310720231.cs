using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update310720231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("15ac8fcb-9b6c-4d45-bf55-6e56b46f025e"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("6936ac08-f8b3-46a2-a46b-551f5aa5da20"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("5f01d0ee-230a-4ab6-a3cd-99e471e8212a"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("b8aec97b-0908-4d97-9dca-6d7478d47c7c"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("579abec6-8097-4aaa-970f-7d9f7f46734c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("137591a1-c308-42f2-8720-07f4df20fb80"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("07de3904-cfe7-47f5-9d5d-daf26e7b5568"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("74247328-1118-47c9-9a9d-fa33fa55d164"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("84e2326a-4f72-4167-8487-544e47a764e8"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("c6b28446-166a-45ce-a9a3-4ca4615a4ead"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("fb33af10-96aa-41d9-bfef-abbaa0a7e513"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("c2b35fae-6747-46e4-b9d6-bf866c31b985"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("1e86e814-ef4a-4c98-b212-25bd59a67bdf"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("3b8437ee-f12f-4a12-80c3-3a6f868415cc"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("a2566b20-3647-4225-b124-fb717359942b"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("eda1d59f-47b9-4097-83d9-b950466c58e9"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("9a305819-a323-4f52-89f5-d092050f4264"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("20d01ca1-04cd-4f59-8d06-3caae335f043"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("197ef214-6d53-4ab7-a6d2-c1773c647830"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("e8913d59-6c6b-4043-b7da-087e469de3f7"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("5e92d6ec-a437-49bd-a3ba-e3189fa5650f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("5294bb4b-43a1-4b4f-844d-0c4100525cc3"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("ad045acb-211f-440a-947e-9a95bdc4d3c3"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Guid", "Title" },
                values: new object[] { new Guid("bcd4e4d3-c53f-42a1-8b41-1f5c6cbc8395"), "Administrador" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Guid", "Title" },
                values: new object[] { new Guid("28d1131b-fbc1-43a9-82e5-57a7b219a82b"), "Media Stream Data Base" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Enabled", "Guid", "IconClass", "IconTypeCatalogDetailId", "IconTypeCatalogId", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[] { true, new Guid("436483f0-deba-406a-8913-91aae0a7342e"), "fa-solid fa-list-check", 2, 5, 1, "/role-list", 1, "Roles" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("46502a31-190d-4ebb-95a6-52bea3fbc00f"), "fa-solid fa-user", "/user-list", 2, "Usuarios" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("0c726943-9a78-4fc2-b461-9e64c9de6e0b"), "fa-solid fa-list-check", "/menu-list", 3, "Menu" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Guid", "IconClass", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("3b7625ff-48d3-4172-a5ae-6213518b752a"), "fa-solid fa-film", 2, "/movie-list", 1, "Peliculas" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("da989dc4-0e96-420b-897f-8aae6b474f86"), "fa-solid fa-tv", "/tvserie-list", 2, "Series" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("4fd87dcd-d67e-4b90-8932-fe76967eda31"), "fa-solid fa-list-check", "/genre-list", 3, "Generos" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Guid", "Name" },
                values: new object[] { new Guid("66504aef-9400-4f9c-ab1d-684de0e5d57f"), "Administrador Principal" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Guid", "Name" },
                values: new object[] { new Guid("d3cc8802-e2a8-4ffa-90d2-d289ed4ca8e7"), "Administrador de Medios" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Guid", "Title" },
                values: new object[] { new Guid("0a10e335-b830-46ea-be08-1430ce73e258"), "Media" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Guid", "Title" },
                values: new object[] { new Guid("1c5583d4-a310-4d11-b5f7-3c04986301fb"), "Almacenamiento" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Enabled", "Guid", "IconClass", "IconTypeCatalogDetailId", "IconTypeCatalogId", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[] { false, new Guid("55ccda43-1ee2-413a-89e6-a0d6064fa80d"), null, null, null, 0, null, 3, "Mantenimiento" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("984de055-77a3-43d8-a859-1f1dfd137d3f"), "fa-solid fa-house", "/home", 1, "Inicio" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("7bcb308a-39e1-42f3-a578-9fbdec14fabd"), "fa-solid fa-film", "/movies", 2, "Peliculas" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Guid", "IconClass", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("40cddb4d-b9b1-4bed-87fd-8827d49efaa8"), "fa-solid fa-tv", 1, "/tvseries", 3, "Series" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("52084db1-54e4-4ce1-8895-080c0fc99e2c"), "fa-solid fa-database", "/storages", 1, "Almacenamiento" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Guid", "IconClass", "Path", "SortOrder", "Title" },
                values: new object[] { new Guid("151b2cef-1161-474e-aa83-8f371e6f5cd7"), "fa-solid fa-database", "/transcoder", 2, "Transcodificacion" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "Enabled", "Guid", "IconClass", "IconTypeCatalogDetailId", "IconTypeCatalogId", "IconUrl", "LastModified", "LastModifiedBy", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[,]
                {
                    { 9, null, null, null, true, new Guid("3e0eaf3f-d6c4-48fc-a6d2-1e0a98227ca9"), "fa-solid fa-film", 2, 5, null, null, null, 3, "/movie-list", 5, "Peliculas" },
                    { 10, null, null, null, true, new Guid("5fbce551-4034-4457-8e8f-389f044fa878"), "fa-solid fa-tv", 2, 5, null, null, null, 3, "/tvserie-list", 6, "Series" },
                    { 11, null, null, null, true, new Guid("aae42be3-eedf-4e05-b561-d4157c43dddd"), "fa-solid fa-list-check", 2, 5, null, null, null, 3, "/genre-list", 4, "Generos" },
                    { 12, null, null, null, true, new Guid("fe94f3e6-0743-4e7a-9c77-fc066ffb677e"), "fa-solid fa-list-check", 2, 5, null, null, null, 3, "/role-list", 3, "Roles" },
                    { 13, null, null, null, true, new Guid("c5a7c44a-9e88-4624-858e-8563a3ed642a"), "fa-solid fa-user", 2, 5, null, null, null, 3, "/user-list", 2, "Usuarios" },
                    { 14, null, null, null, true, new Guid("378c81d2-7613-45d5-8839-31bff4191f1e"), "fa-solid fa-list-check", 2, 5, null, null, null, 3, "/menu-list", 1, "Menu" }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Guid", "Name" },
                values: new object[] { new Guid("4aa23f7c-79c5-4444-b798-c643acdee46c"), "Administrador" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Guid", "Name" },
                values: new object[] { new Guid("7ae9550f-ff90-4f95-ae6b-76ed9335f2eb"), "Registrado" });

            migrationBuilder.InsertData(
                table: "RoleMenu",
                columns: new[] { "MenuId", "RoleId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, 2, null, null, null, null },
                    { 4, 2, null, null, null, null },
                    { 5, 2, null, null, null, null },
                    { 9, 1, null, null, null, null },
                    { 10, 1, null, null, null, null },
                    { 11, 1, null, null, null, null },
                    { 12, 1, null, null, null, null },
                    { 13, 1, null, null, null, null },
                    { 14, 1, null, null, null, null }
                });
        }
    }
}
