using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aura.LonelySatan.Migrations
{
    /// <inheritdoc />
    public partial class addauditcardtransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "CardTransactions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "CardTransactions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "CardTransactions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "CardTransactions",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CardTransactions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "CardTransactions",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "CardTransactions",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "CardTransactions");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CardTransactions");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "CardTransactions");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "CardTransactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CardTransactions");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "CardTransactions");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "CardTransactions");
        }
    }
}
