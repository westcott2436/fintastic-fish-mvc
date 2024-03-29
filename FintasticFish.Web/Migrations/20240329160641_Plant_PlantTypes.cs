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
            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumbersTypes",
                table: "PhoneNumbersTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumbers",
                table: "PhoneNumbers");

            migrationBuilder.RenameTable(
                name: "SupplierPhoneNumber",
                newName: "SupplierPhoneNumbers");

            migrationBuilder.RenameTable(
                name: "PhoneNumbersTypes",
                newName: "PhoneNumberType");

            migrationBuilder.RenameTable(
                name: "PhoneNumbers",
                newName: "PhoneNumber");

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
                name: "IX_PhoneNumbers_PhoneNumberTypeId",
                table: "PhoneNumber",
                newName: "IX_PhoneNumber_PhoneNumberTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhoneNumber_PhoneNumberId",
                table: "CustomerPhoneNumbers",
                newName: "IX_CustomerPhoneNumbers_PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhoneNumber_CustomerId",
                table: "CustomerPhoneNumbers",
                newName: "IX_CustomerPhoneNumbers_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumberType",
                table: "PhoneNumberType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumber",
                table: "PhoneNumber",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlantType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
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
                    table.PrimaryKey("PK_Plant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_Measurements",
                        column: x => x.MearsurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plant_PlantTypes",
                        column: x => x.PlantTypeId,
                        principalTable: "PlantType",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "PlantType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Submerged" },
                    { 2, "Emergent" },
                    { 3, "Free Floating" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_MearsurementId",
                table: "Plant",
                column: "MearsurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_PlantTypeId",
                table: "Plant",
                column: "PlantTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "PlantType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumberType",
                table: "PhoneNumberType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumber",
                table: "PhoneNumber");

            migrationBuilder.RenameTable(
                name: "SupplierPhoneNumbers",
                newName: "SupplierPhoneNumber");

            migrationBuilder.RenameTable(
                name: "PhoneNumberType",
                newName: "PhoneNumbersTypes");

            migrationBuilder.RenameTable(
                name: "PhoneNumber",
                newName: "PhoneNumbers");

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
                name: "IX_PhoneNumber_PhoneNumberTypeId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_PhoneNumberTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhoneNumbers_PhoneNumberId",
                table: "CustomerPhoneNumber",
                newName: "IX_CustomerPhoneNumber_PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPhoneNumbers_CustomerId",
                table: "CustomerPhoneNumber",
                newName: "IX_CustomerPhoneNumber_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumbersTypes",
                table: "PhoneNumbersTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumbers",
                table: "PhoneNumbers",
                column: "Id");
        }
    }
}
