using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeedCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // insert seed data for all malaysian cities into the Cities table
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Kuala Lumpur')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // remove seed data
            migrationBuilder.Sql("DELETE FROM Cities WHERE Name = 'Kuala Lumpur'");
        }
    }
}
