using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterConsentsDoAusenteQueryResult
    {
        public IEnumerable<ObterConsentsDoAusenteQueryResultInnerConsent> Consents { get; set; }

        public class ObterConsentsDoAusenteQueryResultInnerConsent
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public bool? Value { get; set; }
            public string Justificativa { get; set; }
        }
    }
}