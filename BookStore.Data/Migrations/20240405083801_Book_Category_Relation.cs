using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Book_Category_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Category",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_BookId",
                table: "Category",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Book_BookId",
                table: "Category",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Book_BookId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_BookId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Category");
        }
    }
}
