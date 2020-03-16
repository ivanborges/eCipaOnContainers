using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReuniaoAggregate
{
    internal class ParticipanteEntityTypeConfiguration : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
        {
            builder.ToTable("Participantes");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.NomeCompleto).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Email).HasMaxLength(100).IsRequired();
            builder.Property(b => b.PossuiConsentValido).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.EConvidado).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.Organizacao).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.Funcao).HasMaxLength(100).IsRequired(false);
            builder.Property<Guid>("AtaId").IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Participante.Consents));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}