using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Organizacoes.Domain.Exceptions
{
    [Serializable]
    public class CodigoDeEstabelecimentoEmUsoException : CoreException
    {
        public override string Key => "CodigoDeEstabelecimentoEmUso";
        public override string Message => "O código de estabelecimento informado já está em uso no sistema.";

        public CodigoDeEstabelecimentoEmUsoException() : base()
        {
        }

        protected CodigoDeEstabelecimentoEmUsoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}