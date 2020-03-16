using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.CipaAggregate
{
    internal class CipaEntityTypeConfiguration : IEntityTypeConfiguration<Cipa>
    {
        public void Configure(EntityTypeBuilder<Cipa> builder)
        {
            builder.ToTable("Cipas");

            builder.Ignore(b => b.Terceirizada);

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.Codigo).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Numero).IsRequired().HasDefaultValue(0);
            builder.Property(b => b.CodigoEmpresa).IsRequired().HasDefaultValue(0);
            builder.Property(b => b.Status).IsRequired();

            builder.OwnsOne(b => b.Mandato);

            builder.HasIndex(s => s.Codigo).IsUnique();

            var navigationMembros = builder.Metadata.FindNavigation(nameof(Cipa.Membros));
            navigationMembros.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigationEstabelecimentos = builder.Metadata.FindNavigation(nameof(Cipa.Estabelecimentos));
            navigationEstabelecimentos.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}