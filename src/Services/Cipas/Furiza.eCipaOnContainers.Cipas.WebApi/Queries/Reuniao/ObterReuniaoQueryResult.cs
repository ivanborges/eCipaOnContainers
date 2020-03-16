﻿using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using System;
using System.Collections.Generic;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao
{
    public class ObterReuniaoQueryResult
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public Guid? CipaId { get; set; }
        public string CipaCodigo { get; set; }
        public Mes? MesDeReferencia { get; set; }
        public DateTime? DataPrevista { get; set; }
        public string Local { get; set; }
        public StatusAgendamento? Status { get; set; }
        public bool? Extraordinaria { get; set; }
        public Guid? PlanoDeAcaoId { get; set; }
        public ObterReuniaoQueryResultInnerAta Ata { get; set; }

        public class ObterReuniaoQueryResultInnerAta
        {
            public Guid? AtaId { get; set; }
            public DateTime? AtaCreationDate { get; set; }
            public string AtaCreationUser { get; set; }
            public string Codigo { get; set; }
            public string CodigoCipa { get; set; }
            public int? Numero { get; set; }
            public string Local { get; set; }
            public DateTime? Inicio { get; set; }
            public DateTime? Termino { get; set; }
            public StatusAta? Status { get; set; }
            public DateTime? Finalizacao_Data { get; set; }
            public string Finalizacao_Ator { get; set; }
            public DateTime? Aprovacao_Data { get; set; }
            public string Aprovacao_Ator { get; set; }
            public DateTime? Fechamento_Data { get; set; }
            public string Fechamento_Ator { get; set; }
            public ICollection<ObterReuniaoQueryResultInnerParticipante> Participantes { get; set; }
            public ICollection<ObterReuniaoQueryResultInnerAusente> Ausentes { get; set; }
            public ICollection<ObterReuniaoQueryResultInnerAssunto> Assuntos { get; set; }
        }

        public class ObterReuniaoQueryResultInnerParticipante
        {
            public Guid? ParticipanteId { get; set; }
            public string ParticipanteNomeCompleto { get; set; }
            public string ParticipanteEmail { get; set; }
            public bool? ParticipantePossuiConsentValido { get; set; }
            public bool? EConvidado { get; set; }
            public string Organizacao { get; set; }
            public string Funcao { get; set; }
        }

        public class ObterReuniaoQueryResultInnerAusente
        {
            public Guid? AusenteId { get; set; }
            public string AusenteNomeCompleto { get; set; }
            public string AusenteEmail { get; set; }
            public JustificativaAusencia? Justificativa { get; set; }
            public bool? AusentePossuiConsentValido { get; set; }
        }

        public class ObterReuniaoQueryResultInnerAssunto
        {
            public Guid? AssuntoId { get; set; }
            public DateTime? AssuntoCreationDate { get; set; }
            public string AssuntoCreationUser { get; set; }
            public ClassificacaoDaInformacao? ClassificacaoDaInformacao { get; set; }
            public TipoAssunto? Tipo { get; set; }
            public int? AssuntoNumero { get; set; }
            public string Descricao { get; set; }
            public string Keywords { get; set; }
            public int? Versao { get; set; }
        }
    }
}