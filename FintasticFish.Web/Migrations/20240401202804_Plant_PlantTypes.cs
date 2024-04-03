using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FintasticFish.Web.Migrations
{
    /// <inheritdoc />
    public partial class Plant_PlantTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "SupplierPhoneNumber",
                newName: "SupplierPhoneNumbers");

            migrationBuilder.RenameTable(
                name: "CustomerPhoneNumber",
                newName: "CustomerPhoneNumbers");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierPhoneNumber_SupplierId",
                table: "SupplierPhoneNumbers",
                newName: "IX_SupplierPhoneNumbers_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierPhoneNumber_PhoneNumberId",
                table: "SupplierPhoneNumbers",
                newName: "IX_SupplierPhoneNumbers_PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhoneNumber_PhoneNumberId",
                table: "CustomerPhoneNumbers",
                newName: "IX_CustomerPhoneNumbers_PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhoneNumber_CustomerId",
                table: "CustomerPhoneNumbers",
                newName: "IX_CustomerPhoneNumbers_CustomerId");

            migrationBuilder.CreateTable(
                name: "PlantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    SalePrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Taxable = table.Column<bool>(type: "bit", nullable: false),
                    Stock = table.Column<bool>(type: "bit", nullable: false),
                    SaleStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SaleEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PlantTypeId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    MearsurementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_Measurements",
                        column: x => x.MearsurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plant_PlantTypes",
                        column: x => x.PlantTypeId,
                        principalTable: "PlantTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "PlantTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Submerged" },
                    { 2, "Emergent" },
                    { 3, "Free Floating" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_MearsurementId",
                table: "Plants",
                column: "MearsurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantTypeId",
                table: "Plants",
                column: "PlantTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "PlantTypes");

            migrationBuilder.RenameTable(
                name: "SupplierPhoneNumbers",
                newName: "SupplierPhoneNumber");

            migrationBuilder.RenameTable(
                name: "CustomerPhoneNumbers",
                newName: "CustomerPhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierPhoneNumbers_SupplierId",
                table: "SupplierPhoneNumber",
                newName: "IX_SupplierPhoneNumber_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierPhoneNumbers_PhoneNumberId",
                table: "SupplierPhoneNumber",
                newName: "IX_SupplierPhoneNumber_PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhoneNumbers_PhoneNumberId",
                table: "CustomerPhoneNumber",
                newName: "IX_CustomerPhoneNumber_PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhoneNumbers_CustomerId",
                table: "CustomerPhoneNumber",
                newName: "IX_CustomerPhoneNumber_CustomerId");
        }
    }
}
