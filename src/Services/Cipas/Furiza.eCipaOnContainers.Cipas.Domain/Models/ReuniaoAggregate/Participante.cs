using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.Base.Core.SeedWork;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public class Participante : Entity
    {
        public string NomeCompleto { get; set; }
        public string Email { get; private set; }
        public bool PossuiConsentValido { get; private set; }
        public bool EConvidado { get; private set; }
        public string Organizacao { get; set; }
        public string Funcao { get; set; }

        public IReadOnlyCollection<ConsentDeParticipante> Consents => _consents;
        private readonly List<ConsentDeParticipante> _consents;

        protected Participante()
        {
            _consents = new List<ConsentDeParticipante>();
        }

        public Participante(string nomeCompleto, string email) : this()
        {
            if (string.IsNullOrWhiteSpace(nomeCompleto))
                throw new NomeNaoPodeSerNuloException();

            if (string.IsNullOrWhiteSpace(email))
                throw new EmailNaoPodeSerNuloException();

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            NomeCompleto = nomeCompleto.Trim();
            Email = email.Trim();
            PossuiConsentValido = false;
            EConvidado = false;
        }

        public Participante(string nomeCompleto, string email, string organizacao, string funcao) : this(nomeCompleto, email)
        {
            EConvidado = true;
            Organizacao = organizacao?.Trim();
            Funcao = funcao?.Trim();
        }

        public void DarConsent(StatusAta statusAta, bool consent, string justificativa)
        {
            //TODO: removido por enquanto pois com a alteração que virá, esse método deixará até mesmo de existir!
            //if (statusAta != StatusAta.Aprovada)
            //    throw new StatusAtaDeReuniaoInvalidoException(StatusAta.Aprovada, statusAta);

            _consents.Add(new ConsentDeParticipante(consent, justificativa));

            PossuiConsentValido = consent;
        }
    }
}