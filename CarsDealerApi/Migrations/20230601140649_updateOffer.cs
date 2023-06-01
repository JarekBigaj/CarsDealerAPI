using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsDealerApi.Migrations
{
    /// <inheritdoc />
    public partial class updateOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAcepted",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAcepted",
                table: "Offers");
        }
    }
}
