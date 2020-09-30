using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class DeafioMvc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id_Client = table.Column<string>(type: "varchar(40)", nullable: false),
                    Name_Client = table.Column<string>(type: "varchar(40)", nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id_Client);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
