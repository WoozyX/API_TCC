using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conexao.Migrations
{
    public partial class Migração : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imei_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nascimento_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plano_Cliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsStatusPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRelacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DsTipoRelacionamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRelacionamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposOcorrencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsTiposOcorrencias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icTipoOcorrencia = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposOcorrencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel_contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contato_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagens_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogMovimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogMovimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogMovimentacao_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InRelacionamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FimRelacionamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relacionamento_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MrPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PxPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VlPagamento = table.Column<float>(type: "real", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    StatusPagamentoId = table.Column<int>(type: "int", nullable: true),
                    StatusPagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_StatusPagamentos_StatusPagamentoId",
                        column: x => x.StatusPagamentoId,
                        principalTable: "StatusPagamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Registro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MtRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MtRegistrado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiposOcorrenciasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registro_TiposOcorrencias_TiposOcorrenciasId",
                        column: x => x.TiposOcorrenciasId,
                        principalTable: "TiposOcorrencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoRelacionamento",
                columns: new[] { "Id", "DsTipoRelacionamento" },
                values: new object[,]
                {
                    { 1, "Standard" },
                    { 2, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "TiposOcorrencias",
                columns: new[] { "Id", "dsTiposOcorrencias", "icTipoOcorrencia" },
                values: new object[,]
                {
                    { 1, "Furto", null },
                    { 2, "Agressão", null },
                    { 3, "Assédio", null },
                    { 4, "Roubo", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ClienteId",
                table: "Contato",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_ClienteId",
                table: "Imagens",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_LogMovimentacao_ClienteId",
                table: "LogMovimentacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_ClienteId",
                table: "Pagamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_StatusPagamentoId",
                table: "Pagamento",
                column: "StatusPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_TiposOcorrenciasId",
                table: "Registro",
                column: "TiposOcorrenciasId");

            migrationBuilder.CreateIndex(
                name: "IX_Relacionamento_ClienteId",
                table: "Relacionamento",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "LogMovimentacao");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Registro");

            migrationBuilder.DropTable(
                name: "Relacionamento");

            migrationBuilder.DropTable(
                name: "TipoRelacionamento");

            migrationBuilder.DropTable(
                name: "StatusPagamentos");

            migrationBuilder.DropTable(
                name: "TiposOcorrencias");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
