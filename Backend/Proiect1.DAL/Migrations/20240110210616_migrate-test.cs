using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect1.DAL.Migrations
{
    public partial class migratetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReviewId",
                table: "Books",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Reviews_ReviewId",
                table: "Books",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Reviews_ReviewId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReviewId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Books");
        }
    }
}
