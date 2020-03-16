using Furiza.eCipaOnContainers.Cipas.Domain.Models;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using MediatR;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands
{
    public class AdicionarAssuntoAAtaDeReuniaoCommand : IRequest
    {
        public Reuniao Reuniao { get; set; }
        public Guid AtaId { get; set; }
        public ClassificacaoDaInformacao ClassificacaoDaInformacao { get; set; }
        public TipoAssunto Tipo { get; set; }
        public string Descricao { get; set; }
        public string Keywords { get; set; }
    }
}