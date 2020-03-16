using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Exceptions
{
    [Serializable]
    public class CipaJaPossuiEstabelecimentoPrincipalException : CoreException
    {
        public override string Key => "CipaJaPossuiEstabelecimentoPrincipal";
        public override string Message => "A cipa já possui um estabelecimento principal e, portanto, não pode ter outro adicionado.";

        public CipaJaPossuiEstabelecimentoPrincipalException() : base()
        {
        }

        protected CipaJaPossuiEstabelecimentoPrincipalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}