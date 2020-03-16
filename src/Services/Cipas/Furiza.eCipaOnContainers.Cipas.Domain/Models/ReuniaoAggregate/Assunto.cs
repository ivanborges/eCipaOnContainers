using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.Base.Core.SeedWork;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public class Assunto : Entity
    {
        public ClassificacaoDaInformacao ClassificacaoDaInformacao { get; set; }

        public TipoAssunto Tipo { get; set; }

        public int Numero { get; private set; }

        public string Descricao { get; private set; }

        public string Keywords { get; set; }

        public int Versao { get; private set; }

        public IReadOnlyCollection<Alteracao> Alteracoes => _alteracoes;
        private readonly List<Alteracao> _alteracoes;

        private Assunto()
        {
            _alteracoes = new List<Alteracao>();
        }

        public Assunto(string criador, ClassificacaoDaInformacao classificacaoDaInformacao, TipoAssunto tipo, int numero, string descricao, string keywords) : this()
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new DescricaoNaoPodeSerNulaException();

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            CreationUser = criador;
            ClassificacaoDaInformacao = classificacaoDaInformacao;
            Tipo = tipo;
            Numero = numero;
            Descricao = descricao.Trim();
            Keywords = keywords?.Trim().ToLower();
            Versao = 1;
        }

        public void DefinirNovaDescricao(string criador, Ata ata, string novaDescricao)
        {
            if (string.IsNullOrWhiteSpace(novaDescricao))
                throw new DescricaoNaoPodeSerNulaException();

            if (ata.Status == StatusAta.Aprovada)
            {
                _alteracoes.Add(new Alteracao(CreationDate, CreationUser, Descricao, Versao));

                Versao++;

                foreach (var participante in ata.Participantes)
                    participante.DarConsent(ata.Status, false, $"Consent automático por alteração na descrição do assunto {Numero.ToString()}.");
            }

            CreationDate = DateTime.UtcNow;
            CreationUser = criador;
            Descricao = novaDescricao.Trim();
        }
    }
}