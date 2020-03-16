using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.WebApi.Dtos.v1.PlanosDeAcao
{
    public class ItensPlanosDeAcaoPut
    {
        [Required]
        public DateTime? Prazo { get; set; }

        public string Descricao { get; set; }
        public string Acao { get; set; }
    }
}