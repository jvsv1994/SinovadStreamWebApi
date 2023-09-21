using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _2109202310 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Catalog__3214EC275C8D2947", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CatalogId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    TextValue = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    NumberValue = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CatalogD__5C6FE914EF292CEC", x => new { x.CatalogId, x.Id });
                    table.ForeignKey(
                        name: "FK_CatalogDetail_Catalog_ID",
                        column: x => x.CatalogId,
                        principalTable: "Catalog",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "Guid", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, new Guid("5b73440a-386d-489e-80ed-569e8af04570"), null, null, "Estado del Servidor Multimedia" },
                    { 2, null, null, null, new Guid("e29dd52b-e3ac-4dfb-9277-e230d5e30334"), null, null, "Tipos de contenido Multimedia " },
                    { 3, null, null, null, new Guid("c7e8e5c4-73cb-49cc-b487-3c7a1fee55f2"), null, null, "Tipos de transmisión de Video" },
                    { 4, null, null, null, new Guid("91d1a5f1-a9bc-4773-a409-565cacbf8fdd"), null, null, "Preajuste del transcodificador" },
                    { 5, null, null, null, new Guid("65973080-8be1-4ac1-861d-859c430922df"), null, null, "Tipo de Icono" },
                    { 6, null, null, null, new Guid("9e68de07-52b6-4c58-935c-f932597d930d"), null, null, "Proveedor de Cuenta Vinculada" }
                });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("ea0d98e0-6427-4120-a36d-c26bb65ba10c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("cef3e7ca-a7c1-49b9-b17a-5296ab4169c0"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("cfceb485-9777-4504-bc6c-6491f789c331"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("8a9d38c6-2cbd-44e0-bfc4-145c736cb790"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("36acef39-bb56-4505-a728-2c075cbb8d6b"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("b4790f32-11a7-48d9-8061-ad7774371c9d"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("8f520cd4-1c03-4126-b683-6462a236c200"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("fa7d7a1e-11cb-491c-8e6c-7a23fb29a01c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("af184747-21da-4ca0-9123-bc79405146a2"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("bbefd4df-bb0d-4a44-aa0b-4a50b539aab6"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("91599c34-6020-4d2b-a79e-9d4b8705df52"));

            migrationBuilder.InsertData(
                table: "CatalogDetail",
                columns: new[] { "CatalogId", "Id", "Created", "CreatedBy", "Deleted", "Guid", "LastModified", "LastModifiedBy", "Name", "NumberValue", "TextValue" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, new Guid("b3b13597-b505-488e-bbcf-6ed2b6eda370"), null, null, "Iniciado", null, null },
                    { 1, 2, null, null, null, new Guid("41449408-a56f-4184-8994-9198a90d41c0"), null, null, "Pausado", null, null },
                    { 2, 1, null, null, null, new Guid("68dbf77e-926f-4fd1-8df5-9e66bcaa3fb7"), null, null, "Película", null, null },
                    { 2, 2, null, null, null, new Guid("f5c0db6e-1f67-4e9c-9480-426ebd6d7ea6"), null, null, "Serie de TV", null, null },
                    { 3, 1, null, null, null, new Guid("29f6245f-8ef2-4220-98c0-e9ded16b8feb"), null, null, "Normal", null, null },
                    { 3, 2, null, null, null, new Guid("e12b63de-0554-416e-a886-4a21e66f73ec"), null, null, "MPEG-DASH", null, null },
                    { 3, 3, null, null, null, new Guid("8b4d1871-2979-456f-abdc-c79b9e4d349d"), null, null, "HLS", null, null },
                    { 4, 1, null, null, null, new Guid("77489236-9339-4689-a1e5-e754f6275169"), null, null, "ultrafast", null, "ultrafast" },
                    { 4, 2, null, null, null, new Guid("cc9f19f6-b30d-449a-9947-bf02525fa3c9"), null, null, "superfast", null, "superfast" },
                    { 4, 3, null, null, null, new Guid("a53a45b8-12e2-472f-b120-96cb3418c257"), null, null, "veryfast", null, "veryfast" },
                    { 4, 4, null, null, null, new Guid("212d64ea-85a2-4f56-af6a-3bcb6dabccbb"), null, null, "faster", null, "faster" },
                    { 4, 5, null, null, null, new Guid("f6dc5504-5e00-424f-97a9-076255de384e"), null, null, "fast", null, "fast" },
                    { 4, 6, null, null, null, new Guid("4317fcd9-cbb5-4d56-9306-93816bf880fa"), null, null, "medium", null, "medium" },
                    { 4, 7, null, null, null, new Guid("3fcb64e6-6aee-48e7-b3ce-9767fb0631fc"), null, null, "slow", null, "slow" },
                    { 4, 8, null, null, null, new Guid("8e7f3773-0dac-445d-b245-7959f1299074"), null, null, "slower", null, "slower" },
                    { 4, 9, null, null, null, new Guid("2a93c4e9-a2d0-46e1-a0a4-cd533afc780c"), null, null, "veryslow", null, "veryslow" },
                    { 5, 1, null, null, null, new Guid("0a78390e-aa38-4958-8614-e4b79706ef5f"), null, null, "Imagen", null, null },
                    { 5, 2, null, null, null, new Guid("0350871b-dc25-4867-a88d-f889a1c4c1fb"), null, null, "Font Awesome", null, null },
                    { 6, 1, null, null, null, new Guid("f78da0f4-296e-4989-b79e-3247e295d5b4"), null, null, "Google", null, null },
                    { 6, 2, null, null, null, new Guid("0f2cbb7e-486b-43ae-a3db-917c3f375c3c"), null, null, "Facebook", null, null },
                    { 6, 3, null, null, null, new Guid("bc74bd69-e2fb-4ccf-b1ae-893e6ddc20ce"), null, null, "Apple", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogDetail");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("28478a69-eb23-498f-b661-48f807ef4051"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("727bb71d-ad89-4662-8688-54737ef68f9a"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("af6949e3-918b-4676-a939-baa1c2eb0fc0"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("56dde2be-afa0-407d-a1e4-cdf012982581"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("a16480a6-750c-4084-a243-cfbdb588ddda"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("1b0941ad-d2cb-4942-b0de-97399cb52269"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("a7ceee7a-44c6-47d8-911c-2486ec90f6d2"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("071c8cf0-aa64-4699-bef7-5c0240086b08"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("6a9c2a6d-5532-4a48-8b8e-f4f6e8aba056"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("3bd5783f-b0e1-4482-be21-bf5a0a812432"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("3d7441c8-56f7-4e95-b26f-6fa8176f3a78"));
        }
    }
}
