using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesAtasAssuntosPut
    {
        [Required]
        public ClassificacaoDaInformacao? ClassificacaoDaInformacao { get; set; }

        [Required]
        public TipoAssunto? Tipo { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Keywords { get; set; }
    }
}