using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GetTogether.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seed_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Description", "Login", "Name" },
                values: new object[,]
                {
                    { 1, "sherman.net", "Dora.Stamm", "Dora" },
                    { 2, "sally.info", "Juan.Swift", "Juan" },
                    { 3, "nyah.biz", "Nellie_Ankunding8", "Nellie" },
                    { 4, "devin.biz", "Julia.King", "Julia" },
                    { 5, "lenny.org", "Lewis86", "Lewis" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
