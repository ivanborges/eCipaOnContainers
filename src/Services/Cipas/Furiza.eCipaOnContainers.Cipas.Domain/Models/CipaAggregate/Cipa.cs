using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.eCipaOnContainers.Cipas.Domain.ValueObjects;
using Furiza.Base.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate
{
    public class Cipa : Entity, IAggregateRoot
    {
        public string Codigo { get; private set; }
        public int Numero { get; private set; }
        public int CodigoEmpresa { get; private set; }
        public Vigencia Mandato { get; private set; }
        public StatusAtividade Status { get; private set; }
        public bool Terceirizada => CodigoEmpresa > 99999;

        public IReadOnlyCollection<Membro> Membros => _membros;
        private readonly List<Membro> _membros;

        public IReadOnlyCollection<Estabelecimento> Estabelecimentos => _estabelecimentos;
        private readonly List<Estabelecimento> _estabelecimentos;

        public IReadOnlyCollection<HistoricoEstabelecimento> HistoricoEstabelecimentos => _historicoEstabelecimentos;
        private readonly List<HistoricoEstabelecimento> _historicoEstabelecimentos;

        private Cipa()
        {
            _membros = new List<Membro>();
            _estabelecimentos = new List<Estabelecimento>();
            _historicoEstabelecimentos = new List<HistoricoEstabelecimento>();
        }

        public Cipa(int numero, int codigoEmpresa, Vigencia mandato) : this()
        {
            if (numero <= 0)
                throw new NumeroDeIdentificacaoInvalidoException();

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            Codigo = $"{codigoEmpresa.ToString()}-{mandato.Inicio.Value.Year.ToString()}/{mandato.Termino.Value.Year.ToString()}-{numero.ToString().PadLeft(3, '0')}";
            Numero = numero;
            CodigoEmpresa = codigoEmpresa;
            Mandato = mandato;
            Status = StatusAtividade.Ativo;
        }

        public void Ativar() => Status = StatusAtividade.Ativo;

        public void Inativar() => Status = StatusAtividade.Inativo;

        public void AdicionarMembro(string userName, string nomeCompleto, FuncaoMembro funcao)
        {
            if (_membros.Any(m => m.UserName == userName))
                throw new MembroDaCipaJaExistenteException();

            if (funcao == FuncaoMembro.Presidente && _membros.Any(m => m.Funcao == FuncaoMembro.Presidente))
                throw new CipaJaPossuiPresidenteException();

            if (funcao == FuncaoMembro.VicePresidente && _membros.Any(m => m.Funcao == FuncaoMembro.VicePresidente))
                throw new CipaJaPossuiVicePresidenteException();

            _membros.Add(new Membro(userName, nomeCompleto, funcao));
        }

        public Membro ObterMembro(Guid membroId)
        {
            var membro = _membros.FirstOrDefault(i => i.Id == membroId) ??
                throw new MembroDaCipaInvalidoException();

            return membro;
        }

        public void RemoverMembro(Guid membroId)
        {
            _membros.Remove(ObterMembro(membroId));
        }

        public void AdicionarEstabelecimento(Guid estabelecimentoId, TipoEstabelecimento tipo)
        {
            if (_estabelecimentos.Any(m => m.EstabelecimentoId == estabelecimentoId))
                throw new EstabelecimentoDaCipaJaExistenteException();

            if (tipo == TipoEstabelecimento.Principal && _estabelecimentos.Any(m => m.Tipo == TipoEstabelecimento.Principal))
                throw new CipaJaPossuiEstabelecimentoPrincipalException();

            _estabelecimentos.Add(new Estabelecimento(estabelecimentoId, tipo));
        }

        public Estabelecimento ObterEstabelecimento(Guid estabelecimentoId)
        {
            var estabelecimento = _estabelecimentos.FirstOrDefault(i => i.Id == estabelecimentoId) ??
                throw new EstabelecimentoDaCipaInvalidoException();

            return estabelecimento;
        }

        public void RemoverEstabelecimento(Guid estabelecimentoId)
        {
            var estabelecimentoASerRemovido = ObterEstabelecimento(estabelecimentoId);
            _historicoEstabelecimentos.Add(new HistoricoEstabelecimento(estabelecimentoASerRemovido));
            _estabelecimentos.Remove(estabelecimentoASerRemovido);
        }
    }
}