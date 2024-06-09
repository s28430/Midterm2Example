using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GagoExampleTest.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSailboatReservationAssociationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationSailboat",
                columns: table => new
                {
                    ReservationsIdReservation = table.Column<int>(type: "int", nullable: false),
                    SailboatsIdSailboat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationSailboat", x => new { x.ReservationsIdReservation, x.SailboatsIdSailboat });
                    table.ForeignKey(
                        name: "FK_ReservationSailboat_Reservations_ReservationsIdReservation",
                        column: x => x.ReservationsIdReservation,
                        principalTable: "Reservations",
                        principalColumn: "IdReservation",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ReservationSailboat_Sailboats_SailboatsIdSailboat",
                        column: x => x.SailboatsIdSailboat,
                        principalTable: "Sailboats",
                        principalColumn: "IdSailboat",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSailboat_SailboatsIdSailboat",
                table: "ReservationSailboat",
                column: "SailboatsIdSailboat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationSailboat");
        }
    }
}
