﻿using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class DarConsentDoParticipanteDaAtaDeReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
        public Guid AtaId { get; set; }
        public Guid ParticipanteId { get; set; }
        public bool Value { get; set; }
        public string Justificativa { get; set; }
    }
}