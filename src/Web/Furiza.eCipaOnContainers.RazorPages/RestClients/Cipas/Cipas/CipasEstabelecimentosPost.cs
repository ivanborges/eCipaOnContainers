using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasEstabelecimentosPost
    {
        [Required]
        public Guid? EstabelecimentoId { get; set; }

        [Required]
        public TipoEstabelecimento? Tipo { get; set; }
    }
}