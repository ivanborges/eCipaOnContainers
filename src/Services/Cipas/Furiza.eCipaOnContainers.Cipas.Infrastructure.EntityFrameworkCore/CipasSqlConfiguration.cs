using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore
{
    public class CipasSqlConfiguration
    {
        [Required]
        public string ConnectionString { get; set; }

        public bool EnableMigrations { get; set; } = false;
    }
}