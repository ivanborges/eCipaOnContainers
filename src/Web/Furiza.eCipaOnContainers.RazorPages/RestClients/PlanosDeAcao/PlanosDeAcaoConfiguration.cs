using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao
{
    public class PlanosDeAcaoConfiguration
    {
        [Required]
        public string ApiUrl { get; set; }
    }
}