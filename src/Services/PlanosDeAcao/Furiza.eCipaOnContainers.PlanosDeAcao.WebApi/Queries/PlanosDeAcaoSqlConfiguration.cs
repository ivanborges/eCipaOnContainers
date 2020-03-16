using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.WebApi.Queries
{
    public class PlanosDeAcaoSqlConfiguration
    {
        [Required]
        public string ConnectionString { get; set; }

        [Required]
        public string DatabaseName { get; set; }
    }
}