using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcDeMo.Migrations
{
    public partial class Create_Table_Demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demos",
                columns: table => new
                {
                    DemoID = table.Column<string>(type: "TEXT", nullable: false),
                    DemoName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demos", x => x.DemoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demos");
        }
    }
}
