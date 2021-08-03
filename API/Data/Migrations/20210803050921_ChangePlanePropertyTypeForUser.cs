using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ChangePlanePropertyTypeForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoritePlane",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "FavoritePlaneId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoritePlaneId",
                table: "AspNetUsers",
                column: "FavoritePlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Plane_FavoritePlaneId",
                table: "AspNetUsers",
                column: "FavoritePlaneId",
                principalTable: "Plane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Plane_FavoritePlaneId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoritePlaneId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoritePlaneId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FavoritePlane",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }
    }
}
