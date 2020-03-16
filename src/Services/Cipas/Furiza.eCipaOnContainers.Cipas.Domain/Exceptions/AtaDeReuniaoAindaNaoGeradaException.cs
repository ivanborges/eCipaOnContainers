using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AtaDeReuniaoAindaNaoGeradaException : CoreException
    {
        public override string Key => "AtaDeReuniaoAindaNaoGerada";
        public override string Message => "A reunião ainda não possui uma ata gerada.";

        public AtaDeReuniaoAindaNaoGeradaException() : base()
        {
        }

        protected AtaDeReuniaoAindaNaoGeradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}