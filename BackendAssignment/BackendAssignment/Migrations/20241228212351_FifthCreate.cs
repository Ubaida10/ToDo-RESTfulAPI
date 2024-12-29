using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAssignment.Migrations
{
    /// <inheritdoc />
    public partial class FifthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_AppUserId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "TodoItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_AppUserId",
                table: "TodoItems",
                newName: "IX_TodoItems_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_UserId",
                table: "TodoItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_UserId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TodoItems",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_UserId",
                table: "TodoItems",
                newName: "IX_TodoItems_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_AppUserId",
                table: "TodoItems",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
