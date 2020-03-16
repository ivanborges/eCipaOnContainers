using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReuniaoAggregate
{
    internal class AlteracaoEntityTypeConfiguration : IEntityTypeConfiguration<Alteracao>
    {
        public void Configure(EntityTypeBuilder<Alteracao> builder)
        {
            builder.ToTable("Alteracoes");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.Descricao).IsRequired();
            builder.Property(b => b.Versao).IsRequired();
            builder.Property<Guid>("AssuntoId").IsRequired();
        }
    }
}