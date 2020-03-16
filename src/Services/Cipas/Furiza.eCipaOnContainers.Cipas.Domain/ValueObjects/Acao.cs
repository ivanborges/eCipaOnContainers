using Furiza.Base.Core.SeedWork;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.Domain.ValueObjects
{
    public class Acao : ValueObject
    {
        public DateTime? Data { get; private set; }
        public string Ator { get; private set; }

        private Acao() { }

        public Acao(DateTime? data, string ator) : this()
        {
            Data = data;
            Ator = ator;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Data;
            yield return Ator;
        }

        public static Acao GetEmpty() => new Acao(null, null);
    }
}