using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Infrastructure.EFCore
{
    public class PlanosDeAcaoSqlConfiguration
    {
        [Required]
        public string ConnectionString { get; set; }

        public bool EnableMigrations { get; set; } = false;
    }
}