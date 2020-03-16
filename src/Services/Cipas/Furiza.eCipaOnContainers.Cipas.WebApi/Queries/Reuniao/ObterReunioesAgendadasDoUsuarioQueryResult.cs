using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterReunioesAgendadasDoUsuarioQueryResult
    {
        public IEnumerable<ObterReunioesAgendadasDoUsuarioQueryResultInnerReuniao> Reunioes { get; set; }

        public class ObterReunioesAgendadasDoUsuarioQueryResultInnerReuniao
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