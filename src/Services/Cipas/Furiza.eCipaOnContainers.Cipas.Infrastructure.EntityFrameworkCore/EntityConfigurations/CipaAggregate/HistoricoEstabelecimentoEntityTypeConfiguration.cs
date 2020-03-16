using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.CipaAggregate
{
    internal class HistoricoEstabelecimentoEntityTypeConfiguration : IEntityTypeConfiguration<HistoricoEstabelecimento>
    {
        public void Configure(EntityTypeBuilder<HistoricoEstabelecimento> builder)
        {
            builder.ToTable("HistoricoEstabelecimentos");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.EstabelecimentoId).IsRequired();
            builder.Property(b => b.Tipo).IsRequired();
            builder.Property<Guid>("CipaId").IsRequired();

            builder.HasIndex(s => s.EstabelecimentoId);
        }
    }
}