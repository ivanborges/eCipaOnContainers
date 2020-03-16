using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.Base.Core.SeedWork;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public class Alteracao : Entity
    {
        public string Descricao { get; private set; }

        public int Versao { get; private set; }

        private Alteracao() { }

        public Alteracao(DateTime creationDate, string criador, string descricao, int versao) : this()
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new DescricaoNaoPodeSerNulaException();

            Id = Guid.NewGuid();
            CreationDate = creationDate;
            CreationUser = criador;
            Descricao = descricao.Trim();
            Versao = versao;
        }
    }
}