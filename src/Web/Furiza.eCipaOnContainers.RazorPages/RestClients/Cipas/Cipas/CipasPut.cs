using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasPut
    {
        [Required]
        public DateTime? InicioDoMandato { get; set; }

        [Required]
        public DateTime? TerminoDoMandato { get; set; }
    }
}