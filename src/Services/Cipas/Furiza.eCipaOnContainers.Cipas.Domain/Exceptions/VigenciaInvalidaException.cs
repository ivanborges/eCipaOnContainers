using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class VigenciaInvalidaException : CoreException
    {
        public override string Key => "VigenciaInvalida";
        public override string Message => "O período compreendido nas datas informadas para a vigência é inválido.";

        public VigenciaInvalidaException() : base()
        {
        }

        protected VigenciaInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}