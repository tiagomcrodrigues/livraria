﻿// <auto-generated />
using System;
using Livraria.Service.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Livraria.Service.Migrations
{
    [DbContext(typeof(DbLivraria))]
    partial class DbLivrariaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Livraria.Data.Entities.Autores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("UK_Autores_Nome");

                    b.ToTable("Autores", (string)null);
                });

            modelBuilder.Entity("Livraria.Data.Entities.Emprestimos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataDevolucao");

                    b.Property<DateTime>("DataEprestimo")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataEprestimo");

                    b.Property<DateTime>("DataVencimeto")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataVencimeto");

                    b.Property<int>("LivroId")
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("LivroId");

                    b.Property<int>("PessoaId")
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("PessoaId");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Emprestimos", (string)null);
                });

            modelBuilder.Entity("Livraria.Data.Entities.Livros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int")
                        .HasColumnName("AutorId");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Descricao");

                    b.Property<ulong>("PermitirEmprestimo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(0ul)
                        .HasColumnName("PermitirEmprestimo");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("Titulo")
                        .IsUnique()
                        .HasDatabaseName("UK_Livros_Titulo");

                    b.ToTable("Livros", (string)null);
                });

            modelBuilder.Entity("Livraria.Data.Entities.Pessoas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("Cep");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Complemento");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Numero");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasDatabaseName("Uk_Pessoas_Cpf");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("Uk_Pessoas_Nome");

                    b.ToTable("Pessoas", (string)null);
                });

            modelBuilder.Entity("Livraria.Data.Entities.Emprestimos", b =>
                {
                    b.HasOne("Livraria.Data.Entities.Livros", "Livros")
                        .WithMany("Emprestimos")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Livraria.Data.Entities.Pessoas", "Pessoas")
                        .WithMany("Emprestimos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Livros");

                    b.Navigation("Pessoas");
                });

            modelBuilder.Entity("Livraria.Data.Entities.Livros", b =>
                {
                    b.HasOne("Livraria.Data.Entities.Autores", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("Livraria.Data.Entities.Autores", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("Livraria.Data.Entities.Livros", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("Livraria.Data.Entities.Pessoas", b =>
                {
                    b.Navigation("Emprestimos");
                });
#pragma warning restore 612, 618
        }
    }
}
