using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApi.Persistence.Migrations
{
    public partial class prdimagefileshowcase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Showcase",
                table: "ProductImageFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Showcase",
                table: "ProductImageFiles");
        }
    }
}
