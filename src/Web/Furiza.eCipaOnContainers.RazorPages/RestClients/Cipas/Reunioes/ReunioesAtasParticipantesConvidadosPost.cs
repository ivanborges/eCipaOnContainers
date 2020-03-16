using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesAtasParticipantesConvidadosPost
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