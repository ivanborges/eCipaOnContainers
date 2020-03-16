using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AtaDeReuniaoSemConsentFavoravelDeTodosParticipantesException : CoreException
    {
        public override string Key => "AtaDeReuniaoSemConsentFavoravelDeTodosParticipantes";
        public override string Message => "A ata de reunião não possui o consent favorável de todos os participantes.";

        public AtaDeReuniaoSemConsentFavoravelDeTodosParticipantesException() : base()
        {
        }

        protected AtaDeReuniaoSemConsentFavoravelDeTodosParticipantesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}