using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class ParticipanteDaAtaDeReuniaoJaExistenteException : CoreException
    {
        public override string Key => "ParticipanteDaAtaDeReuniaoJaExistente";
        public override string Message => "O participante informado já consta na ata de reunião.";

        public ParticipanteDaAtaDeReuniaoJaExistenteException() : base()
        {
        }

        protected ParticipanteDaAtaDeReuniaoJaExistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}