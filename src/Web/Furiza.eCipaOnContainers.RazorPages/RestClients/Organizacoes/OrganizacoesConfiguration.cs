using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes
{
    public class OrganizacoesConfiguration
    {
        [Required]
        public string ApiUrl { get; set; }
    }
}