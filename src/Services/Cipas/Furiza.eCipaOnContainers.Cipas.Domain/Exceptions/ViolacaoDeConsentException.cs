using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class ViolacaoDeConsentException : CoreException
    {
        public override string Key => "ViolacaoDeConsent";
        public override string Message => "O consent é incompatível com as credenciais autenticadas.";

        public ViolacaoDeConsentException() : base()
        {
        }

        protected ViolacaoDeConsentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}