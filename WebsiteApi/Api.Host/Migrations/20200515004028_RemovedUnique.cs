using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Host.Migrations
{
    public partial class RemovedUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebSites_Categories_CategoryId",
                table: "WebSites");

            migrationBuilder.DropIndex(
                name: "IX_WebSites_Url",
                table: "WebSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorys");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "WebSites",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WebSites_Categorys_CategoryId",
                table: "WebSites",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebSites_Categorys_CategoryId",
                table: "WebSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "WebSites",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WebSites_Url",
                table: "WebSites",
                column: "Url",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WebSites_Categories_CategoryId",
                table: "WebSites",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
