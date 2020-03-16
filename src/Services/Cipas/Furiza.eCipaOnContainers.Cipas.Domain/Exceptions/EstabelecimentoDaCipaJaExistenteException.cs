using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class EstabelecimentoDaCipaJaExistenteException : CoreException
    {
        public override string Key => "EstabelecimentoDaCipaJaExistente";
        public override string Message => "O estabelecimento informado já está configurado na CIPA.";

        public EstabelecimentoDaCipaJaExistenteException() : base()
        {
        }

        protected EstabelecimentoDaCipaJaExistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}