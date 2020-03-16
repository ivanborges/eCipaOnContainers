using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesAtasPut
    {
        public string Local { get; set; }

        [Required]
        public DateTime? Inicio { get; set; }

        [Required]
        public DateTime? Termino { get; set; }

        [Required]
        public DateTime? Data { get; set; }

        [Required]
        public string HorarioInicio { get; set; }

        [Required]
        public string HorarioFim { get; set; }
    }
}