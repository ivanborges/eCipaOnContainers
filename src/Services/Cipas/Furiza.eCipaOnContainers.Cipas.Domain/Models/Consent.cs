using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.Base.Core.SeedWork;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models
{
    public abstract class Consent : Entity
    {
        public bool Value { get; private set; }

        public string Justificativa { get; private set; }

        protected Consent() { }

        public Consent(bool value, string justificativa) : this()
        {
            if (!value && string.IsNullOrWhiteSpace(justificativa))
                throw new ConsentDesfavoravelSemJustificativaException();

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            Value = value;
            Justificativa = justificativa;
        }
    }
}