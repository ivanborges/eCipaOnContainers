using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Cipas
{
    public class CipasReunioesGetResult
    {
        public IEnumerable<CipasReunioesGetResultInnerReuniao> Reunioes { get; set; }

        public class CipasReunioesGetResultInnerReuniao
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string CreationUser { get; set; }
            public Guid? CipaId { get; set; }
            public Mes? MesDeReferencia { get; set; }
            public DateTime? DataPrevista { get; set; }
            public string Local { get; set; }
            public StatusAgendamento? Status { get; set; }
            public bool? Extraordinaria { get; set; }
            public Guid? PlanoDeAcaoId { get; set; }
        }
    }
}