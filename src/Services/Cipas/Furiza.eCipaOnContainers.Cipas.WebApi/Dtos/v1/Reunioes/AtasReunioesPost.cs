using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class AtasReunioesPost
    {
        public string Local { get; set; }

        [Required]
        public DateTime? Inicio { get; set; }

        [Required]
        public DateTime? Termino { get; set; }
    }
}