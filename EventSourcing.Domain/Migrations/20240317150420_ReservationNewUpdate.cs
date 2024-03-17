using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSourcing.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ReservationNewUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ControlValue",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e813edd-207c-47c5-b5fa-050a37873a4b", "AQAAAAIAAYagAAAAEJvAK2F99L+Y0v85FHTk6rPZ9Jj4DDJra9hV0/yjNhox/tiyf/wBKlzfsd4ci7h7VQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControlValue",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5a874a3e-5a45-47a0-8b43-ec555a5f5b13", "AQAAAAIAAYagAAAAEHVEr1lQIjYa9Nk0biyen2yYFauvIgExL5VW3sdPABaN8Y5QUCgNJI2XYs7Z6i0XYQ==" });
        }
    }
}
