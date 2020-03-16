using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.CipaAggregate
{
    internal class MembroEntityTypeConfiguration : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.ToTable("Membros");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.UserName).HasMaxLength(100).IsRequired();
            builder.Property(b => b.NomeCompleto).HasMaxLength(200).IsRequired(false);
            builder.Property(b => b.Funcao).IsRequired().HasDefaultValue(FuncaoMembro.TitularEleito);
            builder.Property<Guid>("CipaId").IsRequired();
        }
    }
}