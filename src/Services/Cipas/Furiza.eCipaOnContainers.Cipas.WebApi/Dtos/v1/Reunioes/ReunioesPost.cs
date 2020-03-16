using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class ReunioesPost
    {
        [Required]
        public Guid? CipaId { get; set; }

        [Required]
        public Mes? MesDeReferencia { get; set; }

        [Required]
        public DateTime? DataPrevista { get; set; }

        public string Local { get; set; }

        [Required]
        public bool? Extraordinaria { get; set; }
    }
}