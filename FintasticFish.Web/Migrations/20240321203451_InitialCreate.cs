using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FintasticFish.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AggressionLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggressionLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AggressionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggressionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    SalePrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Taxable = table.Column<bool>(type: "bit", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    SaleStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SaleEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FoodTypeId = table.Column<int>(type: "int", nullable: false),
                    MearsurementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_FoodTypes",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Foods_Measurements",
                        column: x => x.MearsurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Street2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    AddressTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypes",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Countries",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_States",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SupplierTypeId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Countries",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suppliers_Suppliers",
                        column: x => x.SupplierTypeId,
                        principalTable: "SupplierTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomersAddresses",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CustomersAddresses_Addresses",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomersAddresses_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "smallmoney", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Addresses",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_OrderStatuses1",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Species = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MeasurementId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Stock = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecialOrder = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    WaterTypeId = table.Column<int>(type: "int", nullable: false),
                    AggressionLevelId = table.Column<int>(type: "int", nullable: false),
                    AggressionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fishes_AggressionLevels",
                        column: x => x.AggressionLevelId,
                        principalTable: "AggressionLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fishes_AggressionTypes",
                        column: x => x.AggressionTypeId,
                        principalTable: "AggressionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fishes_Countries",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fishes_Measurements",
                        column: x => x.MeasurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fishes_Suppliers",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fishes_WaterType",
                        column: x => x.WaterTypeId,
                        principalTable: "WaterType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrdersFoods",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_OrdersFoods_Foods",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdersFoods_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FishesFoods",
                columns: table => new
                {
                    FishId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_FishesFoods_Fishes",
                        column: x => x.FishId,
                        principalTable: "Fishes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FishesFoods_Foods",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrdersFishes",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_OrdersFishes_Fishes",
                        column: x => x.FishId,
                        principalTable: "Fishes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdersFishes_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Home" },
                    { 2, "Mailing" },
                    { 3, "Business" }
                });

            migrationBuilder.InsertData(
                table: "AggressionLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Docile" },
                    { 2, "Aggressive" },
                    { 3, "Moderate" }
                });

            migrationBuilder.InsertData(
                table: "AggressionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Territorial" },
                    { 2, "Social" },
                    { 3, "Time" },
                    { 4, "Temperature" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "North America" },
                    { 2, "South America" },
                    { 3, "Africa" },
                    { 4, "Asia" }
                });

            migrationBuilder.InsertData(
                table: "FoodTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Flake" },
                    { 2, "Pellet" },
                    { 3, "Live" },
                    { 4, "Frozen" },
                    { 5, "Waffer" },
                    { 6, "Organic" }
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Inches, in" },
                    { 2, "Centimeters, cm" },
                    { 3, "Millimeters, mm" },
                    { 4, "Pounds, lbs" },
                    { 5, "Ounces, oz" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alabama" },
                    { 2, "Alaska" },
                    { 3, "Arizona" },
                    { 4, "Arkansas" },
                    { 5, "California" },
                    { 6, "Colorado" },
                    { 7, "Connecticut" },
                    { 8, "Delaware" },
                    { 9, "Florida" },
                    { 10, "Georgia" },
                    { 11, "Hawaii" },
                    { 12, "Idaho" },
                    { 13, "Illinois" },
                    { 14, "Indiana" },
                    { 15, "Iowa" },
                    { 16, "Kansas" },
                    { 17, "Kentucky" },
                    { 18, "Louisiana" },
                    { 19, "Maine" },
                    { 20, "Maryland" },
                    { 21, "Massachusetts" },
                    { 22, "Michigan" },
                    { 23, "Minnesota" },
                    { 24, "Mississippi" },
                    { 25, "Missouri" },
                    { 26, "Montana" },
                    { 27, "Nebraska" },
                    { 28, "Nevada" },
                    { 29, "New Hampshire" },
                    { 30, "New Jersey" },
                    { 31, "New Mexico" },
                    { 32, "New York" },
                    { 33, "North Carolina" },
                    { 34, "North Dakota" },
                    { 35, "Ohio" },
                    { 36, "Oklahoma" },
                    { 37, "Oregon" },
                    { 38, "Pennsylvania" },
                    { 39, "Rhode Island" },
                    { 40, "South Carolina" },
                    { 41, "South Dakota" },
                    { 42, "Tennessee" },
                    { 43, "Texas" },
                    { 44, "Utah" },
                    { 45, "Vermont" },
                    { 46, "Virginia" },
                    { 47, "Washington" },
                    { 48, "West Virginia" },
                    { 49, "Wisconsin" },
                    { 50, "Wyoming" }
                });

            migrationBuilder.InsertData(
                table: "SupplierTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fish" },
                    { 2, "Food" },
                    { 3, "Consumables" },
                    { 4, "Plants" }
                });

            migrationBuilder.InsertData(
                table: "WaterType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fresh" },
                    { 2, "Salt" },
                    { 3, "Brackish" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersAddresses_AddressId",
                table: "CustomersAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersAddresses_CustomerId",
                table: "CustomersAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_AggressionLevelId",
                table: "Fishes",
                column: "AggressionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_AggressionTypeId",
                table: "Fishes",
                column: "AggressionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_CountryId",
                table: "Fishes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_MeasurementId",
                table: "Fishes",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_SupplierId",
                table: "Fishes",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_WaterTypeId",
                table: "Fishes",
                column: "WaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FishesFoods_FishId",
                table: "FishesFoods",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_FishesFoods_FoodId",
                table: "FishesFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodTypeId",
                table: "Foods",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MearsurementId",
                table: "Foods",
                column: "MearsurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersFishes_FishId",
                table: "OrdersFishes",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersFishes_OrderId",
                table: "OrdersFishes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersFoods_FoodId",
                table: "OrdersFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersFoods_OrderId",
                table: "OrdersFoods",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryId",
                table: "Suppliers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierTypeId",
                table: "Suppliers",
                column: "SupplierTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersAddresses");

            migrationBuilder.DropTable(
                name: "FishesFoods");

            migrationBuilder.DropTable(
                name: "OrdersFishes");

            migrationBuilder.DropTable(
                name: "OrdersFoods");

            migrationBuilder.DropTable(
                name: "Fishes");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "AggressionLevels");

            migrationBuilder.DropTable(
                name: "AggressionTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "WaterType");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "SupplierTypes");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
