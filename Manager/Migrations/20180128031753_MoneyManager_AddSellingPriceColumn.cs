using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Manager.Migrations
{
    public partial class MoneyManager_AddSellingPriceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "realizedProfitLoss",
                table: "stockDetails",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sellingPrice",
                table: "stockDetails",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "realizedProfitLoss",
                table: "optionDetails",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sellingPrice",
                table: "optionDetails",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "realizedProfitLoss",
                table: "stockDetails");

            migrationBuilder.DropColumn(
                name: "sellingPrice",
                table: "stockDetails");

            migrationBuilder.DropColumn(
                name: "realizedProfitLoss",
                table: "optionDetails");

            migrationBuilder.DropColumn(
                name: "sellingPrice",
                table: "optionDetails");
        }
    }
}
