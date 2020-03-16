using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate;

namespace Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore.EntityConfigurations.EstabelecimentoAggregate
{
    internal class EstabelecimentoEntityTypeConfiguration : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.ToTable("Estabelecimentos");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.Codigo).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Nome).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Status).IsRequired();

            builder.HasIndex(s => s.Codigo).IsUnique();
        }
    }
}