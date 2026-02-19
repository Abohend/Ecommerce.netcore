using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WebsiteViewAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1c92561a-2408-4442-960a-350cae3c2a51");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "38f1fc3e-0483-4667-b6ce-0b5688d32089");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6d229666-1485-462d-b795-8114ff6f6f5c");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1c92561a-2408-4442-960a-350cae3c2a51", "3d482e40-06df-4e49-9c41-68bad89689c3" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d229666-1485-462d-b795-8114ff6f6f5c", "36da79db-603c-4f7d-a641-9aea8632d1e9" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d229666-1485-462d-b795-8114ff6f6f5c", "75063820-8a33-4653-92da-0683da1f8a7a" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d229666-1485-462d-b795-8114ff6f6f5c", "e16fc225-cbe1-462d-95e2-5299e3dbc7af" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "36da79db-603c-4f7d-a641-9aea8632d1e9");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3d482e40-06df-4e49-9c41-68bad89689c3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "75063820-8a33-4653-92da-0683da1f8a7a");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e16fc225-cbe1-462d-95e2-5299e3dbc7af");

            migrationBuilder.CreateTable(
                name: "WebsiteViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteViews", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebsiteViews");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c92561a-2408-4442-960a-350cae3c2a51", null, "admin", "ADMIN" },
                    { "38f1fc3e-0483-4667-b6ce-0b5688d32089", null, "editor", "EDITOR" },
                    { "6d229666-1485-462d-b795-8114ff6f6f5c", null, "customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1c92561a-2408-4442-960a-350cae3c2a51", "3d482e40-06df-4e49-9c41-68bad89689c3" },
                    { "6d229666-1485-462d-b795-8114ff6f6f5c", "36da79db-603c-4f7d-a641-9aea8632d1e9" },
                    { "6d229666-1485-462d-b795-8114ff6f6f5c", "75063820-8a33-4653-92da-0683da1f8a7a" },
                    { "6d229666-1485-462d-b795-8114ff6f6f5c", "e16fc225-cbe1-462d-95e2-5299e3dbc7af" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "36da79db-603c-4f7d-a641-9aea8632d1e9", 0, null, "f9bbe6de-682a-4715-9206-2abf99b44908", "ziadabohend@example.com", true, false, null, "Ziad Abohend", "ZIADABOHEND@EXAMPLE.COM", "ZIADABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPI9Gq5z/7/jpRZhdovDnEhvU+OLb+8Ys0kGKn8IzBnD0zoKMwxewnX7HCraxIoLFg==", null, false, "3d17a7c0-ce8c-4c53-913e-f17338328ebe", false, "ziadabohend@example.com" },
                    { "3d482e40-06df-4e49-9c41-68bad89689c3", 0, null, "44407855-1f82-4edd-87c2-5d3e752367b7", "mhmdabohend@gmail.com", true, false, null, "Mohamed Abohend", "MHMDABOHEND@GMAIL.COM", "MHMDABOHEND@GMAIL.COM", "AQAAAAIAAYagAAAAEGHgga/rIVbnodPTZRauAv3oMryXipfsW9Hp+YzTrG0yX4RFNopj078HRvo+IPNz8A==", null, false, "4c1c1179-0af5-4d78-9794-f7b6da8cb946", false, "mhmdabohend@gmail.com" },
                    { "75063820-8a33-4653-92da-0683da1f8a7a", 0, null, "2c28df4d-b0de-4894-9ef8-a7a1a8238004", "abdoabohend@example.com", true, false, null, "AbdoAbohend", "ABDOABOHEND@EXAMPLE.COM", "ABDOABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAEO401BDh2qtmLWLUVccIDuN4a95Yj4RXsnT+vfWkUrIISaeybwt3iAF5/mV916n8xQ==", null, false, "0d5fbcc4-a205-4768-bf06-523054557368", false, "abdoabohend@example.com" },
                    { "e16fc225-cbe1-462d-95e2-5299e3dbc7af", 0, null, "5e81e088-9b31-4553-8dc7-0a1371569f61", "saeedabohend@example.com", true, false, null, "Saeed Abohend", "SAEEDABOHEND@EXAMPLE.COM", "SAEEDABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAEL8hekvqLd9hPhc+dsFN9f+8zI1b1dp4GhHtKSETlPiKbD+OEWo3IlxtQCp0/F5dwA==", null, false, "b01a1681-5945-41c2-89ce-3ec57a65b66f", false, "saeedabohend@example.com" }
                });
        }
    }
}
