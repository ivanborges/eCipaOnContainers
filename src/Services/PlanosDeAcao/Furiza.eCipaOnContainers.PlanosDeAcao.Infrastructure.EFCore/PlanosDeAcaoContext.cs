﻿using Furiza.Base.Core.SeedWork;
using Microsoft.EntityFrameworkCore;
using Furiza.eCipaOnContainers.PlanosDeAcao.Infrastructure.EFCore.EntityConfigurations.PlanoDeAcaoAggregate;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Infrastructure.EFCore
{
    internal class PlanosDeAcaoContext : DbContext, IUnitOfWork
    {
        public PlanosDeAcaoContext(DbContextOptions<PlanosDeAcaoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new PlanoDeAcaoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ResponsavelEntityTypeConfiguration());
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