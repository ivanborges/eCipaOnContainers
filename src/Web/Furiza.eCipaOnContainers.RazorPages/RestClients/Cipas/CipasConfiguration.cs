using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas
{
    public class CipasConfiguration
    {
        [Required]
        public string ApiUrl { get; set; }
    }
}