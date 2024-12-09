using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApi.Persistence.Migrations
{
    public partial class pathImagr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Showcase",
                table: "ProductImageFiles");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ProductImageFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "ProductImageFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductImageFiles");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "ProductImageFiles");

            migrationBuilder.AddColumn<bool>(
                name: "Showcase",
                table: "ProductImageFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
