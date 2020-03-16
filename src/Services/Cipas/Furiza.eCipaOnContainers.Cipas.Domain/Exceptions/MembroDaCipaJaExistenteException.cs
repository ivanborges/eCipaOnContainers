using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class MembroDaCipaJaExistenteException : CoreException
    {
        public override string Key => "MembroDaCipaJaExistente";
        public override string Message => "O usuário informado já é um membro da CIPA.";

        public MembroDaCipaJaExistenteException() : base()
        {
        }

        protected MembroDaCipaJaExistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}