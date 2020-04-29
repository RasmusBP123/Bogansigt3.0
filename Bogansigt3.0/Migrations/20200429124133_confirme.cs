using Microsoft.EntityFrameworkCore.Migrations;

namespace Bogansigt3._0.Migrations
{
    public partial class confirme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                columns: new[] { "EmailConfirmed", "PasswordHash" },
                values: new object[] { true, "AQAAAAEAACcQAAAAELOIyqjsNxAJw2m03zgcbo7aOocogsYAY8dEVM4gPbsT6P5LlJyHBeCmcZUdRaAccA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBBYN0MLRgmLHdPKlOSwGizmcmeCKFlbdOCC+Z2YnnmYGrY8skVDv7hEDvQYB8538g==");
        }
    }
}
