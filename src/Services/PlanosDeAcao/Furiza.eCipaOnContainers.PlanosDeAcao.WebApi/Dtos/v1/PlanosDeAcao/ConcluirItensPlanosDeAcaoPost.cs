using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.WebApi.Dtos.v1.PlanosDeAcao
{
    public class ConcluirItensPlanosDeAcaoPost
    {
        [Required]
        public DateTime? DataRealizacao { get; set; }
    }
}