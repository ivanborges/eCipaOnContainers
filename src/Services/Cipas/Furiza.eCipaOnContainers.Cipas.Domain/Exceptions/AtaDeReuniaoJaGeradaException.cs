using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AtaDeReuniaoJaGeradaException : CoreException
    {
        public override string Key => "AtaDeReuniaoJaGerada";
        public override string Message => "Já existe uma ata gerada para a reunião.";

        public AtaDeReuniaoJaGeradaException() : base()
        {
        }

        protected AtaDeReuniaoJaGeradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}