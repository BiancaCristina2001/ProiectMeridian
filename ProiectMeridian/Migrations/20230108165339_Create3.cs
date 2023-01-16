using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMeridian.Migrations
{
    public partial class Create3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Nume",
                table: "Telefon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nume",
                table: "Telefon");
        }
    }
}
