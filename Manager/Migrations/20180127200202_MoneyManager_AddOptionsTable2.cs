using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Manager.Migrations
{
    public partial class MoneyManager_AddOptionsTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "optionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    avgPrice = table.Column<float>(nullable: false),
                    change = table.Column<float>(nullable: false),
                    currentInvestmentValue = table.Column<float>(nullable: false),
                    currentOptionPrice = table.Column<float>(nullable: false),
                    optionName = table.Column<string>(nullable: true),
                    profitLosee = table.Column<float>(nullable: false),
                    quantity = table.Column<float>(nullable: false),
                    totalInvestmentValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_optionDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "optionDetails");
        }
    }
}
