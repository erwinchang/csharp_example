using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcFriends.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "Mobile", "Name" },
                values: new object[] { 1, "mary@gmailcom", "0922-111222", "Mary" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "Mobile", "Name" },
                values: new object[] { 2, "david@gmailcom", "0933-111222", "David" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "Mobile", "Name" },
                values: new object[] { 3, "rose@gmailcom", "0944-111222", "Rose" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
