using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FintasticFish.Web.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumberType_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PhoneNumbersTypes_PhoneNumberTypeId",
                table: "PhoneNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PhoneNumbersTypes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "PhoneNumbers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "PhoneNumbersTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cell" },
                    { 2, "Home" },
                    { 3, "Business" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_PhoneNumberTypes",
                table: "PhoneNumbers",
                column: "PhoneNumberTypeId",
                principalTable: "PhoneNumbersTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_PhoneNumberTypes",
                table: "PhoneNumbers");

            migrationBuilder.DeleteData(
                table: "PhoneNumbersTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhoneNumbersTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhoneNumbersTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PhoneNumbersTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "PhoneNumbers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PhoneNumbersTypes_PhoneNumberTypeId",
                table: "PhoneNumbers",
                column: "PhoneNumberTypeId",
                principalTable: "PhoneNumbersTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
