using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Midterm2Ex.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSongArtisAssociationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Songs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "IdSong");

            migrationBuilder.CreateTable(
                name: "SongArtist",
                columns: table => new
                {
                    IdArtist = table.Column<int>(type: "int", nullable: false),
                    IdSong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongArtist", x => new { x.IdArtist, x.IdSong });
                    table.ForeignKey(
                        name: "FK_SongArtist_Artists_IdArtist",
                        column: x => x.IdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongArtist_Songs_IdSong",
                        column: x => x.IdSong,
                        principalTable: "Songs",
                        principalColumn: "IdSong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongArtist_IdSong",
                table: "SongArtist",
                column: "IdSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Song");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "IdSong");
        }
    }
}
