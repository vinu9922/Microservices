using Microsoft.EntityFrameworkCore.Migrations;

namespace SegmentService.Infrastructure.Migrations
{
    public partial class Day12_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "seg",
                columns: table => new
                {
                    SegmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegmentName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg", x => x.SegmentId);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComapnyName = table.Column<string>(nullable: true),
                    Date = table.Column<int>(nullable: false),
                    StockPriceToday = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    SegmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_company_seg_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "seg",
                        principalColumn: "SegmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_company_SegmentId",
                table: "company",
                column: "SegmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "seg");
        }
    }
}
