using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class DescricaoNaoPodeSerNulaException : CoreException
    {
        public override string Key => "DescricaoNaoPodeSerNula";
        public override string Message => "A descrição do objeto não pode estar em branco.";

        public DescricaoNaoPodeSerNulaException() : base()
        {
        }

        protected DescricaoNaoPodeSerNulaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}