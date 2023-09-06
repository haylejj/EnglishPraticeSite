using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WordId",
                table: "Unknows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WordId",
                table: "Favorite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Unknows_WordId",
                table: "Unknows",
                column: "WordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_WordId",
                table: "Favorite",
                column: "WordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Words_WordId",
                table: "Favorite",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unknows_Words_WordId",
                table: "Unknows",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Words_WordId",
                table: "Favorite");

            migrationBuilder.DropForeignKey(
                name: "FK_Unknows_Words_WordId",
                table: "Unknows");

            migrationBuilder.DropIndex(
                name: "IX_Unknows_WordId",
                table: "Unknows");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_WordId",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "Unknows");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "Favorite");
        }
    }
}
