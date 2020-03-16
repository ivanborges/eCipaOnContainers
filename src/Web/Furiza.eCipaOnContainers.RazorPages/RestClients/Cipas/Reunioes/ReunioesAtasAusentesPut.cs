using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesAtasAusentesPut
    {
        [Required]
        public JustificativaAusencia? Justificativa { get; set; }
    }
}