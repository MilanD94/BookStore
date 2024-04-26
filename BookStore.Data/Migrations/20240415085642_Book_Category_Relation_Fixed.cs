using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Book_Category_Relation_Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Category_BookId",
                table: "Category",
                column: "BookId",
                unique: true);

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
        }
    }
}
