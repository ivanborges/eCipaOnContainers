using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public class ReunioesGetAtasParticipantesConsentsResult
    {
        public IEnumerable<ReunioesGetAtasParticipantesConsentsResultInnerConsent> Consents { get; set; }

        public class ReunioesGetAtasParticipantesConsentsResultInnerConsent
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public bool? Value { get; set; }
            public string Justificativa { get; set; }
        }
    }
}