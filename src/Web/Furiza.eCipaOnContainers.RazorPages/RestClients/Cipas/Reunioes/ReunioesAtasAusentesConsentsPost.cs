using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesAtasAusentesConsentsPost
    {
        [Required]
        public bool? Value { get; set; }

        public string Justificativa { get; set; }
    }
}