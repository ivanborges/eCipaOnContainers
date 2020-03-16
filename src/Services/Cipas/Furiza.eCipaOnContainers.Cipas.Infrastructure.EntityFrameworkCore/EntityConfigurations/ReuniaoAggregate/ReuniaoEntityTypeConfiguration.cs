using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReuniaoAggregate
{
    internal class ReuniaoEntityTypeConfiguration : IEntityTypeConfiguration<Reuniao>
    {
        public void Configure(EntityTypeBuilder<Reuniao> builder)
        {
            builder.ToTable("Reunioes");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.CipaId).IsRequired();
            builder.Property(b => b.MesDeReferencia).IsRequired().HasDefaultValue(Mes.Janeiro);
            builder.Property(b => b.DataPrevista).IsRequired();
            builder.Property(b => b.Local).HasMaxLength(200).IsRequired(false);
            builder.Property(b => b.Status).IsRequired();
            builder.Property(b => b.Extraordinaria).IsRequired();
            builder.Property(b => b.PlanoDeAcaoId).IsRequired(false);

            var navigation = builder.Metadata.FindNavigation(nameof(Reuniao.Ata));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne<Cipa>()
               .WithMany()
               .HasForeignKey(e => e.CipaId)
               .IsRequired();
        }
    }
}