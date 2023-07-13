using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update130720233 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleMenu",
                columns: new[] { "MenuId", "RoleId", "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null },
                    { 2, 1, null, null, null, null },
                    { 3, 1, null, null, null, null },
                    { 4, 1, null, null, null, null },
                    { 5, 1, null, null, null, null },
                    { 6, 1, null, null, null, null },
                    { 7, 1, null, null, null, null },
                    { 8, 1, null, null, null, null },
                    { 9, 1, null, null, null, null },
                    { 10, 1, null, null, null, null },
                    { 11, 1, null, null, null, null },
                    { 12, 1, null, null, null, null },
                    { 13, 1, null, null, null, null },
                    { 14, 1, null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 8, 1 });

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
        }
    }
}
