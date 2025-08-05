using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Update08051 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBaseInfoData");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "UserBaseInfoData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "UserBaseInfoData");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserBaseInfoData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
