using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AusenteDaAtaDeReuniaoJaExistenteException : CoreException
    {
        public override string Key => "AusenteDaAtaDeReuniaoJaExistente";
        public override string Message => "O ausente informado já consta na ata de reunião.";

        public AusenteDaAtaDeReuniaoJaExistenteException() : base()
        {
        }

        protected AusenteDaAtaDeReuniaoJaExistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}