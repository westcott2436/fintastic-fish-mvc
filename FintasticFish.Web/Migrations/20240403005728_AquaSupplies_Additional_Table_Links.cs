using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintasticFish.Web.Migrations
{
    /// <inheritdoc />
    public partial class AquaSupplies_Additional_Table_Links : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AquaSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    SalePrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SaleStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SaleEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MearsurementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AquaSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AquaSupplies_Measurements",
                        column: x => x.MearsurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AquaSupplies_Suppliers",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_SupplierId",
                table: "Plants",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_SupplierId",
                table: "Foods",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AquaSupplies_MearsurementId",
                table: "AquaSupplies",
                column: "MearsurementId");

            migrationBuilder.CreateIndex(
                name: "IX_AquaSupplies_SupplierId",
                table: "AquaSupplies",
                column: "SupplierId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Foods_Suppliers",
            //    table: "Foods",
            //    column: "SupplierId",
            //    principalTable: "Suppliers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Plants_Suppliers",
            //    table: "Plants",
            //    column: "SupplierId",
            //    principalTable: "Suppliers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Foods_Suppliers_SupplierId",
            //    table: "Foods");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Plants_Suppliers_SupplierId",
            //    table: "Plants");

            migrationBuilder.DropTable(
                name: "AquaSupplies");

            migrationBuilder.DropIndex(
                name: "IX_Plants_SupplierId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Foods_SupplierId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Foods");
        }
    }
}
