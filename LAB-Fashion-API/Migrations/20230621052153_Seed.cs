using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAB_Fashion_API.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Release",
                table: "Collections",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Cnpj", "Cpf", "Email", "Name", "PasswordHash", "PasswordSalt", "Phone", "Sex", "Status", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "99999999999", "adm@adm.com", "Admin", new byte[] { 134, 113, 41, 83, 207, 16, 33, 81, 204, 222, 65, 211, 30, 92, 250, 143, 63, 135, 119, 203, 191, 162, 0, 187, 36, 189, 251, 201, 134, 21, 118, 131 }, new byte[] { 29, 110, 38, 125, 82, 193, 37, 246, 223, 219, 150, 33, 102, 122, 160, 69, 252, 246, 249, 93, 30, 191, 205, 60, 240, 199, 82, 41, 57, 194, 94, 66, 237, 48, 194, 135, 222, 25, 94, 229, 105, 153, 215, 102, 225, 48, 154, 224, 0, 255, 115, 99, 32, 191, 242, 37, 118, 189, 247, 23, 68, 160, 9, 192 }, "55999999999", "Masculino", 1, 1 },
                    { 2, new DateTime(1999, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "999999991522", "matheus@email.com", "Matheus", new byte[] { 173, 98, 184, 177, 137, 33, 91, 42, 164, 168, 172, 159, 192, 27, 42, 158, 99, 18, 16, 44, 77, 2, 81, 59, 167, 247, 196, 212, 49, 106, 67, 71 }, new byte[] { 29, 110, 38, 125, 82, 193, 37, 246, 223, 219, 150, 33, 102, 122, 160, 69, 252, 246, 249, 93, 30, 191, 205, 60, 240, 199, 82, 41, 57, 194, 94, 66, 237, 48, 194, 135, 222, 25, 94, 229, 105, 153, 215, 102, 225, 48, 154, 224, 0, 255, 115, 99, 32, 191, 242, 37, 118, 189, 247, 23, 68, 160, 9, 192 }, "55999999666", "Masculino", 1, 3 },
                    { 3, new DateTime(1996, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "999999991212", "emilly@email.com", "Emilly", new byte[] { 234, 17, 144, 20, 178, 10, 227, 34, 25, 211, 235, 97, 47, 109, 80, 13, 38, 229, 160, 63, 69, 18, 85, 28, 202, 68, 61, 140, 8, 10, 236, 39 }, new byte[] { 29, 110, 38, 125, 82, 193, 37, 246, 223, 219, 150, 33, 102, 122, 160, 69, 252, 246, 249, 93, 30, 191, 205, 60, 240, 199, 82, 41, 57, 194, 94, 66, 237, 48, 194, 135, 222, 25, 94, 229, 105, 153, 215, 102, 225, 48, 154, 224, 0, 255, 115, 99, 32, 191, 242, 37, 118, 189, 247, 23, 68, 160, 9, 192 }, "55999995566", "Feminino", 1, 2 },
                    { 4, new DateTime(1983, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "999556999999", "user@email.com", "Usuario", new byte[] { 37, 219, 180, 52, 251, 60, 191, 99, 27, 133, 4, 232, 187, 18, 213, 42, 254, 194, 209, 248, 188, 36, 109, 243, 57, 160, 242, 252, 86, 62, 147, 141 }, new byte[] { 29, 110, 38, 125, 82, 193, 37, 246, 223, 219, 150, 33, 102, 122, 160, 69, 252, 246, 249, 93, 30, 191, 205, 60, 240, 199, 82, 41, 57, 194, 94, 66, 237, 48, 194, 135, 222, 25, 94, 229, 105, 153, 215, 102, 225, 48, 154, 224, 0, 255, 115, 99, 32, 191, 242, 37, 118, 189, 247, 23, 68, 160, 9, 192 }, "55999922399", "Feminino", 2, 4 },
                    { 5, new DateTime(1992, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "12999444000122", null, "carlos@email.com", "Carlos", new byte[] { 73, 190, 245, 67, 161, 50, 181, 14, 67, 186, 214, 120, 237, 22, 193, 112, 26, 195, 147, 175, 186, 40, 39, 170, 9, 242, 12, 10, 1, 152, 56, 156 }, new byte[] { 29, 110, 38, 125, 82, 193, 37, 246, 223, 219, 150, 33, 102, 122, 160, 69, 252, 246, 249, 93, 30, 191, 205, 60, 240, 199, 82, 41, 57, 194, 94, 66, 237, 48, 194, 135, 222, 25, 94, 229, 105, 153, 215, 102, 225, 48, 154, 224, 0, 255, 115, 99, 32, 191, 242, 37, 118, 189, 247, 23, 68, 160, 9, 192 }, "55999991624", "Masculino", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "Accountable", "Brand", "Budget", "Name", "Release", "Season", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Adidas", 50000.0, "Coleção 1", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1 },
                    { 2, 2, "Nike", 100000.0, "Coleção 2", new DateTime(2030, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 3, 1, "Shein", 200000.0, "Coleção 3", new DateTime(2055, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 4, 4, "Renner", 45000.0, "Coleção 4", new DateTime(2045, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 4 },
                    { 5, 3, "Insider", 1000.0, "Coleção 5", new DateTime(2042, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CollectionId", "Layout", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 1, 2, "Modelo 1", 4 },
                    { 2, 1, 3, "Modelo 2", 4 },
                    { 3, 3, 1, "Modelo 3", 5 },
                    { 4, 2, 2, "Modelo 4", 7 },
                    { 5, 5, 3, "Modelo 5", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Release",
                table: "Collections",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
