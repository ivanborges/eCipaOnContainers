using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AtaDeReuniaoSemParticipanteException : CoreException
    {
        public override string Key => "AtaDeReuniaoSemParticipante";
        public override string Message => "A ata de reunião não possui nenhum participante adicionado.";

        public AtaDeReuniaoSemParticipanteException() : base()
        {
        }

        protected AtaDeReuniaoSemParticipanteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}