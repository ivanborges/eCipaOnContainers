using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReuniaoAggregate
{
    internal class AssuntoEntityTypeConfiguration : IEntityTypeConfiguration<Assunto>
    {
        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder.ToTable("Assuntos");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.ClassificacaoDaInformacao).IsRequired();
            builder.Property(b => b.Tipo).IsRequired();
            builder.Property(b => b.Numero).IsRequired();
            builder.Property(b => b.Descricao).IsRequired();
            builder.Property(b => b.Keywords).HasMaxLength(200).IsRequired(false);
            builder.Property(b => b.Versao).IsRequired();
            builder.Property<Guid>("AtaId").IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Assunto.Alteracoes));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}