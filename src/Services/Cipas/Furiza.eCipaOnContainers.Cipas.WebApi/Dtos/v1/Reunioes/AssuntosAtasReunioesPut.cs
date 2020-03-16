using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class AssuntosAtasReunioesPut
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