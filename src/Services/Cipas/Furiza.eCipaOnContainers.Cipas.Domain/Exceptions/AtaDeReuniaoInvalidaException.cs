using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AtaDeReuniaoInvalidaException : CoreException
    {
        public override string Key => "AtaDeReuniaoInvalida";
        public override string Message => "A ata de reunião especificada é inválida ou não existe.";

        public AtaDeReuniaoInvalidaException() : base()
        {
        }

        protected AtaDeReuniaoInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}