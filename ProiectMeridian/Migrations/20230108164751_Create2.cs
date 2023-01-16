using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMeridian.Migrations
{
    public partial class Create2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistribuitorID",
                table: "Telefon",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "Telefon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Distribuitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distribuitori = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuitor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producatori = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_DistribuitorID",
                table: "Telefon",
                column: "DistribuitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_ProducatorID",
                table: "Telefon",
                column: "ProducatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_Distribuitor_DistribuitorID",
                table: "Telefon",
                column: "DistribuitorID",
                principalTable: "Distribuitor",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_Producator_ProducatorID",
                table: "Telefon",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefon_Distribuitor_DistribuitorID",
                table: "Telefon");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefon_Producator_ProducatorID",
                table: "Telefon");

            migrationBuilder.DropTable(
                name: "Distribuitor");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropIndex(
                name: "IX_Telefon_DistribuitorID",
                table: "Telefon");

            migrationBuilder.DropIndex(
                name: "IX_Telefon_ProducatorID",
                table: "Telefon");

            migrationBuilder.DropColumn(
                name: "DistribuitorID",
                table: "Telefon");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "Telefon");
        }
    }
}
