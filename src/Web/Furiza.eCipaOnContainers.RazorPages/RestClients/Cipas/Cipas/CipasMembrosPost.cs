using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasMembrosPost
    {
        [Required]
        public string UserName { get; set; }

        public string NomeCompleto { get; set; }

        [Required]
        public FuncaoMembro? Funcao { get; set; }
    }
}