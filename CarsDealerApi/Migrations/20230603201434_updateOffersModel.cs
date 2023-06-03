using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsDealerApi.Migrations
{
    /// <inheritdoc />
    public partial class updateOffersModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Cars_CarId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Cars_CarId",
                table: "Offers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Cars_CarId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Cars_CarId",
                table: "Offers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
