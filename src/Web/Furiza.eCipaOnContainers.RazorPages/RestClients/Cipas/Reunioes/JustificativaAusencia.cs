using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public enum JustificativaAusencia
    {
        [Display(Name = "Licença Médica")]
        LicencaMedica = 0,

        [Display(Name = "Férias")]
        Ferias = 1,

        [Display(Name = "Treinamento")]
        Treinamento = 2,

        [Display(Name = "Não Informado")]
        NaoInformado = 99
    }
}