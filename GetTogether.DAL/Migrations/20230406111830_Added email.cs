using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetTogether.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Addedemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Email", "Login", "Name" },
                values: new object[] { "muhammad.name", "Byron_Lehner72@yahoo.com", "Byron.Lehner18", "Byron" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Email", "Login", "Name" },
                values: new object[] { "russell.biz", "Gerard65@gmail.com", "Gerard_Hegmann", "Gerard" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Email", "Login", "Name" },
                values: new object[] { "abdul.info", "Robyn2@yahoo.com", "Robyn.OConner", "Robyn" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Email", "Login", "Name" },
                values: new object[] { "julianne.com", "Juana.Grimes@gmail.com", "Juana.Grimes15", "Juana" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Email", "Login", "Name" },
                values: new object[] { "clementina.biz", "Bethany5@hotmail.com", "Bethany.Schumm", "Bethany" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Login", "Name" },
                values: new object[] { "sherman.net", "Dora.Stamm", "Dora" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Login", "Name" },
                values: new object[] { "sally.info", "Juan.Swift", "Juan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Login", "Name" },
                values: new object[] { "nyah.biz", "Nellie_Ankunding8", "Nellie" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Login", "Name" },
                values: new object[] { "devin.biz", "Julia.King", "Julia" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Login", "Name" },
                values: new object[] { "lenny.org", "Lewis86", "Lewis" });
        }
    }
}
