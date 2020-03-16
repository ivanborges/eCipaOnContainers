using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AtaDeReuniaoSemConsentFavoravelDeTodosAusentesException : CoreException
    {
        public override string Key => "AtaDeReuniaoSemConsentFavoravelDeTodosAusentes";
        public override string Message => "A ata de reunião não possui o consent favorável de todos os ausentes.";

        public AtaDeReuniaoSemConsentFavoravelDeTodosAusentesException() : base()
        {
        }

        protected AtaDeReuniaoSemConsentFavoravelDeTodosAusentesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}