using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesPost
    {
        [Required]
        public Guid? CipaId { get; set; }

        [Required]
        public Mes? MesDeReferencia { get; set; }

        [Required]
        public DateTime? DataPrevista { get; set; }

        [Required]
        public string HorarioPrevisto { get; set; }

        [Required]
        public string Local { get; set; }

        public bool Extraordinaria { get; set; }
    }
}