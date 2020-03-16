using Furiza.Base.Core.SeedWork;
using Microsoft.EntityFrameworkCore;
using Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore.EntityConfigurations.EstabelecimentoAggregate;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore
{
    internal class OrganizacoesContext : DbContext, IUnitOfWork
    {
        public OrganizacoesContext(DbContextOptions<OrganizacoesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstabelecimentoEntityTypeConfiguration());
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