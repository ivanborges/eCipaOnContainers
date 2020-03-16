using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class AusentesAtasReunioesPut
    {
        [Required]
        public JustificativaAusencia? Justificativa { get; set; }
    }
}
