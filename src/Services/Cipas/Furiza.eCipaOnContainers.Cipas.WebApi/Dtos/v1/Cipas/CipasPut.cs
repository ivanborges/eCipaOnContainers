using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Cipas
{
    public class CipasPut
    {
        [Required]
        public DateTime? InicioDoMandato { get; set; }

        [Required]
        public DateTime? TerminoDoMandato { get; set; }
    }
}