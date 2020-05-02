using Microsoft.EntityFrameworkCore.Migrations;

namespace Bogansigt3._0.Migrations
{
    public partial class hest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEL/s/Mk+AcKj4ETRbZ2UTwksPA5aNCf+iLdQdjJc5LiN/GhTv60/Xbpfvulhb/Se4A==");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDdUozIXe9uXAbQVHcKQ9u40L1IZ0s6h/AG5e0VxCkdG35yaNmgyl12YY2CGq78dMw==");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
