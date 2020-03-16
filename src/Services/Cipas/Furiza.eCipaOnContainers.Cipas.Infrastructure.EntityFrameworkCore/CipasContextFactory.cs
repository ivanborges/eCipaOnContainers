using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore
{
    internal class CipasContextFactory : IDesignTimeDbContextFactory<CipasContext>
    {
        public CipasContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CipasContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SESMTTech_Gestor_Cipas;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(CipasContext).GetTypeInfo().Assembly.GetName().Name));

            return new CipasContext(builder.Options);
        }
    }
}