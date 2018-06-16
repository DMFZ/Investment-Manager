using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Manager.Migrations
{
    public partial class MoneyManager_AddColumStatusToOptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profitLosee",
                table: "optionDetails",
                newName: "profitLoss");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "optionDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "optionDetails");

            migrationBuilder.RenameColumn(
                name: "profitLoss",
                table: "optionDetails",
                newName: "profitLosee");
        }
    }
}
