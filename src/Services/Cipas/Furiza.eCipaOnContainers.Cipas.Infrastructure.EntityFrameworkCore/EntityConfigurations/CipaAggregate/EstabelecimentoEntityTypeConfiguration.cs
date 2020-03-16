using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.CipaAggregate
{
    internal class EstabelecimentoEntityTypeConfiguration : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.ToTable("Estabelecimentos");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.EstabelecimentoId).IsRequired();
            builder.Property(b => b.Tipo).IsRequired();
            builder.Property<Guid>("CipaId").IsRequired();
        }
    }
}