using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes
{
    public class PlanosDeAcaoReunioesPost
    {
        [Required]
        public Guid? PlanoDeAcaoId { get; set; }
    }
}