using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Infrastructure.EFCore
{
    internal class PlanosDeAcaoContextFactory : IDesignTimeDbContextFactory<PlanosDeAcaoContext>
    {
        public PlanosDeAcaoContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PlanosDeAcaoContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SESMTTech_Gestor_PlanosDeAcao;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(PlanosDeAcaoContext).GetTypeInfo().Assembly.GetName().Name));

            return new PlanosDeAcaoContext(builder.Options);
        }
    }
}