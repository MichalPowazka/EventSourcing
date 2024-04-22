using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSourcing.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinion_Rooms_RoomId",
                table: "Opinion");

            migrationBuilder.DropTable(
                name: "RoomToReservation");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Opinion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash" },
                values: new object[] { "370de1ba-6fe3-4363-974a-1b56aaf9d41f", false, "AQAAAAIAAYagAAAAEDDPjNnXcjkYXK/HkXEE9bsywRRDjiwni1dOFgmcU4S/PxA4r6G+WIlkoxanb2EmnA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Opinion_Rooms_RoomId",
                table: "Opinion",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinion_Rooms_RoomId",
                table: "Opinion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Opinion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "RoomToReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    StreamId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomToReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomToReservation_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b365e8b-be6a-448a-be35-faca65bb8492", "AQAAAAIAAYagAAAAEBp6sfLQEGq4wGO5Vio0CUVA1kpnUKurEkWS1zAurl+Mv+mhJmuG86G3K/MIIsqkyg==" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomToReservation_RoomId",
                table: "RoomToReservation",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinion_Rooms_RoomId",
                table: "Opinion",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
