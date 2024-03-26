using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSourcing.Domain.Migrations
{
    /// <inheritdoc />
    public partial class StreamForRoomsES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomStream",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b365e8b-be6a-448a-be35-faca65bb8492", "AQAAAAIAAYagAAAAEBp6sfLQEGq4wGO5Vio0CUVA1kpnUKurEkWS1zAurl+Mv+mhJmuG86G3K/MIIsqkyg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomStream",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80d631c6-0d9f-4098-af42-6605a5a2ce1f", "AQAAAAIAAYagAAAAEJRBNqsjckfQwGrYyF4FxiwXl1wlNoFkJQ2topuxAjgSOptCQVQymHjzKr2llpA/hQ==" });
        }
    }
}
