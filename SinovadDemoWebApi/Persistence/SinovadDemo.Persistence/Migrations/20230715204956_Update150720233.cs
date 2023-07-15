using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update150720233 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Created", "CreatedBy", "Deleted", "Enabled", "LastModified", "LastModifiedBy", "Name", "NormalizedName" },
                values: new object[] { 2, null, null, null, null, true, null, null, "Registrado", null });

            migrationBuilder.InsertData(
                table: "RoleMenu",
                columns: new[] { "MenuId", "RoleId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, 2, null, null, null, null },
                    { 2, 2, null, null, null, null },
                    { 4, 2, null, null, null, null },
                    { 5, 2, null, null, null, null },
                    { 6, 2, null, null, null, null },
                    { 7, 2, null, null, null, null },
                    { 8, 2, null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
