using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Practice02_01.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shipDocuments",
                columns: table => new
                {
                    shipDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerRuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    driverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    totalBoxes = table.Column<int>(type: "int", nullable: false),
                    totalWeight = table.Column<int>(type: "int", nullable: false),
                    totalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipDocuments", x => x.shipDocumentId);
                });

            migrationBuilder.CreateTable(
                name: "shipDocumentDetails",
                columns: table => new
                {
                    shipDocumentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    subTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    shipDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipDocumentDetails", x => x.shipDocumentDetailId);
                    table.ForeignKey(
                        name: "FK_shipDocumentDetails_shipDocuments_shipDocumentId",
                        column: x => x.shipDocumentId,
                        principalTable: "shipDocuments",
                        principalColumn: "shipDocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shipDocumentDetails_shipDocumentId",
                table: "shipDocumentDetails",
                column: "shipDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shipDocumentDetails");

            migrationBuilder.DropTable(
                name: "shipDocuments");
        }
    }
}
