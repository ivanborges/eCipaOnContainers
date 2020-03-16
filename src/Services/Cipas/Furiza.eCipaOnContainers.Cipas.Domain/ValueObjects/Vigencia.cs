using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.Base.Core.SeedWork;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.Domain.ValueObjects
{
    public class Vigencia : ValueObject
    {
        public DateTime? Inicio { get; private set; }
        public DateTime? Termino { get; private set; }

        private Vigencia() { }

        public Vigencia(DateTime inicio, DateTime termino) : this()
        {
            if (termino.Date < inicio.Date || termino.Date < DateTime.Now.Date)
                throw new VigenciaInvalidaException();

            Inicio = inicio.Date;
            Termino = termino.Date;
        }

        public void DefinirNovoInicio(DateTime inicio)
        {
            if (inicio.Date > Termino.Value.Date || inicio.Year != Inicio.Value.Year)
                throw new VigenciaInvalidaException();

            Inicio = inicio.Date;
        }

        public void DefinirNovoTermino(DateTime termino)
        {
            if (termino.Date < DateTime.Now.Date || termino.Year != Termino.Value.Year)
                throw new VigenciaInvalidaException();

            Termino = termino.Date;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Inicio;
            yield return Termino;
        }
    }
}