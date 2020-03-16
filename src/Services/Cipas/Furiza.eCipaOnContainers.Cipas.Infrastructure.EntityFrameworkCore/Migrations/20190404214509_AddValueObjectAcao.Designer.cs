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
    [Migration("20190404214509_AddValueObjectAcao")]
    partial class AddValueObjectAcao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ano")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Descricao");

                    b.Property<int?>("Fornecedor");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Ano");

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

                    b.Property<int>("Funcao")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

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

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.PlanoDeAcaoAggregate.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Acao");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DataRealizacao");

                    b.Property<string>("Descricao");

                    b.Property<Guid>("PlanoDeAcaoId");

                    b.Property<DateTime>("Prazo");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("PlanoDeAcaoId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.PlanoDeAcaoAggregate.PlanoDeAcao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ano");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<int>("Numero");

                    b.HasKey("Id");

                    b.HasIndex("Ano");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("PlanosDeAcao");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.PlanoDeAcaoAggregate.Responsavel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<Guid>("ItemId");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Alteracao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AssuntoId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("AssuntoId");

                    b.ToTable("Alteracoes");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Assunto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AtaId");

                    b.Property<int>("ClassificacaoDaInformacao");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Keywords")
                        .HasMaxLength(200);

                    b.Property<int>("Numero");

                    b.Property<int>("Tipo");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("AtaId");

                    b.ToTable("Assuntos");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CodigoCipa")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Inicio");

                    b.Property<string>("Local");

                    b.Property<int>("Numero");

                    b.Property<Guid>("ReuniaoId");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("Termino");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("CodigoCipa");

                    b.HasIndex("ReuniaoId")
                        .IsUnique();

                    b.ToTable("Atas");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ausente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AtaId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Justificativa");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("PossuiConsentValido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("AtaId");

                    b.ToTable("Ausentes");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.ConsentDeAusente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AusenteId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Justificativa");

                    b.Property<bool>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AusenteId");

                    b.ToTable("ConsentsDeAusentes");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.ConsentDeParticipante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<string>("Justificativa");

                    b.Property<Guid>("ParticipanteId");

                    b.Property<bool>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ParticipanteId");

                    b.ToTable("ConsentsDeParticipantes");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Participante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AtaId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<bool>("EConvidado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Funcao")
                        .HasMaxLength(100);

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Organizacao")
                        .HasMaxLength(100);

                    b.Property<bool>("PossuiConsentValido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("AtaId");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Reuniao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CipaId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DataPrevista");

                    b.Property<bool>("Extraordinaria");

                    b.Property<string>("Local")
                        .HasMaxLength(200);

                    b.Property<int>("MesDeReferencia")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<Guid?>("PlanoDeAcaoId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CipaId");

                    b.HasIndex("PlanoDeAcaoId")
                        .IsUnique()
                        .HasFilter("[PlanoDeAcaoId] IS NOT NULL");

                    b.ToTable("Reunioes");
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa", b =>
                {
                    b.OwnsOne("Furiza.eCipaOnContainers.Cipa.Domain.ValueObjects.Vigencia", "Mandato", b1 =>
                        {
                            b1.Property<Guid>("CipaId");

                            b1.Property<DateTime?>("Inicio");

                            b1.Property<DateTime?>("Termino");

                            b1.HasKey("CipaId");

                            b1.ToTable("Cipas");

                            b1.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa")
                                .WithOne("Mandato")
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

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.PlanoDeAcaoAggregate.Item", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.PlanoDeAcaoAggregate.PlanoDeAcao")
                        .WithMany("Itens")
                        .HasForeignKey("PlanoDeAcaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.PlanoDeAcaoAggregate.Responsavel", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.PlanoDeAcaoAggregate.Item")
                        .WithMany("Responsaveis")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Alteracao", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Assunto")
                        .WithMany("Alteracoes")
                        .HasForeignKey("AssuntoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Assunto", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ata")
                        .WithMany("Assuntos")
                        .HasForeignKey("AtaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ata", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Reuniao")
                        .WithOne("Ata")
                        .HasForeignKey("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ata", "ReuniaoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Furiza.eCipaOnContainers.Cipa.Domain.ValueObjects.Acao", "Aprovacao", b1 =>
                        {
                            b1.Property<Guid>("AtaId");

                            b1.Property<string>("Ator");

                            b1.Property<DateTime?>("Data");

                            b1.HasKey("AtaId");

                            b1.ToTable("Atas");

                            b1.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ata")
                                .WithOne("Aprovacao")
                                .HasForeignKey("Furiza.eCipaOnContainers.Cipa.Domain.ValueObjects.Acao", "AtaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Furiza.eCipaOnContainers.Cipa.Domain.ValueObjects.Acao", "Finalizacao", b1 =>
                        {
                            b1.Property<Guid>("AtaId");

                            b1.Property<string>("Ator");

                            b1.Property<DateTime?>("Data");

                            b1.HasKey("AtaId");

                            b1.ToTable("Atas");

                            b1.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ata")
                                .WithOne("Finalizacao")
                                .HasForeignKey("Furiza.eCipaOnContainers.Cipa.Domain.ValueObjects.Acao", "AtaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ausente", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ata")
                        .WithMany("Ausentes")
                        .HasForeignKey("AtaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.ConsentDeAusente", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ausente")
                        .WithMany("Consents")
                        .HasForeignKey("AusenteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.ConsentDeParticipante", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Participante")
                        .WithMany("Consents")
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Participante", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Ata")
                        .WithMany("Participantes")
                        .HasForeignKey("AtaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Reuniao", b =>
                {
                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.CipaAggregate.Cipa")
                        .WithMany()
                        .HasForeignKey("CipaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Furiza.eCipaOnContainers.Cipa.Domain.Models.PlanoDeAcaoAggregate.PlanoDeAcao")
                        .WithOne()
                        .HasForeignKey("Furiza.eCipaOnContainers.Cipa.Domain.Models.ReuniaoAggregate.Reuniao", "PlanoDeAcaoId");
                });
#pragma warning restore 612, 618
        }
    }
}
