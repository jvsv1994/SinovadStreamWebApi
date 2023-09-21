using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _210920236 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    { 1, null, null, null, new Guid("4a7283a4-efd1-4f5f-8790-ed15d833268c"), null, null, "Estado del Servidor Multimedia" },
                    { 2, null, null, null, new Guid("51f6a49b-a3cd-4225-88e7-f310dae9427b"), null, null, "Tipos de contenido Multimedia " },
                    { 3, null, null, null, new Guid("941f220e-9d72-4fac-b844-69226a43a1a4"), null, null, "Tipos de transmisión de Video" },
                    { 4, null, null, null, new Guid("eb79f0da-e985-4e6e-9542-eac0812b5c33"), null, null, "Preajuste del transcodificador" },
                    { 5, null, null, null, new Guid("043e22de-3a91-4e1e-a064-faeea510fe55"), null, null, "Tipo de Icono" },
                    { 6, null, null, null, new Guid("2c16bf71-822e-4cc8-b77e-3557dbde2e00"), null, null, "Proveedor de Cuenta Vinculada" }
                });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("12ffca1d-7260-4140-a65b-5c4151732d42"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("2c73a20e-bbe9-488e-b504-e61a38db2564"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("e1e5d123-7504-4e5f-847d-c5815a4b101e"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("d3f07411-7f8d-4190-83c5-6622969562fb"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("496687be-f71a-4b8a-a138-76f31958f273"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("23fc5ff8-ba0b-410a-8ebf-c1eeb7ea65c3"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("37c2cad1-3f08-4435-9ab0-9016af370839"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("23c56d4b-0677-4fd2-b90c-84f5717bf4ae"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("2467b7a1-95c1-4354-b09b-e7b00b578c92"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("40749e11-6aa4-4b8a-af2f-ca3ea6fe0bf9"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("a5ebc6e6-17b2-4147-84b6-7c029073fe80"));

            migrationBuilder.InsertData(
                table: "CatalogDetail",
                columns: new[] { "CatalogId", "Id", "Created", "CreatedBy", "Deleted", "Guid", "LastModified", "LastModifiedBy", "Name", "NumberValue", "TextValue" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, new Guid("7da1546e-1dfc-4bf3-be94-9ee75ce49ffb"), null, null, "Iniciado", null, null },
                    { 1, 2, null, null, null, new Guid("829c4004-6eaf-4b41-94cf-9c6669e1aa7c"), null, null, "Pausado", null, null },
                    { 2, 1, null, null, null, new Guid("cedb03e5-f944-4556-ad24-5b4bc71d9eea"), null, null, "Película", null, null },
                    { 2, 2, null, null, null, new Guid("911d1fae-8cef-484f-9c84-4a1fef24458a"), null, null, "Serie de TV", null, null },
                    { 3, 1, null, null, null, new Guid("b2ee5983-0af9-42ad-a7e9-8fec031dd971"), null, null, "Normal", null, null },
                    { 3, 2, null, null, null, new Guid("0bb93e75-aff7-4fe8-9735-ec34e8c6a1f1"), null, null, "MPEG-DASH", null, null },
                    { 3, 3, null, null, null, new Guid("d03c9413-7e40-4eaf-a5ba-8c6d70d52b08"), null, null, "HLS", null, null },
                    { 4, 1, null, null, null, new Guid("f5837fb7-870f-4ef8-89fe-426a63b73637"), null, null, "ultrafast", null, "ultrafast" },
                    { 4, 2, null, null, null, new Guid("9f4b830c-8d60-4390-bb33-d9df0bf357f6"), null, null, "superfast", null, "superfast" },
                    { 4, 3, null, null, null, new Guid("68ecd4d7-00f9-46ff-a018-76a60c9226fc"), null, null, "veryfast", null, "veryfast" },
                    { 4, 4, null, null, null, new Guid("c376574b-320d-4357-8cee-175994a4d363"), null, null, "faster", null, "faster" },
                    { 4, 5, null, null, null, new Guid("42a4e586-1381-4715-a66f-ca3fc0341328"), null, null, "fast", null, "fast" },
                    { 4, 6, null, null, null, new Guid("c99498d1-2f0a-420b-a1c1-e4e2b09f683c"), null, null, "medium", null, "medium" },
                    { 4, 7, null, null, null, new Guid("b134e0e3-d6b6-43f5-a57f-a3633b0dfc53"), null, null, "slow", null, "slow" },
                    { 4, 8, null, null, null, new Guid("71ef8b32-a054-4879-81dc-11fad782babf"), null, null, "slower", null, "slower" },
                    { 4, 9, null, null, null, new Guid("ce4d7320-0e34-4620-b96c-0c940f522c39"), null, null, "veryslow", null, "veryslow" },
                    { 5, 1, null, null, null, new Guid("20543255-30e9-470d-bc0b-176938f36be9"), null, null, "Imagen", null, null },
                    { 5, 2, null, null, null, new Guid("9519930f-cada-4bd7-acea-1f759fdcd02f"), null, null, "Font Awesome", null, null },
                    { 6, 1, null, null, null, new Guid("fd6fcfb6-74ee-408c-a379-7ec5ef7122cd"), null, null, "Google", null, null },
                    { 6, 2, null, null, null, new Guid("a52d3a4f-ded5-4630-9620-d483ee13ab43"), null, null, "Facebook", null, null },
                    { 6, 3, null, null, null, new Guid("7eec6998-6dbe-46ca-9b02-d0772f30dd8e"), null, null, "Apple", null, null }
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
                value: new Guid("bdff0574-2a51-45f5-800f-818aa74ffd5b"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("e0fda9b4-f410-4bde-a409-e6ea75c15408"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("a3ae429c-7cbf-460a-bde0-1486a6ac4c49"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("18e41776-2e19-451c-8d4d-2442f0555040"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("f94232a1-1d78-4203-9ee2-8f6809f5ebaf"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("08e07ed1-65f9-426d-8613-cd2da3d2d258"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("fc45ae1e-0763-415d-83af-6f41d65df904"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("3976e27c-4263-46cb-87a1-390dd513c631"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("66084d48-65e2-4c3b-aa25-73124476faf2"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("71ab6996-b1f4-420a-9c85-60c59bc3ad2c"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("ec03f5e5-50ea-4727-922a-699dd6063695"));
        }
    }
}
