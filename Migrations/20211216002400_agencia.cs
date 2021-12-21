using Microsoft.EntityFrameworkCore.Migrations;

namespace Agencia.Migrations
{
    public partial class agencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    area = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.area);
                });

            migrationBuilder.CreateTable(
                name: "destinos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    retorno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataRetorno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destinos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promocaos",
                columns: table => new
                {
                    preco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    retorno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataRetorno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promocaos", x => x.preco);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "destinos");

            migrationBuilder.DropTable(
                name: "promocaos");
        }
    }
}
