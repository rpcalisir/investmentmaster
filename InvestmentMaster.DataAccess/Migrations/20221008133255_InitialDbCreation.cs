﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentMaster.DataAccess.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FONKODU = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FONUNVAN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FONTURACIKLAMA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Funds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funds");
        }
    }
}
