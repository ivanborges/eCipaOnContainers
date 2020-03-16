using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.PlanosDeAcao.PlanosDeAcao
{
    public class PlanosDeAcaoItensConcluirPost
    {
        [Required]
        public DateTime? DataRealizacao { get; set; }
    }
}