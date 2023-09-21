using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _210920235 : Migration
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
    }
}
