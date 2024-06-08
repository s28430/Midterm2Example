using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Midterm2Ex.Migrations
{
    /// <inheritdoc />
    public partial class AddedFKToSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Studios_IdAlbum",
                table: "Album");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "IdAlbum",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_IdAlbum",
                table: "Songs",
                column: "IdAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Studios_IdAlbum",
                table: "Albums",
                column: "IdAlbum",
                principalTable: "Studios",
                principalColumn: "IdStudio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_IdAlbum",
                table: "Songs",
                column: "IdAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Studios_IdAlbum",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_IdAlbum",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_IdAlbum",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "IdAlbum",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "IdAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Studios_IdAlbum",
                table: "Album",
                column: "IdAlbum",
                principalTable: "Studios",
                principalColumn: "IdStudio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
