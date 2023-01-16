using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMeridian.Migrations
{
    public partial class Create13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Buying",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    TelefonID = table.Column<int>(type: "int", nullable: true),
                    DateofBuiying = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buying", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Buying_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Buying_Telefon_TelefonID",
                        column: x => x.TelefonID,
                        principalTable: "Telefon",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buying_ClientID",
                table: "Buying",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Buying_TelefonID",
                table: "Buying",
                column: "TelefonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buying");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
