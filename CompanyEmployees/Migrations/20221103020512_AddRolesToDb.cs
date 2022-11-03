using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyEmployees.Migrations
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3dcaff83-3141-4b46-b388-e83f91e7633e", "2eb6fd38-22d9-446a-927a-6cb6783732a8", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87c3bcc7-8045-4522-960a-15dd5a906286", "f84ac708-df32-4565-82e1-1ae30f43c2d5", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dcaff83-3141-4b46-b388-e83f91e7633e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87c3bcc7-8045-4522-960a-15dd5a906286");
        }
    }
}
