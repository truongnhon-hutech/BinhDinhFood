using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinhDinhFoodWeb.Migrations
{
    public partial class ADDfieldsRatinginProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductRating",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductRating",
                table: "Product");
        }
    }
}
