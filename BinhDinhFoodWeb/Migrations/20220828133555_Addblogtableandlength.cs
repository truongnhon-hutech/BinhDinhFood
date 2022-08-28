using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinhDinhFoodWeb.Migrations
{
    public partial class Addblogtableandlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogImage",
                table: "Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogImage",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
