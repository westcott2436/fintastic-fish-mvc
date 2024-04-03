using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintasticFish.Web.Migrations
{
    /// <inheritdoc />
    public partial class Suppliers_To_SupplierType_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Suppliers",
                table: "Suppliers");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_SupplierType",
                table: "Suppliers",
                column: "SupplierTypeId",
                principalTable: "SupplierTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_SupplierType",
                table: "Suppliers");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Suppliers",
                table: "Suppliers",
                column: "SupplierTypeId",
                principalTable: "SupplierTypes",
                principalColumn: "Id");
        }
    }
}
