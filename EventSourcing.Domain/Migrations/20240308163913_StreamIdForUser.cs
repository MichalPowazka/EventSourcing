using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSourcing.Domain.Migrations
{
    /// <inheritdoc />
    public partial class StreamIdForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StreamId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreamId",
                table: "AspNetUsers");
        }
    }
}
