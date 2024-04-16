using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddValue_BookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Order");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Book",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "TotalAmount",
                table: "Order",
                type: "text",
                nullable: true);
        }
    }
}
