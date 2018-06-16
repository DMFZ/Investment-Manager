﻿// <auto-generated />
using Manager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Manager.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20180127200743_MoneyManager_AddColumStatusToOptionTable")]
    partial class MoneyManager_AddColumStatusToOptionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Manager.DAL.Models.MutualFundsDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Change");

                    b.Property<float>("CurrentInvestmentValue");

                    b.Property<float>("CurrentNAV");

                    b.Property<float>("InvestmentNAV");

                    b.Property<string>("MutualFundName");

                    b.Property<float>("ProfitLoss");

                    b.Property<float>("TotalInvestmentValue");

                    b.Property<float>("UnitsHeld");

                    b.HasKey("Id");

                    b.ToTable("MFDetails");
                });

            modelBuilder.Entity("Manager.DAL.Models.OptionDetailsDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("avgPrice");

                    b.Property<float>("change");

                    b.Property<float>("currentInvestmentValue");

                    b.Property<float>("currentOptionPrice");

                    b.Property<string>("optionName");

                    b.Property<float>("profitLoss");

                    b.Property<float>("quantity");

                    b.Property<string>("status");

                    b.Property<float>("totalInvestmentValue");

                    b.HasKey("Id");

                    b.ToTable("optionDetails");
                });

            modelBuilder.Entity("Manager.DAL.Models.StockDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("avgPrice");

                    b.Property<float>("change");

                    b.Property<float>("currentInvestmentValue");

                    b.Property<float>("currentSharePrice");

                    b.Property<float>("profitLoss");

                    b.Property<float>("quantity");

                    b.Property<string>("sector");

                    b.Property<string>("status");

                    b.Property<string>("stockName");

                    b.Property<float>("totalInvestmentValue");

                    b.HasKey("Id");

                    b.ToTable("stockDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
