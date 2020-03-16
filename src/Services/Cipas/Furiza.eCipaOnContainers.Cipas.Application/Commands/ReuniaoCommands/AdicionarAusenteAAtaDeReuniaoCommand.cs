﻿using MediatR;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class AdicionarAusenteAAtaDeReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
        public Guid AtaId { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public JustificativaAusencia Justificativa { get; set; }
    }
}