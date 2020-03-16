using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Cipas
{
    public class MembrosCipasPost
    {
        [Required]
        public string UserName { get; set; }

        public string NomeCompleto { get; set; }

        [Required]
        public FuncaoMembro? Funcao { get; set; }
    }
}