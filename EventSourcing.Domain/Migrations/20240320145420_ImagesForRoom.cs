using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSourcing.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ImagesForRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
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
                values: new object[] { "80d631c6-0d9f-4098-af42-6605a5a2ce1f", "AQAAAAIAAYagAAAAEJRBNqsjckfQwGrYyF4FxiwXl1wlNoFkJQ2topuxAjgSOptCQVQymHjzKr2llpA/hQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e813edd-207c-47c5-b5fa-050a37873a4b", "AQAAAAIAAYagAAAAEJvAK2F99L+Y0v85FHTk6rPZ9Jj4DDJra9hV0/yjNhox/tiyf/wBKlzfsd4ci7h7VQ==" });
        }
    }
}
