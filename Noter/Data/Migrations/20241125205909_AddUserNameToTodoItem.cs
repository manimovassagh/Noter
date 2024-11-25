using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNameToTodoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AspNetUsers_UserId1",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_UserId1",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TodoItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TodoItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TodoItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "TodoItems",
                type: "TEXT",
                nullable: true);

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
    }
}
