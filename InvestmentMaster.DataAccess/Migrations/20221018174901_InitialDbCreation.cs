using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentMaster.DataAccess.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComparisonFunds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FONKODU = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FONUNVAN = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FONTURACIKLAMA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GETIRI1A = table.Column<double>(type: "float", nullable: true),
                    GETIRI3A = table.Column<double>(type: "float", nullable: true),
                    GETIRI6A = table.Column<double>(type: "float", nullable: true),
                    GETIRI1Y = table.Column<double>(type: "float", nullable: true),
                    GETIRIYB = table.Column<double>(type: "float", nullable: true),
                    GETIRI3Y = table.Column<double>(type: "float", nullable: true),
                    GETIRI5Y = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComparisonFunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioFunds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FONKODU = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioFunds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComparisonFunds");

            migrationBuilder.DropTable(
                name: "PortfolioFunds");
        }
    }
}
