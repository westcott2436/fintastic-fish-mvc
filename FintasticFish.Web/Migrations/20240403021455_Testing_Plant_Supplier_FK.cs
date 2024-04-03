using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintasticFish.Web.Migrations
{
    /// <inheritdoc />
    public partial class Testing_Plant_Supplier_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Foods_Suppliers_SupplierId",
            //    table: "Foods");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Plants_Suppliers_SupplierId",
            //    table: "Plants");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Suppliers",
                table: "Foods",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Suppliers",
                table: "Plants",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Suppliers",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Suppliers",
                table: "Plants");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Foods_Suppliers_SupplierId",
            //    table: "Foods",
            //    column: "SupplierId",
            //    principalTable: "Suppliers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Plants_Suppliers_SupplierId",
            //    table: "Plants",
            //    column: "SupplierId",
            //    principalTable: "Suppliers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
