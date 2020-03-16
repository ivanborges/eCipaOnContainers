using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa
{
    public class ObterReunioesDaCipaQueryResult
    {
        public IEnumerable<ObterReunioesDaCipaQueryResultInnerReuniao> Reunioes { get; set; }

        public class ObterReunioesDaCipaQueryResultInnerReuniao
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