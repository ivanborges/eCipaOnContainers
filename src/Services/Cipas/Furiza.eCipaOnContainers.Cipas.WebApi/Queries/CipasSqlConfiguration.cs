using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries
{
    public class CipasSqlConfiguration
    {
        [Required]
        public string ConnectionString { get; set; }

        [Required]
        public string DatabaseName { get; set; }

        [Required]
        public string OrganizacoesDatabaseName { get; set; }
    }
}