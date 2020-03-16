using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReuniaoAggregate
{
    internal class ConsentDeAusenteEntityTypeConfiguration : IEntityTypeConfiguration<ConsentDeAusente>
    {
        public void Configure(EntityTypeBuilder<ConsentDeAusente> builder)
        {
            builder.ToTable("ConsentsDeAusentes");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreationDate).IsRequired();
            builder.Property(b => b.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(b => b.Value).IsRequired();
            builder.Property(b => b.Justificativa).IsRequired(false);
            builder.Property<Guid>("AusenteId").IsRequired();
        }
    }
}