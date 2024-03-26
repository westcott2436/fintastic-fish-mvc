using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintasticFish.Web.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumber_Customer_Relations_TableCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerPhoneNumber",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CustomerPhoneNumber_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerPhoneNumber_PhoneNumber",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumber_CustomerId",
                table: "CustomerPhoneNumber",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumber_PhoneNumberId",
                table: "CustomerPhoneNumber",
                column: "PhoneNumberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPhoneNumber");
        }
    }
}
