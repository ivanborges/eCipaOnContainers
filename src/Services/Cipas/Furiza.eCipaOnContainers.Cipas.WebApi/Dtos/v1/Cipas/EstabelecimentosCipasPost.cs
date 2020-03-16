using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Cipas
{
    public class EstabelecimentosCipasPost
    {
        [Required]
        public Guid? EstabelecimentoId { get; set; }

        [Required]
        public TipoEstabelecimento? Tipo { get; set; }
    }
}