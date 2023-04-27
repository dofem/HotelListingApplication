using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Application.DataAccess.Migrations
{
    public partial class defaultroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "413de894-719e-4582-95cd-10c1b839a893", "8d8d4c38-9d5b-4948-abd9-38aa106d6a57", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb1ff872-0134-47a5-bdbf-d65e425eba12", "8e51e321-3423-4d2a-bcdf-aa6c307c9028", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "413de894-719e-4582-95cd-10c1b839a893");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb1ff872-0134-47a5-bdbf-d65e425eba12");
        }
    }
}
