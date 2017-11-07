using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarDealer.Data.Migrations
{
    public partial class AlterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_SupplaierId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "PartsCar");

            migrationBuilder.DropIndex(
                name: "IX_Parts_SupplaierId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "SupplaierId",
                table: "Parts");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PartCar",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartCar", x => new { x.CarId, x.PartId });
                    table.ForeignKey(
                        name: "FK_PartCar_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartCar_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_SupplierId",
                table: "Parts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCar_PartId",
                table: "PartCar",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_SupplierId",
                table: "Parts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_SupplierId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "PartCar");

            migrationBuilder.DropIndex(
                name: "IX_Parts_SupplierId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Parts");

            migrationBuilder.AddColumn<int>(
                name: "SupplaierId",
                table: "Parts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PartsCar",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false),
                    PartsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsCar", x => new { x.CarId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_PartsCar_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsCar_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_SupplaierId",
                table: "Parts",
                column: "SupplaierId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsCar_PartsId",
                table: "PartsCar",
                column: "PartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_SupplaierId",
                table: "Parts",
                column: "SupplaierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
