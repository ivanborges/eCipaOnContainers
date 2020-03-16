using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesGetAtasAusentesConsentsResult
    {
        public IEnumerable<ReunioesGetAtasAusentesConsentsResultInnerConsent> Consents { get; set; }

        public class ReunioesGetAtasAusentesConsentsResultInnerConsent
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public bool? Value { get; set; }
            public string Justificativa { get; set; }
        }
    }
}