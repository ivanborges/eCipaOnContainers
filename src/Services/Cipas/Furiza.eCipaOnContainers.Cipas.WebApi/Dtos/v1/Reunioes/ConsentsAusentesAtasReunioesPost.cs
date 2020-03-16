using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class ConsentsAusentesAtasReunioesPost
    {
        [Required]
        public bool Value { get; set; }

        public string Justificativa { get; set; }
    }
}