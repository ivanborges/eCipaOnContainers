using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore
{
    internal class OrganizacoesContextFactory : IDesignTimeDbContextFactory<OrganizacoesContext>
    {
        public OrganizacoesContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OrganizacoesContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SESMTTech_Gestor_Organizacoes;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(OrganizacoesContext).GetTypeInfo().Assembly.GetName().Name));

            return new OrganizacoesContext(builder.Options);
        }
    }
}