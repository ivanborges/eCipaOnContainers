using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Domain.Exceptions
{
    [Serializable]
    public class ResponsavelDoItemDoPlanoDeAcaoJaExistenteException : CoreException
    {
        public override string Key => "ResponsavelDoItemDoPlanoDeAcaoJaExistente";
        public override string Message => "O responsável informado já consta no item do plano de ação.";

        public ResponsavelDoItemDoPlanoDeAcaoJaExistenteException() : base()
        {
        }

        protected ResponsavelDoItemDoPlanoDeAcaoJaExistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}