﻿// <auto-generated />
using Agencia.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agencia.Migrations
{
    [DbContext(typeof(agenciaContext))]
    [Migration("20211216002400_agencia")]
    partial class agencia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Agencia.Models.cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cpf")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("Agencia.Models.contato", b =>
                {
                    b.Property<string>("area")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("area");

                    b.ToTable("contatos");
                });

            modelBuilder.Entity("Agencia.Models.destino", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dataOrigem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dataRetorno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("retorno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("destinos");
                });

            modelBuilder.Entity("Agencia.Models.promocao", b =>
                {
                    b.Property<int>("preco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dataOrigem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dataRetorno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("retorno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("preco");

                    b.ToTable("promocaos");
                });
#pragma warning restore 612, 618
        }
    }
}