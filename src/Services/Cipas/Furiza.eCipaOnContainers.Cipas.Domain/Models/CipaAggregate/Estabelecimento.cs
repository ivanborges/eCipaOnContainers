using Furiza.Base.Core.SeedWork;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate
{
    public class Estabelecimento : Entity
    {
        public Guid EstabelecimentoId { get; private set; }
        public TipoEstabelecimento Tipo { get; private set; }

        private Estabelecimento()
        {
        }

        public Estabelecimento(Guid estabelecimentoId, TipoEstabelecimento tipo) : this()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            EstabelecimentoId = estabelecimentoId;
            Tipo = tipo;
        }
    }
}