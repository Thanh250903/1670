using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShoppingCartMvcUI.Migrations
{
    /// <inheritdoc />
    public partial class addArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Genre_GenreId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Book",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Book",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_GenreId",
                table: "Book",
                newName: "IX_Book_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Book",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Book",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                newName: "IX_Book_GenreId");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Book",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Book",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Genre_GenreId",
                table: "Book",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
