﻿// <auto-generated />
using System;
using API_Pagamento.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Pagamento.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230618152654_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Pagamento.PagamentoCartao", b =>
                {
                    b.Property<long>("numero_cartao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("numero_cartao"));

                    b.Property<int>("codigo_seguranca")
                        .HasColumnType("int");

                    b.Property<string>("cpf_titular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome_titular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("validade_cartao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("numero_cartao");

                    b.ToTable("PagamentoCartao");

                    b.HasData(
                        new
                        {
                            numero_cartao = 1L,
                            codigo_seguranca = 245,
                            cpf_titular = "12345678912",
                            nome_titular = "HENRIQUE N SILVA",
                            validade_cartao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            valor = 230m
                        },
                        new
                        {
                            numero_cartao = 2L,
                            codigo_seguranca = 254,
                            cpf_titular = "32165498732",
                            nome_titular = "EMILLY R SILVA",
                            validade_cartao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            valor = 240m
                        });
                });

            modelBuilder.Entity("API_Pagamento.PagamentoPix", b =>
                {
                    b.Property<string>("chave_pix")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("data_pagamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("id_pagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome_emissor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome_receptor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("chave_pix");

                    b.ToTable("PagamentosPix");

                    b.HasData(
                        new
                        {
                            chave_pix = "minha chave pix",
                            data_pagamento = new DateTime(2023, 6, 18, 12, 26, 54, 83, DateTimeKind.Local).AddTicks(7433),
                            id_pagamento = "1",
                            nome_emissor = "Henrique N Silva",
                            nome_receptor = "Emilly R Silva",
                            valor = 100m
                        },
                        new
                        {
                            chave_pix = "sua chave pix",
                            data_pagamento = new DateTime(2023, 6, 18, 12, 26, 54, 83, DateTimeKind.Local).AddTicks(7448),
                            id_pagamento = "2",
                            nome_emissor = "Emilly R Silva",
                            nome_receptor = "Henrique N Silva",
                            valor = 120m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
