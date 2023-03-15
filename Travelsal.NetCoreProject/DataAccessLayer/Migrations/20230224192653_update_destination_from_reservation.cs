using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatedestinationfromreservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_DestinationsDestinationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DestinationsDestinationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DestinationsDestinationID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Reservations",
                newName: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DestinationID",
                table: "Reservations",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Destinations_DestinationID",
                table: "Reservations",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_DestinationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DestinationID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DestinationID",
                table: "Reservations",
                newName: "Destination");

            migrationBuilder.AddColumn<int>(
                name: "DestinationsDestinationID",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DestinationsDestinationID",
                table: "Reservations",
                column: "DestinationsDestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Destinations_DestinationsDestinationID",
                table: "Reservations",
                column: "DestinationsDestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID");
        }
    }
}
