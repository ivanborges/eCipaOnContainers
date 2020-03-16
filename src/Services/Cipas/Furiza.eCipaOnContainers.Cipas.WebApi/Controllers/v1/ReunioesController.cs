using AutoMapper;
using Furiza.AspNetCore.ExceptionHandling;
using Furiza.AspNetCore.WebApi.Configuration;
using Furiza.Base.Core.Exceptions.Serialization;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Furiza.eCipaOnContainers.Cipas.Application.Commands;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.ReuniaoCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate;
using Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Reunioes;
using Furiza.eCipaOnContainers.Cipas.WebApi.Exceptions;
using Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Reuniao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ReunioesController : RootController
    {
        private readonly IReuniaoReadOnlyRepository reuniaoReadOnlyRepository;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IUserPrincipalBuilder userPrincipalBuilder;

        public ReunioesController(IReuniaoReadOnlyRepository reuniaoReadOnlyRepository,
            IMediator mediator,
            IMapper mapper,
            IUserPrincipalBuilder userPrincipalBuilder)
        {
            this.reuniaoReadOnlyRepository = reuniaoReadOnlyRepository ?? throw new ArgumentNullException(nameof(reuniaoReadOnlyRepository));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
        }

        [HttpGet("{id}", Name = "ReunioesGet")]
        [ProducesResponseType(typeof(ObterReuniaoQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> GetAsync([FromRoute]Guid id)
        {
            var query = new ObterReuniaoQuery()
            {
                ReuniaoId = id
            };
            var queryResult = await mediator.Send(query);
            if (queryResult == null)
                throw new ResourceNotFoundException(new ResourceNotFoundExceptionItem[] { CipasResourceNotFoundExceptionItem.Reuniao });

            return Ok(queryResult);
        }

        [HttpGet("AgendadasDoUsuarioLogado")]
        [ProducesResponseType(typeof(ObterReunioesAgendadasDoUsuarioQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AgendadasDoUsuarioLogadoGetAsync()
        {
            var query = new ObterReunioesAgendadasDoUsuarioQuery()
            {
                UserName = userPrincipalBuilder.UserPrincipal.UserName
            };
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost]
        [ProducesResponseType(typeof(CriarCommandResult), 201)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> PostAsync([FromBody]ReunioesPost model)
        {
            var command = mapper.Map<ReunioesPost, CriarReuniaoCommand>(model);
            var commandResult = await mediator.Send(command);

            return CreatedAtRoute("ReunioesGet", new { id = commandResult.Id },  commandResult);
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> PutAsync(Guid id,
            [FromBody]ReunioesPut model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<ReunioesPut, AtualizarReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/PlanosDeAcao")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> PlanosDeAcaoPostAsync(Guid id,
            [FromBody]PlanosDeAcaoReunioesPost model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new DefinirPlanoDeAcaoDaReuniaoCommand()
            {
                Reuniao = reuniao,
                PlanoDeAcaoId = model.PlanoDeAcaoId.Value
            };

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpDelete("{id}/PlanosDeAcao/{planoDeAcaoId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> PlanosDeAcaoDeleteAsync(Guid id,
            Guid planoDeAcaoId)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new RemoverPlanoDeAcaoDaReuniaoCommand()
            {
                Reuniao = reuniao,
                PlanoDeAcaoId = planoDeAcaoId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Cancelar")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> CancelarPostAsync(Guid id)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new CancelarReuniaoCommand()
            {
                Reuniao = reuniao
            };

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Atas")]
        [ProducesResponseType(typeof(CriarCommandResult), 200)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AtasPostAsync(Guid id,
            [FromBody]AtasReunioesPost model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<AtasReunioesPost, GerarAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                }));

            var commandResult = await mediator.Send(command);

            return Ok(commandResult);
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPut("{id}/Atas/{ataId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AtasPutAsync(Guid id,
            Guid ataId,
            [FromBody]AtasReunioesPut model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<AtasReunioesPut, AtualizarAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Atas/{ataId}/Finalizar")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> FinalizarAtasPostAsync(Guid id,
            Guid ataId)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new FinalizarAtaDeReuniaoCommand()
            {
                Reuniao = reuniao,
                AtaId = ataId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Atas/{ataId}/Reabrir")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ReabrirAtasPostAsync(Guid id,
            Guid ataId)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new ReabrirAtaDeReuniaoCommand()
            {
                Reuniao = reuniao,
                AtaId = ataId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireApproverRights)]
        [HttpPost("{id}/Atas/{ataId}/Aprovar")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AprovarAtasPostAsync(Guid id,
            Guid ataId)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new AprovarAtaDeReuniaoCommand()
            {
                Reuniao = reuniao,
                AtaId = ataId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Atas/{ataId}/Participantes")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ParticipantesAtasPostAsync(Guid id,
        Guid ataId,
        [FromBody]ParticipantesAtasReunioesPost model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<ParticipantesAtasReunioesPost, AdicionarParticipanteAAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Atas/{ataId}/ParticipantesConvidados")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ParticipantesConvidadosAtasPostAsync(Guid id,
        Guid ataId,
        [FromBody]ParticipantesConvidadosAtasReunioesPost model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<ParticipantesConvidadosAtasReunioesPost, AdicionarParticipanteConvidadoAAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpDelete("{id}/Atas/{ataId}/Participantes/{participanteId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ParticipantesAtasDeleteAsync(Guid id,
            Guid ataId,
            Guid participanteId)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new RemoverParticipanteDaAtaDeReuniaoCommand()
            {
                Reuniao = reuniao,
                AtaId = ataId,
                ParticipanteId = participanteId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/Atas/{ataId}/Participantes/{participanteId}/Consents")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ConsentsParticipantesAtasPostAsync(Guid id,
            Guid ataId,
            Guid participanteId,
            [FromBody]ConsentsParticipantesAtasReunioesPost model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<ConsentsParticipantesAtasReunioesPost, DarConsentDoParticipanteDaAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                    d.ParticipanteId = participanteId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}/Atas/{ataId}/Participantes/{participanteId}/Consents")]
        [ProducesResponseType(typeof(ObterConsentsDoParticipanteQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ConsentsParticipantesAtasGetAsync(Guid id,
            Guid ataId,
            Guid participanteId)
        {
            var query = new ObterConsentsDoParticipanteQuery()
            {
                ReuniaoId = id,
                AtaId = ataId,
                ParticipanteId = participanteId
            };
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Atas/{ataId}/Ausentes")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AusentesAtasPostAsync(Guid id,
        Guid ataId,
        [FromBody]AusentesAtasReunioesPost model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<AusentesAtasReunioesPost, AdicionarAusenteAAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPut("{id}/Atas/{ataId}/Ausentes/{ausenteId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AusentesAtasPutAsync(Guid id,
            Guid ataId,
            Guid ausenteId,
            [FromBody]AusentesAtasReunioesPut model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<AusentesAtasReunioesPut, AtualizarAusenteDaAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                    d.AusenteId = ausenteId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpDelete("{id}/Atas/{ataId}/Ausentes/{ausenteId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AusentesAtasDeleteAsync(Guid id,
            Guid ataId,
            Guid ausenteId)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new RemoverAusenteDaAtaDeReuniaoCommand()
            {
                Reuniao = reuniao,
                AtaId = ataId,
                AusenteId = ausenteId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/Atas/{ataId}/Ausentes/{ausenteId}/Consents")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ConsentsAusentesAtasPostAsync(Guid id,
            Guid ataId,
            Guid ausenteId,
            [FromBody]ConsentsAusentesAtasReunioesPost model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<ConsentsAusentesAtasReunioesPost, DarConsentDoAusenteDaAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                    d.AusenteId = ausenteId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}/Atas/{ataId}/Ausentes/{ausenteId}/Consents")]
        [ProducesResponseType(typeof(ObterConsentsDoAusenteQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ConsentsAusentesAtasGetAsync(Guid id,
            Guid ataId,
            Guid ausenteId)
        {
            var query = new ObterConsentsDoAusenteQuery()
            {
                ReuniaoId = id,
                AtaId = ataId,
                AusenteId = ausenteId
            };
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Atas/{ataId}/Assuntos")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AssuntosAtasPostAsync(Guid id,
        Guid ataId,
        [FromBody]AssuntosAtasReunioesPost model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<AssuntosAtasReunioesPost, AdicionarAssuntoAAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPut("{id}/Atas/{ataId}/Assuntos/{assuntoId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AssuntosAtasPutAsync(Guid id,
            Guid ataId,
            Guid assuntoId,
            [FromBody]AssuntosAtasReunioesPut model)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = mapper.Map<AssuntosAtasReunioesPut, AtualizarAssuntoDaAtaDeReuniaoCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Reuniao = reuniao;
                    d.AtaId = ataId;
                    d.AssuntoId = assuntoId;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpDelete("{id}/Atas/{ataId}/Assuntos/{assuntoId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AssuntosAtasDeleteAsync(Guid id,
            Guid ataId,
            Guid assuntoId)
        {
            var reuniao = await ObterReuniaoAsync(id);

            var command = new RemoverAssuntoDaAtaDeReuniaoCommand()
            {
                Reuniao = reuniao,
                AtaId = ataId,
                AssuntoId = assuntoId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}/Atas/{ataId}/Assuntos/{assuntoId}/Alteracoes")]
        [ProducesResponseType(typeof(ObterAlteracoesDoAssuntoQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AlteracoesAssuntosAtasGetAsync(Guid id,
            Guid ataId,
            Guid assuntoId)
        {
            var query = new ObterAlteracoesDoAssuntoQuery()
            {
                ReuniaoId = id,
                AtaId = ataId,
                AssuntoId = assuntoId
            };
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        #region [+] Pvts
        private async Task<Reuniao> ObterReuniaoAsync(Guid id)
        {
            var errors = new List<CipasResourceNotFoundExceptionItem>();

            var reuniao = await reuniaoReadOnlyRepository.GetByIdAsync(id);
            if (reuniao == null)
                errors.Add(CipasResourceNotFoundExceptionItem.Reuniao);

            if (errors.Any())
                throw new ResourceNotFoundException(errors);

            return reuniao;
        }
        #endregion
    }
}