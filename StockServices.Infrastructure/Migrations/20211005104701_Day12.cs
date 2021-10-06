using Microsoft.EntityFrameworkCore.Migrations;

namespace StockServices.Infrastructure.Migrations
{
    public partial class Day12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    StockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    ComapnyName = table.Column<string>(maxLength: 30, nullable: false),
                    StockPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.StockId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stock");
        }
    }
}
