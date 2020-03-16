using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesPlanosDeAcaoPost
    {
        [Required]
        public Guid? PlanoDeAcaoId { get; set; }
    }
}