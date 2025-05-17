using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "All About Mobile Phones", "Mobile Phones" },
                    { 2, "All About Laptops", "Laptops" },
                    { 3, "All About Tablets", "Tablets" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c95e81f-8e01-4443-8c2d-18ff9f502dc4", null, "admin", "ADMIN" },
                    { "419d9ae1-edf2-4d9e-ab7c-4712684966df", null, "customer", "CUSTOMER" },
                    { "ef4e7bda-89bc-4953-9d53-ca00a054cf78", null, "editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0c95e81f-8e01-4443-8c2d-18ff9f502dc4", "e04c3582-8b0b-488a-bf42-59adbe0a5928" },
                    { "419d9ae1-edf2-4d9e-ab7c-4712684966df", "32cac776-1bf2-470c-9fb6-a5d651d77f47" },
                    { "419d9ae1-edf2-4d9e-ab7c-4712684966df", "3adcf16a-9159-48e8-9079-9c9436adbd31" },
                    { "419d9ae1-edf2-4d9e-ab7c-4712684966df", "bbc1210d-3f25-4d9c-8662-21cc71a46fde" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "32cac776-1bf2-470c-9fb6-a5d651d77f47", 0, null, "de51bcc0-67a2-48bb-b63c-ab9704ba919f", "abdoabohend@example.com", true, false, null, "AbdoAbohend", "ABDOABOHEND@EXAMPLE.COM", "ABDOABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAZ99k+h6wxbT7OTSQ+IfIhkePGpnrRPD1oHiTjHJ/G3vu5/Zyuvev8mY7IvTXL0aA==", null, false, "e6016912-a828-43f5-b5c7-8ac066a70439", false, "abdoabohend@example.com" },
                    { "3adcf16a-9159-48e8-9079-9c9436adbd31", 0, null, "05bbd642-35c8-48ab-ac17-0ac6963aef36", "ziadabohend@example.com", true, false, null, "Ziad Abohend", "ZIADABOHEND@EXAMPLE.COM", "ZIADABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAEL9gAzamOO5kvEiT2i5Twby6eOh+zgOWztcciTO47cviedUtvsvvCWwjRYORTgwG8A==", null, false, "b8dc01b6-ae43-4f1e-ac67-df0d5cc54580", false, "ziadabohend@example.com" },
                    { "bbc1210d-3f25-4d9c-8662-21cc71a46fde", 0, null, "7ae16fa8-7e69-4a21-a4e4-ebbebfed4735", "saeedabohend@example.com", true, false, null, "Saeed Abohend", "SAEEDABOHEND@EXAMPLE.COM", "SAEEDABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAEBOyrTAn3Iwob5ZHC68Txtjjeh7UQ00nr+sNkZL9wrVDC6OcxsaADUxhgZHU99c6jg==", null, false, "a0fd2b32-34e9-4526-8293-e64d69e32a8e", false, "saeedabohend@example.com" },
                    { "e04c3582-8b0b-488a-bf42-59adbe0a5928", 0, null, "8702ecb2-915e-4436-be24-b5a7b46b0bc4", "mhmdabohend@gmail.com", true, false, null, "Mohamed Abohend", "MHMDABOHEND@GMAIL.COM", "MHMDABOHEND@GMAIL.COM", "AQAAAAIAAYagAAAAEJ5OIWbQ6QgcMMuf+S0iqRDulTboVoBdwFjIJ0J5iOviRhjKgu7jHdCUu1MxaUgqcg==", null, false, "e24c48f5-7a62-4ad5-96df-d1802e6ee131", false, "mhmdabohend@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Iphone 14 Pro Max", "images/products/image1.webp", "Iphone 14 Pro", 1200m },
                    { 2, 1, "Samsung Galaxy S23 Ultra", "images/products/image2.webp", "Samsung Galaxy S23", 1000m },
                    { 3, 2, "Dell Inspiron 15 3000", "images/products/image3.jpg", "Dell Inspiron 15", 1500m },
                    { 4, 2, "HP Pavilion 15", "images/products/image4.jpg", "HP Pavilion", 1400m },
                    { 5, 3, "Hwawei MatePad Pro", "images/products/image5.jpg", "Hwawei MatePad", 600m },
                    { 6, 3, "Samsung Galaxy Tab S8", "images/products/image6.jpg", "Samsung Galaxy Tab S8", 700m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0c95e81f-8e01-4443-8c2d-18ff9f502dc4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "419d9ae1-edf2-4d9e-ab7c-4712684966df");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ef4e7bda-89bc-4953-9d53-ca00a054cf78");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0c95e81f-8e01-4443-8c2d-18ff9f502dc4", "e04c3582-8b0b-488a-bf42-59adbe0a5928" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "419d9ae1-edf2-4d9e-ab7c-4712684966df", "32cac776-1bf2-470c-9fb6-a5d651d77f47" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "419d9ae1-edf2-4d9e-ab7c-4712684966df", "3adcf16a-9159-48e8-9079-9c9436adbd31" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "419d9ae1-edf2-4d9e-ab7c-4712684966df", "bbc1210d-3f25-4d9c-8662-21cc71a46fde" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "32cac776-1bf2-470c-9fb6-a5d651d77f47");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3adcf16a-9159-48e8-9079-9c9436adbd31");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "bbc1210d-3f25-4d9c-8662-21cc71a46fde");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e04c3582-8b0b-488a-bf42-59adbe0a5928");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
