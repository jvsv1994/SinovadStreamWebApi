using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update130720232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Role");

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Estado del Servidor Multimedia" },
                    { 2, null, null, null, null, null, "Tipos de contenido Multimedia " },
                    { 3, null, null, null, null, null, "Tipos de transmisión de Video" },
                    { 4, null, null, null, null, null, "Preajuste del transcodificador" },
                    { 5, null, null, null, null, null, "Tipo de Icono" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Created", "CreatedBy", "Deleted", "Enable", "LastModified", "LastModifiedBy", "Name", "NormalizedName" },
                values: new object[] { 1, null, null, null, null, true, null, null, "Administrador", null });

            migrationBuilder.InsertData(
                table: "CatalogDetail",
                columns: new[] { "CatalogId", "Id", "Created", "CreatedBy", "Deleted", "LastModified", "LastModifiedBy", "Name", "NumberValue", "TextValue" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, null, "Iniciado", null, null },
                    { 1, 2, null, null, null, null, null, "Pausado", null, null },
                    { 2, 1, null, null, null, null, null, "Película", null, null },
                    { 2, 2, null, null, null, null, null, "Serie de TV", null, null },
                    { 3, 1, null, null, null, null, null, "Normal", null, null },
                    { 3, 2, null, null, null, null, null, "MPEG-DASH", null, null },
                    { 3, 3, null, null, null, null, null, "HLS", null, null },
                    { 4, 1, null, null, null, null, null, "ultrafast", null, "ultrafast" },
                    { 4, 2, null, null, null, null, null, "superfast", null, "superfast" },
                    { 4, 3, null, null, null, null, null, "veryfast", null, "veryfast" },
                    { 4, 4, null, null, null, null, null, "faster", null, "faster" },
                    { 4, 5, null, null, null, null, null, "fast", null, "fast" },
                    { 4, 6, null, null, null, null, null, "medium", null, "medium" },
                    { 4, 7, null, null, null, null, null, "slow", null, "slow" },
                    { 4, 8, null, null, null, null, null, "slower", null, "slower" },
                    { 4, 9, null, null, null, null, null, "veryslow", null, "veryslow" },
                    { 5, 1, null, null, null, null, null, "Font Awesome", null, null },
                    { 5, 2, null, null, null, null, null, "Imagen", null, null }
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
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Role");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
