using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aura.LonelySatan.Migrations
{
    /// <inheritdoc />
    public partial class updateuserotp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOtps_AbpUsers_UserId",
                table: "UserOtps");

            migrationBuilder.DropIndex(
                name: "IX_UserOtps_UserId",
                table: "UserOtps");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserOtps",
                newName: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Otp",
                table: "UserOtps",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "UserOtps",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Otp",
                table: "UserOtps",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_UserOtps_UserId",
                table: "UserOtps",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOtps_AbpUsers_UserId",
                table: "UserOtps",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
