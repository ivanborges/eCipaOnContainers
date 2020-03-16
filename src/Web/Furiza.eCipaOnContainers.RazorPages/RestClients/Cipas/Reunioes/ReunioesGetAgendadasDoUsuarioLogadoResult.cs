using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesGetAgendadasDoUsuarioLogadoResult
    {
        public IEnumerable<ReunioesGetAgendadasDoUsuarioLogadoResultInnerReuniao> Reunioes { get; set; }

        public class ReunioesGetAgendadasDoUsuarioLogadoResultInnerReuniao
        {
            public Guid? Id { get; set; }
            public Guid? CipaId { get; set; }
            public Mes? MesDeReferencia { get; set; }
            public DateTime? DataPrevista { get; set; }
            public string Local { get; set; }
            public StatusAgendamento? Status { get; set; }
            public bool? Extraordinaria { get; set; }
        }
    }
}