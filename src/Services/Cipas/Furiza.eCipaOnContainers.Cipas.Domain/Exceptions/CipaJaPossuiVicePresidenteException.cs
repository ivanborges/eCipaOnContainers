using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class CipaJaPossuiVicePresidenteException : CoreException
    {
        public override string Key => "CipaJaPossuiVicePresidente";
        public override string Message => "A cipa já possui um vice-presidente e, portanto, não pode ter outro adicionado.";

        public CipaJaPossuiVicePresidenteException() : base()
        {
        }

        protected CipaJaPossuiVicePresidenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}