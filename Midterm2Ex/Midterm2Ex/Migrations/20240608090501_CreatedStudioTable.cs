using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Midterm2Ex.Migrations
{
    /// <inheritdoc />
    public partial class CreatedStudioTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongArtist_Artists_IdArtist",
                table: "SongArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtist_Songs_IdSong",
                table: "SongArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongArtist",
                table: "SongArtist");

            migrationBuilder.RenameTable(
                name: "SongArtist",
                newName: "SongArtists");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtist_IdSong",
                table: "SongArtists",
                newName: "IX_SongArtists_IdSong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongArtists",
                table: "SongArtists",
                columns: new[] { "IdArtist", "IdSong" });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    IdStudio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.IdStudio);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Artists_IdArtist",
                table: "SongArtists",
                column: "IdArtist",
                principalTable: "Artists",
                principalColumn: "IdArtist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Songs_IdSong",
                table: "SongArtists",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Artists_IdArtist",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Songs_IdSong",
                table: "SongArtists");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongArtists",
                table: "SongArtists");

            migrationBuilder.RenameTable(
                name: "SongArtists",
                newName: "SongArtist");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtists_IdSong",
                table: "SongArtist",
                newName: "IX_SongArtist_IdSong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongArtist",
                table: "SongArtist",
                columns: new[] { "IdArtist", "IdSong" });

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtist_Artists_IdArtist",
                table: "SongArtist",
                column: "IdArtist",
                principalTable: "Artists",
                principalColumn: "IdArtist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtist_Songs_IdSong",
                table: "SongArtist",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
