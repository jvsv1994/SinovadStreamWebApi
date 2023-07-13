using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update13072023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Menu",
                newName: "SortOrder");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IconTypeCatalogId",
                table: "Menu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IconTypeCatalogDetailId",
                table: "Menu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IconClass",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "Enabled", "IconClass", "IconTypeCatalogDetailId", "IconTypeCatalogId", "IconUrl", "LastModified", "LastModifiedBy", "ParentId", "Path", "SortOrder", "Title" },
                values: new object[,]
                {
                    { 1, null, null, null, false, null, null, null, null, null, null, 0, null, 1, "Media" },
                    { 2, null, null, null, false, null, null, null, null, null, null, 0, null, 2, "Almacenamiento" },
                    { 3, null, null, null, false, null, null, null, null, null, null, 0, null, 3, "Mantenimiento" },
                    { 4, null, null, null, true, "fa-solid fa-house", 2, 5, null, null, null, 1, "/home", 1, "Inicio" },
                    { 5, null, null, null, true, "fa-solid fa-film", 2, 5, null, null, null, 1, "/movies", 2, "Peliculas" },
                    { 6, null, null, null, true, "fa-solid fa-tv", 2, 5, null, null, null, 1, "/tvseries", 3, "Series" },
                    { 7, null, null, null, true, "fa-solid fa-database", 2, 5, null, null, null, 2, "/storages", 1, "Almacenamiento" },
                    { 8, null, null, null, true, "fa-solid fa-database", 2, 5, null, null, null, 2, "/transcoder", 2, "Transcodificacion" },
                    { 9, null, null, null, true, "fa-solid fa-list-film", 2, 5, null, null, null, 3, "/movies-maintenance", 1, "Peliculas" },
                    { 10, null, null, null, true, "fa-solid fa-list-tv", 2, 5, null, null, null, 3, "/tvseries-maintenance", 2, "Series" },
                    { 11, null, null, null, true, "fa-solid fa-list-check", 2, 5, null, null, null, 3, "/genres-maintenance", 3, "Generos" },
                    { 12, null, null, null, true, "fa-solid fa-list-check", 2, 5, null, null, null, 3, "/roles-maintenance", 4, "Roles" },
                    { 13, null, null, null, true, "fa-solid fa-list-user", 2, 5, null, null, null, 3, "/users-maintenance", 5, "Usuarios" },
                    { 14, null, null, null, true, "fa-solid fa-list-check", 2, 5, null, null, null, 3, "/options-maintenance", 6, "Opciones" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8);

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

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IconClass",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "Menu",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IconTypeCatalogId",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IconTypeCatalogDetailId",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
