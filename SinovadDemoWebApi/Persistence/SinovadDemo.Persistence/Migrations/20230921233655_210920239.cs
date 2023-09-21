using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _210920239 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Catalog__3214EC275C8D2947", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogDetail",
                columns: table => new
                {
                    CatalogId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    NumberValue = table.Column<int>(type: "int", nullable: true),
                    TextValue = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
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
                    { 1, null, null, null, new Guid("558713c6-cfa3-45db-b566-4f11f15bfd9f"), null, null, "Estado del Servidor Multimedia" },
                    { 2, null, null, null, new Guid("3c2e2adf-b85a-485d-8db8-1bd0e970b572"), null, null, "Tipos de contenido Multimedia " },
                    { 3, null, null, null, new Guid("4693954c-8aab-402b-8218-51b3c44d5153"), null, null, "Tipos de transmisión de Video" },
                    { 4, null, null, null, new Guid("ce95e24b-1739-466c-a7ef-73688331c37c"), null, null, "Preajuste del transcodificador" },
                    { 5, null, null, null, new Guid("40b124f2-f433-42b8-84aa-4a1ffdc16a28"), null, null, "Tipo de Icono" },
                    { 6, null, null, null, new Guid("0ef08890-847a-4011-a92c-539da572407c"), null, null, "Proveedor de Cuenta Vinculada" }
                });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("ad6448ee-fb1d-4ec3-a6d4-8e773c31ad73"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("e5464c85-0a1a-40ea-81de-089a458a4fb9"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("256ba963-9f2c-4bbe-89ac-f3a6d1fffe26"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("c182dc7b-f133-4faf-bf7d-bf7f19f7bcfc"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("4bd35a17-9c56-41cc-b47b-79580b6484a4"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("e66665a1-3356-4a43-bd19-98c871c0caa0"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("9dfe1c4c-f841-461e-90d8-dcd63a255772"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("2a02bbe7-d3fa-4fb5-a3ec-d9f80f8361ed"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("b02c71be-755f-4128-a4bc-f48e5e8903f4"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("45ca4ec2-72ff-4070-8268-adb94541f8bd"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("2b416365-cefa-4aee-86d6-081a317d3640"));

            migrationBuilder.InsertData(
                table: "CatalogDetail",
                columns: new[] { "CatalogId", "Id", "Created", "CreatedBy", "Deleted", "Guid", "LastModified", "LastModifiedBy", "Name", "NumberValue", "TextValue" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, new Guid("e7c2100a-c495-4505-accb-5e2db217712a"), null, null, "Iniciado", null, null },
                    { 1, 2, null, null, null, new Guid("859a8805-9471-4e9f-850d-7deb6eb482cc"), null, null, "Pausado", null, null },
                    { 2, 1, null, null, null, new Guid("6eaf9d58-5ed2-40ef-b044-619525ce55b4"), null, null, "Película", null, null },
                    { 2, 2, null, null, null, new Guid("87286761-54cd-4aef-89e1-44443684e840"), null, null, "Serie de TV", null, null },
                    { 3, 1, null, null, null, new Guid("e16c9852-19ba-4bff-81f0-23f35845dd1a"), null, null, "Normal", null, null },
                    { 3, 2, null, null, null, new Guid("dcb19613-df7e-47e2-8568-c2e4a6e1e4cc"), null, null, "MPEG-DASH", null, null },
                    { 3, 3, null, null, null, new Guid("029994b6-cf48-49e4-80d9-a05310ad392e"), null, null, "HLS", null, null },
                    { 4, 1, null, null, null, new Guid("b2a3c6e7-21cd-4100-915b-e0a6d844f008"), null, null, "ultrafast", null, "ultrafast" },
                    { 4, 2, null, null, null, new Guid("31be5293-d7fb-446d-a26c-4d6b8e56ab15"), null, null, "superfast", null, "superfast" },
                    { 4, 3, null, null, null, new Guid("08efcfac-b0ae-45dc-919c-acb61ac7d0cc"), null, null, "veryfast", null, "veryfast" },
                    { 4, 4, null, null, null, new Guid("48153094-feec-44f7-9032-7498ad44a33d"), null, null, "faster", null, "faster" },
                    { 4, 5, null, null, null, new Guid("0cd4f977-3fe2-47fe-b14c-11b87e08ecfc"), null, null, "fast", null, "fast" },
                    { 4, 6, null, null, null, new Guid("5f796450-ced0-4261-a222-8d9620886944"), null, null, "medium", null, "medium" },
                    { 4, 7, null, null, null, new Guid("c984c3f5-3a27-49a5-b75a-fb58719a6d9f"), null, null, "slow", null, "slow" },
                    { 4, 8, null, null, null, new Guid("db869f67-0612-4dc4-94ce-2f21c07ca579"), null, null, "slower", null, "slower" },
                    { 4, 9, null, null, null, new Guid("a85e0295-6b2a-4597-b3e8-562d4f1134bb"), null, null, "veryslow", null, "veryslow" },
                    { 5, 1, null, null, null, new Guid("2b8d3411-d2f4-46e6-b324-0a1acddcd1c4"), null, null, "Imagen", null, null },
                    { 5, 2, null, null, null, new Guid("89f622de-8e7a-4333-94a2-f8948834d3d2"), null, null, "Font Awesome", null, null },
                    { 6, 1, null, null, null, new Guid("9870647f-7e6e-4038-8580-7f6c8a8bd97b"), null, null, "Google", null, null },
                    { 6, 2, null, null, null, new Guid("0ea172bd-8bf5-409c-b9d5-5e3be488c41b"), null, null, "Facebook", null, null },
                    { 6, 3, null, null, null, new Guid("5160f3e1-3750-4292-91c6-6023b9188dad"), null, null, "Apple", null, null }
                });
        }
    }
}
