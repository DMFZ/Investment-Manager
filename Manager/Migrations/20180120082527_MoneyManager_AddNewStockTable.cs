using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Manager.Migrations
{
    public partial class MoneyManager_AddNewStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stockDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    avgPrice = table.Column<string>(nullable: true),
                    change = table.Column<string>(nullable: true),
                    currentInvestmentValue = table.Column<string>(nullable: true),
                    currentSharePrice = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    quantity = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    stockName = table.Column<string>(nullable: true),
                    totalInvestmentValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stockDetails");
        }
    }
}
