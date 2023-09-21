using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _210920234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "Guid", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, new Guid("d46fbdb0-8f00-41e9-845a-4bad409c5e97"), null, null, "Estado del Servidor Multimedia" },
                    { 2, null, null, null, new Guid("a4100363-0275-41d7-8a97-c4a1a87e829a"), null, null, "Tipos de contenido Multimedia " },
                    { 3, null, null, null, new Guid("e109c06d-7fb1-448c-a714-088d80ef0b06"), null, null, "Tipos de transmisión de Video" },
                    { 4, null, null, null, new Guid("c905c2b6-e5fe-428d-81a8-bae54cbfbef9"), null, null, "Preajuste del transcodificador" },
                    { 5, null, null, null, new Guid("7236395a-80d8-45d9-b3f7-4fdb734e8fd7"), null, null, "Tipo de Icono" },
                    { 6, null, null, null, new Guid("69778b46-afa9-4042-aae2-90e376a9affc"), null, null, "Proveedor de Cuenta Vinculada" }
                });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("1ac9f316-ee9b-4cec-a8b6-24cb0d9c7d83"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("74c145b0-7467-4603-a3f5-6c61a07e2003"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("c8bf90b7-d53e-45e0-bcc7-ebea358a1869"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("1391b529-c617-4326-8ffd-c2f8e2fbe7e8"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("a03f868c-d336-4303-87ad-004eb61486df"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("35f03671-bcb7-4717-9b23-28facd5a6392"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("dead4d3a-fa03-4f1f-9788-77d0ca4042b8"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("532049ac-529c-4005-b721-e1da0a692898"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("fb11172c-a222-4af7-adbd-706a9508d977"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("eb0d99d8-f99c-4d9a-abdb-75a0261ee8fb"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("52f1d7a1-2a85-4c08-a4cc-bb566bd26d61"));

            migrationBuilder.InsertData(
                table: "CatalogDetail",
                columns: new[] { "CatalogId", "Id", "Created", "CreatedBy", "Deleted", "Guid", "LastModified", "LastModifiedBy", "Name", "NumberValue", "TextValue" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, new Guid("3fc804e7-29d6-413a-9c78-e4bce624672a"), null, null, "Iniciado", null, null },
                    { 1, 2, null, null, null, new Guid("d828371b-a1ff-4c53-a093-5b0daa2a3dce"), null, null, "Pausado", null, null },
                    { 2, 1, null, null, null, new Guid("d8c62b10-796b-49d2-828f-f52b95fd372d"), null, null, "Película", null, null },
                    { 2, 2, null, null, null, new Guid("470bbe9c-1d95-4334-8fff-416a8fcce1fc"), null, null, "Serie de TV", null, null },
                    { 3, 1, null, null, null, new Guid("88ae4a65-5e55-40c8-86fd-1023735e31b3"), null, null, "Normal", null, null },
                    { 3, 2, null, null, null, new Guid("7aa7c0fe-651d-4eae-b9bb-c3000de781d4"), null, null, "MPEG-DASH", null, null },
                    { 3, 3, null, null, null, new Guid("2c85db02-f550-4f84-bd60-cd24cc145a37"), null, null, "HLS", null, null },
                    { 4, 1, null, null, null, new Guid("4e277b6a-15f4-4a73-a1b1-08a1c779d39e"), null, null, "ultrafast", null, "ultrafast" },
                    { 4, 2, null, null, null, new Guid("efe6f359-5613-448f-9a1f-ba0d189a1f8d"), null, null, "superfast", null, "superfast" },
                    { 4, 3, null, null, null, new Guid("ae50b522-bca3-4132-9753-3e29126f9a6b"), null, null, "veryfast", null, "veryfast" },
                    { 4, 4, null, null, null, new Guid("40e7dc08-c4af-4314-a07b-8c23c4424b66"), null, null, "faster", null, "faster" },
                    { 4, 5, null, null, null, new Guid("8b3c3e3a-9ca1-499d-8910-5ad52aa23d99"), null, null, "fast", null, "fast" },
                    { 4, 6, null, null, null, new Guid("0b9b4ecd-a521-4874-83c4-ad463f39265d"), null, null, "medium", null, "medium" },
                    { 4, 7, null, null, null, new Guid("2d644e0e-0b8f-4bc3-a488-6beb2b5c7633"), null, null, "slow", null, "slow" },
                    { 4, 8, null, null, null, new Guid("ab7f6722-51b6-4b07-9cca-6b8038cb5bc6"), null, null, "slower", null, "slower" },
                    { 4, 9, null, null, null, new Guid("a87293df-8f0e-4760-898e-3df32b6fc449"), null, null, "veryslow", null, "veryslow" },
                    { 5, 1, null, null, null, new Guid("d108bbb3-178e-4bbf-b295-1fedde1d766e"), null, null, "Imagen", null, null },
                    { 5, 2, null, null, null, new Guid("e2f02432-b7bd-4c8a-b378-52baa5af22cd"), null, null, "Font Awesome", null, null },
                    { 6, 1, null, null, null, new Guid("c44f450e-9c94-4ee6-b546-82f3a688ba43"), null, null, "Google", null, null },
                    { 6, 2, null, null, null, new Guid("d5992ab1-9cae-4c45-a191-5e01bc5b055f"), null, null, "Facebook", null, null },
                    { 6, 3, null, null, null, new Guid("452fb444-609b-4b87-99b9-a567528cc137"), null, null, "Apple", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 });

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("f1b339d0-191e-4900-b5fb-592b3f4253c8"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("b971c9f9-e8c2-4afb-98a6-6d4ad33c0568"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("b824e73a-68ba-4dbf-9ffa-970b0abf9f69"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("f02f0544-4295-4aa9-aba9-d128ab2d7ff5"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("54eabf00-da04-40e3-a83f-ff8fac651ce4"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("c5a6828c-49b7-4ed9-9452-a670619b4d71"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("f4773027-9168-4b92-b65f-3c05f24f7283"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("f678cf8c-d870-45cb-8135-91ec9665dcc9"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("593c1722-da9f-407b-9de6-082fabd2a890"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("6b7a271f-1d2f-4b4f-b864-885d1df20d22"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("765476b1-fc4b-407e-914f-5a447b0fa881"));
        }
    }
}
