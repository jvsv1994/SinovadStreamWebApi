using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinovadDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _220920231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "UserRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowCreate",
                table: "RoleMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowDelete",
                table: "RoleMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowRead",
                table: "RoleMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowUpdate",
                table: "RoleMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "RoleMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("58ab39f8-ee78-4459-96c1-2785a3e1009c"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("0aa0af19-e2a8-4422-89f3-e9886665b9ef"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("15020d35-bbcd-4e92-ac6e-188cb3f9c038"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("4ede7871-e576-43fe-897d-d0af71161ac4"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("55f4706c-96f9-4959-b1bb-df6b3fce5054"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("bae2d16d-65a3-425a-8a81-1ed45b0e9497"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("c09df2eb-a285-419b-8502-cc6adcee9c1d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("a105749e-6798-49e9-acc8-295a148bab29"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("9c74104b-da4b-4f2b-b1fe-163d282f350c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("f03622da-becc-4139-9b5a-938686fbf052"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("dda2242e-8af8-451f-8ca1-abd1435025ce"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("e1a82bb5-8ab8-4135-8594-940a612e17be"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("aa3e3475-cdb6-4545-b641-87d8de98e77d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("7375736c-9510-4da3-8a92-ef6866bf887c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("c14eca21-68b7-4651-a977-7cc66358952d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("4ff69175-f4e3-47a6-981b-bc26bbce6964"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("e1f974f9-8177-4eac-9392-635d264f87fe"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("f0f48fc0-5e9c-4fd2-a8cd-7a69bcf3c336"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("45847ec2-4c9a-43b9-9a1a-9009c8608a46"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("6f280859-47ba-4714-a16b-86d08d1d9567"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("74df0a4f-49c3-4170-9ae7-4d453d9b4151"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("544847e7-25e3-448e-af39-63f063071679"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("f32a28c5-e10f-46b7-8f5d-5cc703f76acb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("d8c008aa-4bde-4355-a9dc-d3c9c3045c13"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 1 },
                column: "Guid",
                value: new Guid("3cebe94c-2b71-4c9d-ba0b-8782f062cabd"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 2 },
                column: "Guid",
                value: new Guid("c6502cea-f14c-47ac-a5e3-56e15c585433"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 3 },
                column: "Guid",
                value: new Guid("7c6867b2-dc83-43f7-b609-e4621e11510c"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("c91d07c2-de15-44d2-9bb4-dec1bde10683"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("ae7846b3-1c6d-45b2-8855-c151c6585b8f"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("09700630-6626-4d9c-aaae-88da50e820fb"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("b2d6fe3d-3be3-4569-b370-dc218b5c78d9"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("15e74e84-7550-49f1-a095-9528b78df1ea"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("9986bf6d-f36f-4c5b-9d90-81f3373fb7c8"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 7,
                column: "Guid",
                value: new Guid("9b3a0005-de88-4353-a3bd-f67a42ca0a26"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 8,
                column: "Guid",
                value: new Guid("ded35c3e-8377-4acb-8c5b-9b8ffd12aee3"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: 9,
                column: "Guid",
                value: new Guid("e1064b3b-588d-4e18-9f70-d6e8f54f9fa6"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("2078819e-6454-4706-96f6-b76e6d0da6c3"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("2a751515-a1cc-4842-9f9b-c513eb94376d"));

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 3, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 4, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 5, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 6, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 7, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 8, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 9, 1 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 7, 2 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 8, 2 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });

            migrationBuilder.UpdateData(
                table: "RoleMenu",
                keyColumns: new[] { "MenuId", "RoleId" },
                keyValues: new object[] { 9, 2 },
                columns: new[] { "AllowCreate", "AllowDelete", "AllowRead", "AllowUpdate", "Enabled" },
                values: new object[] { false, false, false, false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "AllowCreate",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "AllowDelete",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "AllowRead",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "AllowUpdate",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "RoleMenu");

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("5b73440a-386d-489e-80ed-569e8af04570"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("e29dd52b-e3ac-4dfb-9277-e230d5e30334"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("c7e8e5c4-73cb-49cc-b487-3c7a1fee55f2"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("91d1a5f1-a9bc-4773-a409-565cacbf8fdd"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("65973080-8be1-4ac1-861d-859c430922df"));

            migrationBuilder.UpdateData(
                table: "Catalog",
                keyColumn: "Id",
                keyValue: 6,
                column: "Guid",
                value: new Guid("9e68de07-52b6-4c58-935c-f932597d930d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Guid",
                value: new Guid("b3b13597-b505-488e-bbcf-6ed2b6eda370"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 1, 2 },
                column: "Guid",
                value: new Guid("41449408-a56f-4184-8994-9198a90d41c0"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 1 },
                column: "Guid",
                value: new Guid("68dbf77e-926f-4fd1-8df5-9e66bcaa3fb7"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 2, 2 },
                column: "Guid",
                value: new Guid("f5c0db6e-1f67-4e9c-9480-426ebd6d7ea6"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 1 },
                column: "Guid",
                value: new Guid("29f6245f-8ef2-4220-98c0-e9ded16b8feb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 2 },
                column: "Guid",
                value: new Guid("e12b63de-0554-416e-a886-4a21e66f73ec"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 3, 3 },
                column: "Guid",
                value: new Guid("8b4d1871-2979-456f-abdc-c79b9e4d349d"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 1 },
                column: "Guid",
                value: new Guid("77489236-9339-4689-a1e5-e754f6275169"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 2 },
                column: "Guid",
                value: new Guid("cc9f19f6-b30d-449a-9947-bf02525fa3c9"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 3 },
                column: "Guid",
                value: new Guid("a53a45b8-12e2-472f-b120-96cb3418c257"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 4 },
                column: "Guid",
                value: new Guid("212d64ea-85a2-4f56-af6a-3bcb6dabccbb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 5 },
                column: "Guid",
                value: new Guid("f6dc5504-5e00-424f-97a9-076255de384e"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 6 },
                column: "Guid",
                value: new Guid("4317fcd9-cbb5-4d56-9306-93816bf880fa"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 7 },
                column: "Guid",
                value: new Guid("3fcb64e6-6aee-48e7-b3ce-9767fb0631fc"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 8 },
                column: "Guid",
                value: new Guid("8e7f3773-0dac-445d-b245-7959f1299074"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 4, 9 },
                column: "Guid",
                value: new Guid("2a93c4e9-a2d0-46e1-a0a4-cd533afc780c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 1 },
                column: "Guid",
                value: new Guid("0a78390e-aa38-4958-8614-e4b79706ef5f"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 5, 2 },
                column: "Guid",
                value: new Guid("0350871b-dc25-4867-a88d-f889a1c4c1fb"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 1 },
                column: "Guid",
                value: new Guid("f78da0f4-296e-4989-b79e-3247e295d5b4"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 2 },
                column: "Guid",
                value: new Guid("0f2cbb7e-486b-43ae-a3db-917c3f375c3c"));

            migrationBuilder.UpdateData(
                table: "CatalogDetail",
                keyColumns: new[] { "CatalogId", "Id" },
                keyValues: new object[] { 6, 3 },
                column: "Guid",
                value: new Guid("bc74bd69-e2fb-4ccf-b1ae-893e6ddc20ce"));

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
        }
    }
}
