﻿using Furiza.Base.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Domain.Exceptions
{
    [Serializable]
    public class DataNaoPodeSerNoPassadoException : CoreException
    {
        public override string Key => "DataNaoPodeSerNoPassado";
        public override string Message => "A data informada não pode ser no passado.";

        public DataNaoPodeSerNoPassadoException() : base()
        {
        }

        protected DataNaoPodeSerNoPassadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}