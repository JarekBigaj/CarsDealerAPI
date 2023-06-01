using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsDealerApi.Migrations
{
    /// <inheritdoc />
    public partial class updatePurchase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Cars_CarId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CarId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CarId",
                table: "Purchases",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Cars_CarId",
                table: "Purchases",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Cars_CarId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CarId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Purchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CarId",
                table: "Purchases",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Cars_CarId",
                table: "Purchases",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
