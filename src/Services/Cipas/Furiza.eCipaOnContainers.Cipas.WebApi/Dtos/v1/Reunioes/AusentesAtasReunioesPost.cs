using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class AusentesAtasReunioesPost
    {
        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public JustificativaAusencia? Justificativa { get; set; }
    }
}
