using Furiza.Base.Core.SeedWork;
using Microsoft.EntityFrameworkCore;
using Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.CipaAggregate;
using Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReuniaoAggregate;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore
{
    internal class CipasContext : DbContext, IUnitOfWork
    {
        public CipasContext(DbContextOptions<CipasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CipaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MembroEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EstabelecimentoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricoEstabelecimentoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReuniaoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AtaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipanteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConsentDeParticipanteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AusenteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConsentDeAusenteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AssuntoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlteracaoEntityTypeConfiguration());
        }

        public int SaveEntities()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveEntitiesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}