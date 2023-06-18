using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Pagamento.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagamentoCartao",
                columns: table => new
                {
                    numero_cartao = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_titular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    validade_cartao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    codigo_seguranca = table.Column<int>(type: "int", nullable: false),
                    cpf_titular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoCartao", x => x.numero_cartao);
                });

            migrationBuilder.CreateTable(
                name: "PagamentosPix",
                columns: table => new
                {
                    chave_pix = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    data_pagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    id_pagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_emissor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_receptor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentosPix", x => x.chave_pix);
                });

            migrationBuilder.InsertData(
                table: "PagamentoCartao",
                columns: new[] { "numero_cartao", "codigo_seguranca", "cpf_titular", "nome_titular", "validade_cartao", "valor" },
                values: new object[,]
                {
                    { 1L, 245, "12345678912", "HENRIQUE N SILVA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 230m },
                    { 2L, 254, "32165498732", "EMILLY R SILVA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 240m }
                });

            migrationBuilder.InsertData(
                table: "PagamentosPix",
                columns: new[] { "chave_pix", "data_pagamento", "id_pagamento", "nome_emissor", "nome_receptor", "valor" },
                values: new object[,]
                {
                    { "minha chave pix", new DateTime(2023, 6, 18, 12, 26, 54, 83, DateTimeKind.Local).AddTicks(7433), "1", "Henrique N Silva", "Emilly R Silva", 100m },
                    { "sua chave pix", new DateTime(2023, 6, 18, 12, 26, 54, 83, DateTimeKind.Local).AddTicks(7448), "2", "Emilly R Silva", "Henrique N Silva", 120m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoCartao");

            migrationBuilder.DropTable(
                name: "PagamentosPix");
        }
    }
}
