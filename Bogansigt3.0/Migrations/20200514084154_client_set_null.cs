using Microsoft.EntityFrameworkCore.Migrations;

namespace Bogansigt3._0.Migrations
{
    public partial class client_set_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0BFBD470-5DC8-4CD2-93FE-88049B3D9E99",
                column: "ConcurrencyStamp",
                value: "65dcc6c7-5951-4e21-a400-42efddef3ec7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FA02B864-ECE7-45E4-9A03-6023AF206756",
                column: "ConcurrencyStamp",
                value: "6b3c1f46-4042-4361-b443-aba2d49d4c2b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMJAYpFtu5SuJWD3IFEd73lzARF37+l4Grx8TqRhd8HGSiW4iM+1pl6gwX0AJu2NoA==");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0BFBD470-5DC8-4CD2-93FE-88049B3D9E99",
                column: "ConcurrencyStamp",
                value: "cc14e105-b83d-4780-8abb-53cc4a041919");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FA02B864-ECE7-45E4-9A03-6023AF206756",
                column: "ConcurrencyStamp",
                value: "7364b3ab-12c1-47bf-a6a4-65fb2e71a702");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMT42S8CGlcGnAHEKpsrQrAKXO0lVc4rEUD/o9zP12W/HkNq1c2KvOBGh9fEUBKpzA==");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
