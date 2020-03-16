using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AusenteDeAtaDeReuniaoInvalidoException : CoreException
    {
        public override string Key => "AusenteDeAtaDeReuniaoInvalido";
        public override string Message => "O ausente da ata de reunião especificado é inválido ou não existe.";

        public AusenteDeAtaDeReuniaoInvalidoException() : base()
        {
        }

        protected AusenteDeAtaDeReuniaoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}