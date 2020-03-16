using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public enum StatusAta
    {
        [Display(Name = "Em Edição")]
        EmEdicao = 0,

        [Display(Name = "Finalizada")]
        Finalizada = 1,

        [Display(Name = "Aprovada")]
        Aprovada = 2,

        [Display(Name = "Fechada")]
        Fechada = 10
    }
}