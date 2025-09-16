using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockWebApi.Migrations
{
    /// <inheritdoc />
    public partial class initTradeAndLastPrize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LastUpdatePrize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastUpdatePrize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyinAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeAmount = table.Column<int>(type: "int", nullable: false),
                    TradePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TradeTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradesData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastUpdatePrize");

            migrationBuilder.DropTable(
                name: "TradesData");
        }
    }
}
