using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public enum FuncaoMembro
    {
        [Display(Name = "Titular Eleito")]
        TitularEleito = 0,

        [Display(Name = "Titular Indicado")]
        TitularIndicado = 1,

        [Display(Name = "Suplente Eleito")]
        SuplenteEleito = 2,

        [Display(Name = "Suplente Indicado")]
        SuplenteIndicado = 3,

        [Display(Name = "Designado")]
        Designado = 4,

        [Display(Name = "Secretário")]
        Secretário = 8,

        [Display(Name = "Vice-Presidente")]
        VicePresidente = 9,

        [Display(Name = "Presidente")]
        Presidente = 10
    }
}