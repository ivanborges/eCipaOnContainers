using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class CipaJaPossuiPresidenteException : CoreException
    {
        public override string Key => "CipaJaPossuiPresidente";
        public override string Message => "A cipa já possui um presidente e, portanto, não pode ter outro adicionado.";

        public CipaJaPossuiPresidenteException() : base()
        {
        }

        protected CipaJaPossuiPresidenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}