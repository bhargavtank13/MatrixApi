using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matrix.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RegionalSaleDirectors",
                columns: table => new
                {
                    RegionalSaleDirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionalSaleDirectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionalSaleDirectorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionalSaleDirectors", x => x.RegionalSaleDirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Sourcings",
                columns: table => new
                {
                    SourcingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourcingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourcingEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sourcings", x => x.SourcingID);
                });

            migrationBuilder.CreateTable(
                name: "SalesReps",
                columns: table => new
                {
                    SalesRepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleRepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleRepEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionalSaleDirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReps", x => x.SalesRepId);
                    table.ForeignKey(
                        name: "FK_SalesReps_RegionalSaleDirectors_RegionalSaleDirectorId",
                        column: x => x.RegionalSaleDirectorId,
                        principalTable: "RegionalSaleDirectors",
                        principalColumn: "RegionalSaleDirectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    ItemGoupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourcingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.ItemGoupId);
                    table.ForeignKey(
                        name: "FK_ItemGroups_Sourcings_SourcingId",
                        column: x => x.SourcingId,
                        principalTable: "Sourcings",
                        principalColumn: "SourcingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    QuoteNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleRepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesRepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionalSaleDirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFQNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourcingNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuggestedSalesPrice = table.Column<int>(type: "int", nullable: false),
                    HTSCode = table.Column<int>(type: "int", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreightTerms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FobPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFQStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_RegionalSaleDirectors_RegionalSaleDirectorId",
                        column: x => x.RegionalSaleDirectorId,
                        principalTable: "RegionalSaleDirectors",
                        principalColumn: "RegionalSaleDirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_SalesReps_SalesRepId",
                        column: x => x.SalesRepId,
                        principalTable: "SalesReps",
                        principalColumn: "SalesRepId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    HistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_History_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "SalesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepeatItems",
                columns: table => new
                {
                    RepeatItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    CurrentItemNumber = table.Column<int>(type: "int", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedAnnualUsage = table.Column<int>(type: "int", nullable: false),
                    EstimatedCustomerSpend = table.Column<int>(type: "int", nullable: false),
                    ItemNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    PriceUnit = table.Column<int>(type: "int", nullable: false),
                    MOQ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderMultiple = table.Column<int>(type: "int", nullable: false),
                    LeadTIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PalletSize = table.Column<int>(type: "int", nullable: false),
                    PalletQTY = table.Column<int>(type: "int", nullable: false),
                    UOMType1 = table.Column<int>(type: "int", nullable: false),
                    QTY1 = table.Column<int>(type: "int", nullable: false),
                    UOMType2 = table.Column<int>(type: "int", nullable: false),
                    QTY2 = table.Column<int>(type: "int", nullable: false),
                    UOMType3 = table.Column<int>(type: "int", nullable: false),
                    QTY3 = table.Column<int>(type: "int", nullable: false),
                    IsCheckd = table.Column<bool>(type: "bit", nullable: false),
                    FullSkidDimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    MinQty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PackagingAndQtyPallet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetupCharge = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatItems", x => x.RepeatItemId);
                    table.ForeignKey(
                        name: "FK_RepeatItems_ItemGroups_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "ItemGoupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepeatItems_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "SalesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerNumber",
                table: "Customers",
                column: "CustomerNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_History_SalesId",
                table: "History",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_SourcingId",
                table: "ItemGroups",
                column: "SourcingId");

            migrationBuilder.CreateIndex(
                name: "IX_RepeatItems_ItemGroupId",
                table: "RepeatItems",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RepeatItems_SalesId",
                table: "RepeatItems",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_QuoteNumber",
                table: "Sales",
                column: "QuoteNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_RegionalSaleDirectorId",
                table: "Sales",
                column: "RegionalSaleDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesRepId",
                table: "Sales",
                column: "SalesRepId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReps_RegionalSaleDirectorId",
                table: "SalesReps",
                column: "RegionalSaleDirectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "RepeatItems");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Sourcings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SalesReps");

            migrationBuilder.DropTable(
                name: "RegionalSaleDirectors");
        }
    }
}
