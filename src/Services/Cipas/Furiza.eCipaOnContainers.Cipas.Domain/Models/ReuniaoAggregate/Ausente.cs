using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.Base.Core.SeedWork;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public class Ausente : Entity
    {
        public string NomeCompleto { get; set; }
        public string Email { get; private set; }
        public JustificativaAusencia Justificativa { get; private set; }
        public bool PossuiConsentValido { get; private set; }

        public IReadOnlyCollection<ConsentDeAusente> Consents => _consents;
        private readonly List<ConsentDeAusente> _consents;

        private Ausente()
        {
            _consents = new List<ConsentDeAusente>();
        }

        public Ausente(string nomeCompleto, string email, JustificativaAusencia justificativa) : this()
        {
            if (string.IsNullOrWhiteSpace(nomeCompleto))
                throw new NomeNaoPodeSerNuloException();

            if (string.IsNullOrWhiteSpace(email))
                throw new EmailNaoPodeSerNuloException();

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            NomeCompleto = nomeCompleto.Trim();
            Email = email.Trim();
            Justificativa = justificativa;
            PossuiConsentValido = false;
        }

        public void DarConsent(StatusAta statusAta, bool consent, string justificativa)
        {
            if (statusAta != StatusAta.Aprovada)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.Aprovada, statusAta);

            _consents.Add(new ConsentDeAusente(consent, justificativa));

            PossuiConsentValido = consent;
        }

        public void DefinirNovaJustificativa(StatusAta statusAta, JustificativaAusencia novaJustificativa)
        {
            if (statusAta != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, statusAta);

            Justificativa = novaJustificativa;
            PossuiConsentValido = false;
        }
    }
}