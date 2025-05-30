using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TezMektepKz.Migrations
{
    /// <inheritdoc />
    public partial class tezmektepkz11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20956ad4-4661-48c1-b1e1-67da16fc05c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e5322da-874f-4d1e-9891-4163e6f01467");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9b91963-6c5c-4cc8-8e62-e02ea890b428");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6f2db4f-c496-4c7f-975f-d633f3e7a1a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb20b2df-6ebf-47f0-8c58-f90d9a6771d9");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBorn",
                table: "AspNetUsers",
                type: "date",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0541a9cb-d6a5-4d2f-9d75-051aa5169644", null, "Кассир", "КАССИР" },
                    { "26f0b676-5131-4d64-bc34-639c7e5da9d1", null, "Учитель", "УЧИТЕЛЬ" },
                    { "5760c6f6-efc0-4995-9ee4-dc204c555889", null, "Админ", "АДМИН" },
                    { "a4628957-b40a-4849-9203-0ed3362f5b15", null, "Директор", "ДИРЕКТОР" },
                    { "b0165f4a-a486-4771-9ef9-6d7da347c113", null, "Ученик", "УЧЕНИК" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0541a9cb-d6a5-4d2f-9d75-051aa5169644");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f0b676-5131-4d64-bc34-639c7e5da9d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5760c6f6-efc0-4995-9ee4-dc204c555889");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4628957-b40a-4849-9203-0ed3362f5b15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0165f4a-a486-4771-9ef9-6d7da347c113");

            migrationBuilder.DropColumn(
                name: "DateOfBorn",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20956ad4-4661-48c1-b1e1-67da16fc05c2", null, "Ученик", "УЧЕНИК" },
                    { "8e5322da-874f-4d1e-9891-4163e6f01467", null, "Кассир", "КАССИР" },
                    { "b9b91963-6c5c-4cc8-8e62-e02ea890b428", null, "Учитель", "УЧИТЕЛЬ" },
                    { "c6f2db4f-c496-4c7f-975f-d633f3e7a1a9", null, "Админ", "АДМИН" },
                    { "cb20b2df-6ebf-47f0-8c58-f90d9a6771d9", null, "Директор", "ДИРЕКТОР" }
                });
        }
    }
}
