using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReuniaoAggregate
{
    internal class AtaEntityTypeConfiguration : IEntityTypeConfiguration<Ata>
    {
        public void Configure(EntityTypeBuilder<Ata> builder)
        {
            builder.ToTable("Atas");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.Codigo).HasMaxLength(100).IsRequired();
            builder.Property(b => b.CodigoCipa).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Numero).IsRequired();
            builder.Property(b => b.Local).IsRequired(false);
            builder.Property(b => b.Inicio).IsRequired(false);
            builder.Property(b => b.Termino).IsRequired(false);
            builder.Property(b => b.Status).IsRequired();
            builder.Property<Guid>("ReuniaoId").IsRequired();

            builder.OwnsOne(b => b.Finalizacao);
            builder.OwnsOne(b => b.Aprovacao);
            builder.OwnsOne(b => b.Fechamento);

            builder.HasIndex(s => s.Codigo).IsUnique();
            builder.HasIndex(s => s.CodigoCipa);

            var navigationParticipantes = builder.Metadata.FindNavigation(nameof(Ata.Participantes));
            navigationParticipantes.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigationAusentes = builder.Metadata.FindNavigation(nameof(Ata.Ausentes));
            navigationAusentes.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigationAssuntos = builder.Metadata.FindNavigation(nameof(Ata.Assuntos));
            navigationAssuntos.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}