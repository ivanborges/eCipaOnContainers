using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class ParticipanteDeAtaDeReuniaoInvalidoException : CoreException
    {
        public override string Key => "ParticipanteDeAtaDeReuniaoInvalido";
        public override string Message => "O participante da ata de reunião especificado é inválido ou não existe.";

        public ParticipanteDeAtaDeReuniaoInvalidoException() : base()
        {
        }

        protected ParticipanteDeAtaDeReuniaoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}