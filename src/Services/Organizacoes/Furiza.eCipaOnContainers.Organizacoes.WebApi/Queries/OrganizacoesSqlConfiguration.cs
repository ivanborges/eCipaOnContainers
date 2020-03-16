using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries
{
    public class OrganizacoesSqlConfiguration
    {
        [Required]
        public string ConnectionString { get; set; }

        [Required]
        public string DatabaseName { get; set; }

        [Required]
        public string CipasDatabaseName { get; set; }
    }
}