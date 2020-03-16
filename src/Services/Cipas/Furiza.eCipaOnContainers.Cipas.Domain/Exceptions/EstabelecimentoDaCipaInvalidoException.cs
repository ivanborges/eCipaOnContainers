using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class EstabelecimentoDaCipaInvalidoException : CoreException
    {
        public override string Key => "EstabelecimentoDaCipaInvalido";
        public override string Message => "O estabelecimento da cipa especificado é inválido ou não existe.";

        public EstabelecimentoDaCipaInvalidoException() : base()
        {
        }

        protected EstabelecimentoDaCipaInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}