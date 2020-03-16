using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.WebApi.Dtos.v1.PlanosDeAcao
{
    public class ResponsaveisItensPlanosDeAcaoPost
    {
        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}