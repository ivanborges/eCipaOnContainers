using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class UsuarioNaoPodeSerNuloException : CoreException
    {
        public override string Key => "UsuarioNaoPodeSerNulo";
        public override string Message => "O usuário não pode estar em branco.";

        public UsuarioNaoPodeSerNuloException() : base()
        {
        }

        protected UsuarioNaoPodeSerNuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
