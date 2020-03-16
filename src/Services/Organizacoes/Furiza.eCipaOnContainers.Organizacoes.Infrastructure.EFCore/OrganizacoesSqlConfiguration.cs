using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore
{
    public class OrganizacoesSqlConfiguration
    {
        [Required]
        public string ConnectionString { get; set; }

        public bool EnableMigrations { get; set; } = false;
    }
}