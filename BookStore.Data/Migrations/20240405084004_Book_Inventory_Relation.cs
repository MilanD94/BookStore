using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Book_Inventory_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InventoryId",
                table: "Book",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_InventoryId",
                table: "Book",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Inventory_InventoryId",
                table: "Book",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Inventory_InventoryId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_InventoryId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Book");
        }
    }
}
