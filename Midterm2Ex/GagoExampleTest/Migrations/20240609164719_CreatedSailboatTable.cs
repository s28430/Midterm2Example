using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GagoExampleTest.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSailboatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sailboats",
                columns: table => new
                {
                    IdSailboat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sailboats", x => x.IdSailboat);
                    table.ForeignKey(
                        name: "FK_Sailboats_BoatStandards_IdBoatStandard",
                        column: x => x.IdBoatStandard,
                        principalTable: "BoatStandards",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sailboats_IdBoatStandard",
                table: "Sailboats",
                column: "IdBoatStandard");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sailboats");
        }
    }
}
