using Microsoft.EntityFrameworkCore.Migrations;

namespace Bogansigt3._0.Migrations
{
    public partial class admin123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBBYN0MLRgmLHdPKlOSwGizmcmeCKFlbdOCC+Z2YnnmYGrY8skVDv7hEDvQYB8538g==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIoTzCn1mMUKoattpTx4H7bHgHDmm96znSR4nGwcPizlKMzHK4n0ScNeD3JiNmI7CA==");
        }
    }
}
