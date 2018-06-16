using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Manager.Migrations
{
    public partial class MoneyManager_AddMutualFundDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MFDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false,defaultValue: new Guid()),
                    Change = table.Column<double>(nullable: false),
                    CurrentInvestmentValue = table.Column<double>(nullable: false),
                    CurrentNAV = table.Column<float>(nullable: false),
                    InvestmentNAV = table.Column<float>(nullable: false),
                    MutualFundName = table.Column<string>(nullable: true),
                    ProfitLoss = table.Column<double>(nullable: false),
                    TotalInvestmentValue = table.Column<double>(nullable: false),
                    UnitsHeld = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MFDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MFDetails");
        }
    }
}
