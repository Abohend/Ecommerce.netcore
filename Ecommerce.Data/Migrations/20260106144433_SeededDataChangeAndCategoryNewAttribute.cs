using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataChangeAndCategoryNewAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Fresh fruits", "images/categories/Fruits.png", "Fruits" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Fresh vegetables", "images/categories/Vegetables.jpg", "Vegetables" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "High quality bread", "images/categories/Bread.jpg", "Bread" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[] { 4, "All meat types", "images/categories/Meat.jpg", "Meat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Fresh grapes", "images/products/grapes.jpg", "Grapes", 4.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Fresh Raspberries", "images/products/Raspberries.jpg", "Raspberries", 5.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Fresh brocoli", "images/products/Brocoli.jpg", "Brocoli", 2.5m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "High quality potatoes", "images/products/Potatoes.jpg", "Potatoes", 1.4m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Wellbacked breadsticks", "images/products/Breadsticks.jpg", "Breadsticks", 1.93m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Wellbacked croissant", "images/products/Croissant.jpg", "Croissant", 2.14m });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e42297d-e84c-4778-820c-af61bd9949ec", null, "editor", "EDITOR" },
                    { "6be9d851-4496-4d3c-878b-c5816d15132c", null, "admin", "ADMIN" },
                    { "df695ebc-f8b0-460a-883e-a53004f3f224", null, "customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6be9d851-4496-4d3c-878b-c5816d15132c", "92e67dee-c904-439f-bba6-96eace7193be" },
                    { "df695ebc-f8b0-460a-883e-a53004f3f224", "034f768e-f2f4-40d6-a612-3f95674f1ac5" },
                    { "df695ebc-f8b0-460a-883e-a53004f3f224", "b0cf6801-a4b0-4fde-a769-e981a0e8c6ed" },
                    { "df695ebc-f8b0-460a-883e-a53004f3f224", "c9bfe5ec-f047-400b-bef4-0a0ffc70edb5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "034f768e-f2f4-40d6-a612-3f95674f1ac5", 0, null, "7f4dd870-a30c-488a-9fb2-0688846aaba5", "saeedabohend@example.com", true, false, null, "Saeed Abohend", "SAEEDABOHEND@EXAMPLE.COM", "SAEEDABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAEGxvVbYTiVVyysBGQZ75aRxfIX4OqAkFaCUrPZcPVu1UB6VNJmZZenaOOHtcgW+Oag==", null, false, "9dce36b6-74b2-4f05-8936-f8186a50de02", false, "saeedabohend@example.com" },
                    { "92e67dee-c904-439f-bba6-96eace7193be", 0, null, "86e8c2f4-2099-49e4-bcc2-5539f0b21ace", "mhmdabohend@gmail.com", true, false, null, "Mohamed Abohend", "MHMDABOHEND@GMAIL.COM", "MHMDABOHEND@GMAIL.COM", "AQAAAAIAAYagAAAAEMz5qSSjQdXqWQKqxL/aIbMXzCPEKKOaT3CuaxaREWOi62dApoOL0ex9tIjVhfaCyA==", null, false, "94b423d4-6c86-4a3d-bd8e-f1432e01a469", false, "mhmdabohend@gmail.com" },
                    { "b0cf6801-a4b0-4fde-a769-e981a0e8c6ed", 0, null, "1938814f-c693-4bc6-9504-be0d01d2a7db", "abdoabohend@example.com", true, false, null, "AbdoAbohend", "ABDOABOHEND@EXAMPLE.COM", "ABDOABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAENW8IZcambkRvXASQgU/i89gg2c2UPHHpBdaWnT+iop14TkfJNJtcL3l/HHmsN1Vdw==", null, false, "a058e9bd-f1e5-4d93-9e1e-f2ad7bfc7737", false, "abdoabohend@example.com" },
                    { "c9bfe5ec-f047-400b-bef4-0a0ffc70edb5", 0, null, "5d173834-eb21-4362-8d2d-457bc8c63c04", "ziadabohend@example.com", true, false, null, "Ziad Abohend", "ZIADABOHEND@EXAMPLE.COM", "ZIADABOHEND@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMZUl5wmp35QquspokzWSd78JBmHHvVvc95kIC5aFe4k6ok7lLDntAg42HmAITmPfA==", null, false, "cc808973-b569-4622-ac0e-17abe89fabe0", false, "ziadabohend@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 7, 4, "Basic cuts of beef", "images/products/Beef.jpg", "Beef", 9.14m },
                    { 8, 4, "Basic cuts of lamp meat", "images/products/Lamp.webp", "Lamp", 10.45m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2e42297d-e84c-4778-820c-af61bd9949ec");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6be9d851-4496-4d3c-878b-c5816d15132c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "df695ebc-f8b0-460a-883e-a53004f3f224");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6be9d851-4496-4d3c-878b-c5816d15132c", "92e67dee-c904-439f-bba6-96eace7193be" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df695ebc-f8b0-460a-883e-a53004f3f224", "034f768e-f2f4-40d6-a612-3f95674f1ac5" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df695ebc-f8b0-460a-883e-a53004f3f224", "b0cf6801-a4b0-4fde-a769-e981a0e8c6ed" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df695ebc-f8b0-460a-883e-a53004f3f224", "c9bfe5ec-f047-400b-bef4-0a0ffc70edb5" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "034f768e-f2f4-40d6-a612-3f95674f1ac5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "92e67dee-c904-439f-bba6-96eace7193be");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b0cf6801-a4b0-4fde-a769-e981a0e8c6ed");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c9bfe5ec-f047-400b-bef4-0a0ffc70edb5");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "All About Mobile Phones", "Mobile Phones" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "All About Laptops", "Laptops" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "All About Tablets", "Tablets" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Iphone 14 Pro Max", "images/products/image1.webp", "Iphone 14 Pro", 1200m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Samsung Galaxy S23 Ultra", "images/products/image2.webp", "Samsung Galaxy S23", 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Dell Inspiron 15 3000", "images/products/image3.jpg", "Dell Inspiron 15", 1500m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "HP Pavilion 15", "images/products/image4.jpg", "HP Pavilion", 1400m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Hwawei MatePad Pro", "images/products/image5.jpg", "Hwawei MatePad", 600m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Samsung Galaxy Tab S8", "images/products/image6.jpg", "Samsung Galaxy Tab S8", 700m });

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
        }
    }
}
