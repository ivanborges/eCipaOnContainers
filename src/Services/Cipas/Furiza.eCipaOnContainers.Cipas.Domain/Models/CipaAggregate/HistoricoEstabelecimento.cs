using Furiza.Base.Core.SeedWork;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate
{
    public class HistoricoEstabelecimento : Entity
    {
        public Guid EstabelecimentoId { get; private set; }
        public TipoEstabelecimento Tipo { get; private set; }

        private HistoricoEstabelecimento()
        {
        }

        public HistoricoEstabelecimento(Estabelecimento estabelecimento) : this()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            EstabelecimentoId = estabelecimento.EstabelecimentoId;
            Tipo = estabelecimento.Tipo;
        }
    }
}