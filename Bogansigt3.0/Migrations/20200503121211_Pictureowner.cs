using Microsoft.EntityFrameworkCore.Migrations;

namespace Bogansigt3._0.Migrations
{
    public partial class Pictureowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureOwnerId",
                table: "Picture",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEAHCPgmZxkRLfqVsfsfUM+Ohg/F9KIahlYs1Myzcn7vZr6+LlMhj182Q5WUzGzQRA==");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_PictureOwnerId",
                table: "Picture",
                column: "PictureOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_AspNetUsers_PictureOwnerId",
                table: "Picture",
                column: "PictureOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_AspNetUsers_PictureOwnerId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_PictureOwnerId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "PictureOwnerId",
                table: "Picture");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELyGukgIQqsy0BEfeC8hOFzbXgva5oBgTDSyxwZdGL6gZxLBiplZFjI076cgfDXT6g==");
        }
    }
}
