using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class adddestinationfromreservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Destination",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_DestinationsDestinationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DestinationsDestinationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DestinationsDestinationID",
                table: "Reservations");
        }
    }
}
