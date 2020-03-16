using Furiza.Base.Core.SeedWork;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Exceptions;
using System;

namespace Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate
{
    public class Estabelecimento : Entity, IAggregateRoot
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public StatusAtividade Status { get; private set; }

        private Estabelecimento()
        {
        }

        public Estabelecimento(string codigo, string nome) : this()
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new CodigoNaoPodeSerNuloException();

            if (string.IsNullOrWhiteSpace(nome))
                throw new NomeNaoPodeSerNuloException();

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            Codigo = codigo.Trim();
            Nome = nome.Trim();
            Status = StatusAtividade.Ativo;
        }

        public void Ativar() => Status = StatusAtividade.Ativo;

        public void Inativar() => Status = StatusAtividade.Inativo;
    }
}