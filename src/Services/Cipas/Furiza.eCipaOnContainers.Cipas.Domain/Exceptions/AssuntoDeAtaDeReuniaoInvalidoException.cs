using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AssuntoDeAtaDeReuniaoInvalidoException : CoreException
    {
        public override string Key => "AssuntoDeAtaDeReuniaoInvalido";
        public override string Message => "O assunto da ata de reunião especificado é inválido ou não existe.";

        public AssuntoDeAtaDeReuniaoInvalidoException() : base()
        {
        }

        protected AssuntoDeAtaDeReuniaoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}