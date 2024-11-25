using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedAtToTodoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TodoItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TodoItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_UserId1",
                table: "TodoItems",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_AspNetUsers_UserId1",
                table: "TodoItems",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AspNetUsers_UserId1",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_UserId1",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TodoItems");
        }
    }
}
