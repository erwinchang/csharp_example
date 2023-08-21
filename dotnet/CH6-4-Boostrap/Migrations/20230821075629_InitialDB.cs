using Microsoft.EntityFrameworkCore.Migrations;

namespace CH6_4_Boostrap.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Department", "Email", "Mobile", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "總經理室", "mary@gmailcom", "0922-111222", "Mary", "CEO" },
                    { 2, "人事部", "david@gmailcom", "0933-111222", "David", "管理師" },
                    { 3, "財務部", "rose@gmailcom", "0944-111222", "Rose", "經理" },
                    { 4, "總經理室2", "mary@gmailcom", "0922-111222", "Mary2", "CEO2" },
                    { 5, "人事部2", "david@gmailcom", "0933-111222", "David2", "管理師2" },
                    { 6, "財務部2", "rose@gmailcom", "0944-111222", "Rose2", "經理2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
