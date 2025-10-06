using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaDigital.Migrations
{
    /// <inheritdoc />
    public partial class BookTitleChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EjemplaresDisponibles",
                table: "Books",
                newName: "StockAvailable");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Books",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "StockAvailable",
                table: "Books",
                newName: "EjemplaresDisponibles");
        }
    }
}
