using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class CodigoDeCipaEmUsoException : CoreException
    {
        public override string Key => "CodigoDeCipaEmUso";
        public override string Message => "O código de cipa informado já está em uso no sistema.";

        public CodigoDeCipaEmUsoException() : base()
        {
        }

        protected CodigoDeCipaEmUsoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}