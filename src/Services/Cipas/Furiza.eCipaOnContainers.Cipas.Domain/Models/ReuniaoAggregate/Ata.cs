using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.eCipaOnContainers.Cipas.Domain.ValueObjects;
using Furiza.Base.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public class Ata : Entity
    {
        public string Codigo { get; private set; }
        public string CodigoCipa { get; private set; }
        public int Numero { get; private set; }
        public string Local { get; private set; }
        public DateTime? Inicio { get; private set; }
        public DateTime? Termino { get; private set; }
        public StatusAta Status { get; private set; }

        public IReadOnlyCollection<Participante> Participantes => _participantes;
        private readonly List<Participante> _participantes;

        public IReadOnlyCollection<Ausente> Ausentes => _ausentes;
        private readonly List<Ausente> _ausentes;

        public IReadOnlyCollection<Assunto> Assuntos => _assuntos;
        private readonly List<Assunto> _assuntos;

        public Acao Finalizacao { get; private set; }
        public Acao Aprovacao { get; private set; }
        public Acao Fechamento { get; private set; }

        private Ata()
        {
            _participantes = new List<Participante>();
            _ausentes = new List<Ausente>();
            _assuntos = new List<Assunto>();
        }

        public Ata(string criador, int numero, string codigoCipa, string local, DateTime inicio, DateTime termino) : this()
        {
            if (numero <= 0)
                throw new NumeroDeIdentificacaoInvalidoException();

            if (string.IsNullOrWhiteSpace(codigoCipa))
                throw new CodigoNaoPodeSerNuloException();

            if (termino < inicio)
                throw new DataNaoPodeSerNoPassadoException();

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            CreationUser = criador;
            Codigo = $"{codigoCipa}-ATA-{numero.ToString().PadLeft(3, '0')}";
            CodigoCipa = codigoCipa;
            Numero = numero;
            Local = local?.Trim();
            Inicio = inicio;
            Termino = termino;
            Status = StatusAta.EmEdicao;
            Finalizacao = Acao.GetEmpty();
            Aprovacao = Acao.GetEmpty();
            Fechamento = Acao.GetEmpty();
        }
        
        public void Finalizar(string ator)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            if (_participantes.Count == 0)
                throw new AtaDeReuniaoSemParticipanteException();

            if (_assuntos.Count == 0)
                throw new AtaDeReuniaoSemAssuntoException();

            Status = StatusAta.Finalizada;
            Finalizacao = new Acao(DateTime.Now, ator);
        }

        public void Reabrir()
        {
            if (Status != StatusAta.Finalizada)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.Finalizada, Status);

            foreach (var participante in Participantes)
                participante.DarConsent(Status, false, "Consent automático por reabertura da ata.");

            Status = StatusAta.EmEdicao;
            Finalizacao = Acao.GetEmpty();
            Aprovacao = Acao.GetEmpty();
            Fechamento = Acao.GetEmpty();
        }

        public void Aprovar(string ator)
        {
            if (Status != StatusAta.Finalizada)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.Finalizada, Status);

            //TODO: validar se é presidente ou vice

            Status = StatusAta.Aprovada;
            Aprovacao = new Acao(DateTime.Now, ator);
        }

        public void Fechar(string ator)
        {
            CertificarQueAtaEstaAptaParaFechamento();

            Status = StatusAta.Fechada;
            Fechamento = new Acao(DateTime.Now, ator);
        }

        public bool PossuiAlgumaPendencia()
        {
            return Status != StatusAta.Aprovada || Participantes.Any(p => !p.PossuiConsentValido) || Ausentes.Any(a => !a.PossuiConsentValido);
        }

        public void DefinirNovoLocal(string novoLocal)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            Local = novoLocal?.Trim();
        }

        public void DefinirNovoPeriodo(DateTime novoInicio, DateTime novoTermino)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            if (novoTermino < novoInicio)
                throw new DataNaoPodeSerNoPassadoException();

            Inicio = novoInicio;
            Termino = novoTermino;
        }

        public void AdicionarParticipante(string nomeCompleto, string email)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            if (_participantes.Any(r => r.Email == email))
                throw new ParticipanteDaAtaDeReuniaoJaExistenteException();

            _participantes.Add(new Participante(nomeCompleto, email));
        }

        public void AdicionarParticipanteConvidado(string nomeCompleto, string email, string organizacao, string funcao)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            if (_participantes.Any(r => r.Email == email))
                throw new ParticipanteDaAtaDeReuniaoJaExistenteException();

            _participantes.Add(new Participante(nomeCompleto, email, organizacao, funcao));
        }

        public Participante ObterParticipante(Guid participanteId)
        {
            var participante = _participantes.FirstOrDefault(i => i.Id == participanteId) ??
                throw new ParticipanteDeAtaDeReuniaoInvalidoException();

            return participante;
        }

        public void RemoverParticipante(Guid participanteId)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            _participantes.Remove(ObterParticipante(participanteId));
        }

        public void AdicionarAusente(string nomeCompleto, string email, JustificativaAusencia justificativa)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            if (_ausentes.Any(r => r.Email == email))
                throw new AusenteDaAtaDeReuniaoJaExistenteException();

            _ausentes.Add(new Ausente(nomeCompleto, email, justificativa));
        }

        public Ausente ObterAusente(Guid ausenteId)
        {
            var ausente = _ausentes.FirstOrDefault(i => i.Id == ausenteId) ??
                throw new AusenteDeAtaDeReuniaoInvalidoException();

            return ausente;
        }

        public void RemoverAusente(Guid ausenteId)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            _ausentes.Remove(ObterAusente(ausenteId));
        }

        public void AdicionarAssunto(string criador, ClassificacaoDaInformacao classificacaoDaInformacao, TipoAssunto tipo, string descricao, string keywords)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            var numeroAssunto = _assuntos.Any()
                ? _assuntos.Max(a => a.Numero) + 1
                : 1;

            _assuntos.Add(new Assunto(criador, classificacaoDaInformacao, tipo, numeroAssunto, descricao, keywords));
        }

        public Assunto ObterAssunto(Guid assuntoId)
        {
            var assunto = _assuntos.FirstOrDefault(i => i.Id == assuntoId) ??
                throw new AssuntoDeAtaDeReuniaoInvalidoException();

            return assunto;
        }

        public void RemoverAssunto(Guid assuntoId)
        {
            if (Status != StatusAta.EmEdicao)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.EmEdicao, Status);

            _assuntos.Remove(ObterAssunto(assuntoId));
        }

        #region [+] Pvts
        private void CertificarQueAtaEstaAptaParaFechamento()
        {
            if (!PossuiAlgumaPendencia())
                return;

            if (Status != StatusAta.Aprovada)
                throw new StatusAtaDeReuniaoInvalidoException(StatusAta.Aprovada, Status);

            if (Participantes.Any(p => !p.PossuiConsentValido))
                throw new AtaDeReuniaoSemConsentFavoravelDeTodosParticipantesException();

            if (Ausentes.Any(a => !a.PossuiConsentValido))
                throw new AtaDeReuniaoSemConsentFavoravelDeTodosAusentesException();
        } 
        #endregion
    }
}