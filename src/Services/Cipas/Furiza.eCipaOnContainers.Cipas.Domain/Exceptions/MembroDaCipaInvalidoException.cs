using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class MembroDaCipaInvalidoException : CoreException
    {
        public override string Key => "MembroDaCipaInvalido";
        public override string Message => "O membro da cipa especificado é inválido ou não existe.";

        public MembroDaCipaInvalidoException() : base()
        {
        }

        protected MembroDaCipaInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}