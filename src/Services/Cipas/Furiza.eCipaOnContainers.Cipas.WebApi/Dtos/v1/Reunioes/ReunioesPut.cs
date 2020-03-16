using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class ReunioesPut
    {
        [Required]
        public Mes? MesDeReferencia { get; set; }

        [Required]
        public DateTime? DataPrevista { get; set; }

        public string Local { get; set; }
    }
}