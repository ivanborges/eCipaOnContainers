using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class AtaDeReuniaoSemAssuntoException : CoreException
    {
        public override string Key => "AtaDeReuniaoSemAssunto";
        public override string Message => "A ata de reunião não possui nenhum assunto adicionado.";

        public AtaDeReuniaoSemAssuntoException() : base()
        {
        }

        protected AtaDeReuniaoSemAssuntoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}