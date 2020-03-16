using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class ConsentDesfavoravelSemJustificativaException : CoreException
    {
        public override string Key => "ConsentDesfavoravelSemJustificativa";
        public override string Message => "Um consent desfavorável deve obrigatoriamente possuir uma justificativa para tal.";

        public ConsentDesfavoravelSemJustificativaException() : base()
        {
        }

        protected ConsentDesfavoravelSemJustificativaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}