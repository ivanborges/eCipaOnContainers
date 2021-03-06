﻿// <auto-generated />
using System;
using Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(CipasContext))]
    [Migration("20190210151511_AddValueObjectVigencia")]
    partial class AddValueObjectVigencia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Cipas");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Membro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CipaId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CipaId");

                    b.ToTable("Membros");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.EstabelecimentoAggregate.CipaAnterior", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CipaId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<Guid>("EstabelecimentoId");

                    b.HasKey("Id");

                    b.HasIndex("CipaId");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("CipasAnteriores");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.EstabelecimentoAggregate.Estabelecimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CipaId");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CipaId");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Estabelecimentos");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa", b =>
                {
                    b.OwnsOne("Furiza.eCipaOnContainers.Cipa.Domain.ValueObjects.Vigencia", "Vigencia", b1 =>
                        {
                            b1.Property<Guid>("CipaId");

                            b1.Property<DateTime?>("Inicio");

                            b1.Property<DateTime?>("Termino");

                            b1.HasKey("CipaId");

                            b1.ToTable("Cipas");

                            b1.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa")
                                .WithOne("Vigencia")
                                .HasForeignKey("Furiza.eCipaOnContainers.Cipa.Domain.ValueObjects.Vigencia", "CipaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Membro", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa")
                        .WithMany("Membros")
                        .HasForeignKey("CipaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.EstabelecimentoAggregate.CipaAnterior", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa")
                        .WithMany()
                        .HasForeignKey("CipaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.EstabelecimentoAggregate.Estabelecimento")
                        .WithMany("CipasAnteriores")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.EstabelecimentoAggregate.Estabelecimento", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa")
                        .WithMany()
                        .HasForeignKey("CipaId");
                });
#pragma warning restore 612, 618
        }
    }
}
