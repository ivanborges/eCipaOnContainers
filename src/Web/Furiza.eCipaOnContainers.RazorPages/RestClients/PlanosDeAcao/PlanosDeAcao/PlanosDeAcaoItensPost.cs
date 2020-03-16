using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao
{
    public class PlanosDeAcaoItensPost
    {
        [Required]
        public DateTime? Prazo { get; set; }

        [Required]
        public string NomeCompletoResponsavel { get; set; }

        [Required]
        [EmailAddress]
        public string EmailResponsavel { get; set; }

        public string Descricao { get; set; }
        public string Acao { get; set; }
    }
}