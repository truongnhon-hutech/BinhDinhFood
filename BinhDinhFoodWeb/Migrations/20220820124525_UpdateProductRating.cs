using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinhDinhFoodWeb.Migrations
{
    public partial class UpdateProductRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductRatingDateCreated",
                table: "ProductRating",
                newName: "PRDateCreated");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ProductRating",
                newName: "RatingContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatingContent",
                table: "ProductRating",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "PRDateCreated",
                table: "ProductRating",
                newName: "ProductRatingDateCreated");
        }
    }
}
