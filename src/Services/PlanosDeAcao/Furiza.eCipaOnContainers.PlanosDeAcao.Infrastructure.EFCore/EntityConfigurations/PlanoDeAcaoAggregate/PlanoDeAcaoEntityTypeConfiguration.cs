using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furiza.eCipaOnContainers.PlanosDeAcao.Domain.Models.PlanoDeAcaoAggregate;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Infrastructure.EFCore.EntityConfigurations.PlanoDeAcaoAggregate
{
    internal class PlanoDeAcaoEntityTypeConfiguration : IEntityTypeConfiguration<PlanoDeAcao>
    {
        public void Configure(EntityTypeBuilder<PlanoDeAcao> builder)
        {
            builder.ToTable("PlanosDeAcao");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.Codigo).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Ano).IsRequired();
            builder.Property(b => b.Numero).IsRequired();

            builder.HasIndex(s => s.Codigo).IsUnique();
            builder.HasIndex(s => s.Ano);

            var navigation = builder.Metadata.FindNavigation(nameof(PlanoDeAcao.Itens));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}