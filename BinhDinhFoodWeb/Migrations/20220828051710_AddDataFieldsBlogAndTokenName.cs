using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinhDinhFoodWeb.Migrations
{
    public partial class AddDataFieldsBlogAndTokenName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens");

            migrationBuilder.RenameTable(
                name: "Tokens",
                newName: "Token");

            migrationBuilder.AddColumn<string>(
                name: "BlogImage",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "TokenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "BlogImage",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "Tokens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens",
                column: "TokenID");
        }
    }
}
