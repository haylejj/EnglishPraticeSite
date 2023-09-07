using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addnewdbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Words_WordId",
                table: "Favorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite");

            migrationBuilder.RenameTable(
                name: "Favorite",
                newName: "Favorites");

            migrationBuilder.RenameIndex(
                name: "IX_Favorite_WordId",
                table: "Favorites",
                newName: "IX_Favorites_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Words_WordId",
                table: "Favorites",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Words_WordId",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favorite");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_WordId",
                table: "Favorite",
                newName: "IX_Favorite_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Words_WordId",
                table: "Favorite",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
