using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinhDinhFoodWeb.Migrations
{
    public partial class AddTableTokenAndFixNonNullDatafieldsAndMakeUniqueUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminUSerName",
                table: "Admin",
                newName: "AdminUserName");

            migrationBuilder.AlterColumn<string>(
                name: "RatingContent",
                table: "ProductRating",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerImage",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerUserName",
                table: "Customer",
                column: "CustomerUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AdminUserName",
                table: "Admin",
                column: "AdminUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerUserName",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Admin_AdminUserName",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "AdminUserName",
                table: "Admin",
                newName: "AdminUSerName");

            migrationBuilder.AlterColumn<string>(
                name: "RatingContent",
                table: "ProductRating",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerImage",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
