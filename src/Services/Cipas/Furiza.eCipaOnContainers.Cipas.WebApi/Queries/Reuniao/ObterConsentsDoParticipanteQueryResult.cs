using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterConsentsDoParticipanteQueryResult
    {
        public IEnumerable<ObterConsentsDoParticipanteQueryResultInnerConsent> Consents { get; set; }

        public class ObterConsentsDoParticipanteQueryResultInnerConsent
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public bool? Value { get; set; }
            public string Justificativa { get; set; }
        }
    }
}