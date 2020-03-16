using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao
{
    public class PlanosDeAcaoItensPut
    {
        [Required]
        public DateTime? Prazo { get; set; }

        public string Descricao { get; set; }
        public string Acao { get; set; }
    }
}