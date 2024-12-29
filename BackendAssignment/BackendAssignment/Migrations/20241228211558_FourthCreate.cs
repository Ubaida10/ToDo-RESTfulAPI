using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAssignment.Migrations
{
    /// <inheritdoc />
    public partial class FourthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AppUsers_AppUserId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_AppUserId",
                table: "TodoItems",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_AppUserId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "TodoItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_AppUsers_AppUserId",
                table: "TodoItems",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }
    }
}
