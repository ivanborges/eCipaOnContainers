using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasPost
    {
        [Required]
        public int? CodigoEmpresa { get; set; }

        [Required]
        public DateTime? InicioDoMandato { get; set; }

        [Required]
        public DateTime? TerminoDoMandato { get; set; }
    }
}