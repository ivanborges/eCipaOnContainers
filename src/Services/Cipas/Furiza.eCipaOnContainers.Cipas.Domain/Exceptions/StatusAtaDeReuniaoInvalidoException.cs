using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class StatusAtaDeReuniaoInvalidoException : CoreException
    {
        public override string Key => "StatusAtaDeReuniaoInvalido";
        public override string Message => "A ata de reunião não está com status apropriado para a operação em questão.";

        public StatusAta Esperado { get; private set; }
        public StatusAta Encontrado { get; private set; }

        public StatusAtaDeReuniaoInvalidoException(StatusAta statusEsperado, StatusAta statusEncontrado) : base()
        {
            Esperado = statusEsperado;
            Encontrado = statusEncontrado;
        }

        protected StatusAtaDeReuniaoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}