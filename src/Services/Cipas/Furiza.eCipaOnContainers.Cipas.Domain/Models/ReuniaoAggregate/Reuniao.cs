using Furiza.Base.Core.SeedWork;
using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public class Reuniao : Entity, IAggregateRoot
    {
        public Guid CipaId { get; private set; }
        public Mes MesDeReferencia { get; private set; }
        public DateTime DataPrevista { get; private set; }
        public string Local { get; private set; }
        public StatusAgendamento Status { get; private set; }
        public bool Extraordinaria { get; private set; }
        public Guid? PlanoDeAcaoId { get; private set; }

        public Ata Ata { get; private set; }

        private Reuniao() { }

        public Reuniao(string criador, Guid cipaId, Mes mesDeReferencia, DateTime dataPrevista, string local, bool extraordinaria) : this()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            CreationUser = criador;
            CipaId = cipaId;
            MesDeReferencia = mesDeReferencia;
            DataPrevista = dataPrevista;
            Local = local?.Trim();
            Status = StatusAgendamento.Programado;
            Extraordinaria = extraordinaria;
        }

        public void DefinirNovoMesDeReferencia(Mes mesDeReferencia)
        {
            if (Status == StatusAgendamento.Realizado || Status == StatusAgendamento.Cancelado)
                throw new StatusAgendamentoNaoPermiteAlteracaoException();

            MesDeReferencia = mesDeReferencia;
        }

        public void DefinirNovaPrevisao(DateTime novaPrevisao)
        {
            if (Status == StatusAgendamento.Realizado || Status == StatusAgendamento.Cancelado)
                throw new StatusAgendamentoNaoPermiteAlteracaoException();

            if (novaPrevisao < DataPrevista)
                Status = StatusAgendamento.Adiantado;
            else if (novaPrevisao > DataPrevista)
                Status = StatusAgendamento.Adiado;

            DataPrevista = novaPrevisao;
        }

        public void DefinirNovoLocal(string novoLocal)
        {
            if (Status == StatusAgendamento.Realizado || Status == StatusAgendamento.Cancelado)
                throw new StatusAgendamentoNaoPermiteAlteracaoException();

            Local = novoLocal?.Trim();
        }

        public void DefinirPlanoDeAcao(Guid? planoDeAcaoId)
        {
            if (Status != StatusAgendamento.Realizado)
                throw new StatusAgendamentoNaoPermiteAlteracaoException();

            PlanoDeAcaoId = planoDeAcaoId;
        }

        public void Cancelar()
        {
            if (Status == StatusAgendamento.Realizado || Status == StatusAgendamento.Cancelado)
                throw new StatusAgendamentoNaoPermiteAlteracaoException();

            Status = StatusAgendamento.Cancelado;
        }

        public void GerarAta(string criador, int numeroAta, string codigoCipa, string local, DateTime inicio, DateTime termino)
        {
            if (Status == StatusAgendamento.Realizado || Status == StatusAgendamento.Cancelado)
                throw new StatusAgendamentoNaoPermiteAlteracaoException();

            if (Ata != null)
                throw new AtaDeReuniaoJaGeradaException();

            Ata = new Ata(criador, numeroAta, codigoCipa, local, inicio, termino);

            Status = StatusAgendamento.Realizado;
        }
    }
}