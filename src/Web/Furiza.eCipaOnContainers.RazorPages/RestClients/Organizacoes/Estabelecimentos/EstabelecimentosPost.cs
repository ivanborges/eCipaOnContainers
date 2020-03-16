using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Organizacoes.Estabelecimentos
{
    public class EstabelecimentosPost
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}