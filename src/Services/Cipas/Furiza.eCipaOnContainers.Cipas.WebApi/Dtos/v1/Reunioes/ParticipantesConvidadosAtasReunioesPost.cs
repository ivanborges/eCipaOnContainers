using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class ParticipantesConvidadosAtasReunioesPost
    {
        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Organizacao { get; set; }
        public string Funcao { get; set; }
    }
}