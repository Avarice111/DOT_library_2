using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Dot.Library.Web.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserID",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Message",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserID",
                table: "Message",
                newName: "IX_Message_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Message",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserId",
                table: "Message",
                newName: "IX_Message_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_UserID",
                table: "Message",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
