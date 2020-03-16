using AutoMapper;
using Furiza.AspNetCore.ExceptionHandling;
using Furiza.AspNetCore.WebApi.Configuration;
using Furiza.Base.Core.Exceptions.Serialization;
using Furiza.Base.Core.Identity.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Furiza.eCipaOnContainers.Cipas.Application.Commands;
using Furiza.eCipaOnContainers.Cipas.Application.Commands.CipaCommands;
using Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate;
using Furiza.eCipaOnContainers.Cipas.WebApi.Dtos.v1.Cipas;
using Furiza.eCipaOnContainers.Cipas.WebApi.Exceptions;
using Furiza.eCipaOnContainers.Cipas.WebApi.Queries.Cipa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Cipas.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CipasController : RootController
    {
        private readonly ICipaReadOnlyRepository cipaReadOnlyRepository;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IUserPrincipalBuilder userPrincipalBuilder;

        public CipasController(ICipaReadOnlyRepository cipaReadOnlyRepository,
            IMediator mediator,
            IMapper mapper,
            IUserPrincipalBuilder userPrincipalBuilder)
        {
            this.cipaReadOnlyRepository = cipaReadOnlyRepository ?? throw new ArgumentNullException(nameof(cipaReadOnlyRepository));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ObterCipasQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> GetManyAsync([FromQuery]ObterCipasQuery query)
        {
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        [HttpGet("{id}", Name = "CipasGet")]
        [ProducesResponseType(typeof(ObterCipaQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> GetAsync([FromRoute]Guid id)
        {
            var query = new ObterCipaQuery()
            {
                CipaId = id
            };
            var queryResult = await mediator.Send(query);
            if (queryResult == null)
                throw new ResourceNotFoundException(new ResourceNotFoundExceptionItem[] { CipasResourceNotFoundExceptionItem.Cipa });

            return Ok(queryResult);
        }
        
        [HttpGet("AtivasDoUsuarioLogado")]
        [ProducesResponseType(typeof(ObterCipasAtivasDoUsuarioQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AtivasDoUsuarioLogadoGetAsync()
        {
            var query = new ObterCipasAtivasDoUsuarioQuery()
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
        public async Task<IActionResult> PostAsync([FromBody]CipasPost model)
        {
            var command = mapper.Map<CipasPost, CriarCipaCommand>(model);
            var commandResult = await mediator.Send(command);

            return CreatedAtRoute("CipasGet", new { id = commandResult.Id }, commandResult);
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
            [FromBody]CipasPut model)
        {
            var cipa = await ObterCipaAsync(id);

            var command = mapper.Map<CipasPut, AtualizarCipaCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Cipa = cipa;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/AlternarStatusDeAtividade")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> AlternarStatusDeAtividadePostAsync(Guid id)
        {
            var cipa = await ObterCipaAsync(id);

            var command = new AlternarStatusDeAtividadeDaCipaCommand()
            {
                Cipa = cipa
            };

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Membros")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> MembrosPostAsync(Guid id,
            [FromBody]MembrosCipasPost model)
        {
            var cipa = await ObterCipaAsync(id);

            var command = mapper.Map<MembrosCipasPost, AdicionarMembroACipaCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Cipa = cipa;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpDelete("{id}/Membros/{membroId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> MembrosDeleteAsync(Guid id,
            Guid membroId)
        {
            var cipa = await ObterCipaAsync(id);

            var command = new RemoverMembroDaCipaCommand()
            {
                Cipa = cipa,
                MembroId = membroId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}/Estabelecimentos")]
        [ProducesResponseType(typeof(ObterEstabelecimentosDaCipaQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> EstabelecimentosGetAsync([FromRoute]Guid id)
        {
            var cipa = await ObterCipaAsync(id);

            var query = new ObterEstabelecimentosDaCipaQuery()
            {
                CipaId = cipa.Id
            };
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost("{id}/Estabelecimentos")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> EstabelecimentosPostAsync(Guid id,
            [FromBody]EstabelecimentosCipasPost model)
        {
            var cipa = await ObterCipaAsync(id);

            var command = mapper.Map<EstabelecimentosCipasPost, AdicionarEstabelecimentoACipaCommand>(model, opts =>
                opts.AfterMap((s, d) =>
                {
                    d.Cipa = cipa;
                }));

            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpDelete("{id}/Estabelecimentos/{estabelecimentoId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> EstabelecimentosDeleteAsync(Guid id,
            Guid estabelecimentoId)
        {
            var cipa = await ObterCipaAsync(id);

            var command = new RemoverEstabelecimentoDaCipaCommand()
            {
                Cipa = cipa,
                EstabelecimentoId = estabelecimentoId
            };

            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}/Reunioes")]
        [ProducesResponseType(typeof(ObterReunioesDaCipaQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> ReunioesGetAsync([FromRoute]Guid id)
        {
            var cipa = await ObterCipaAsync(id);

            var query = new ObterReunioesDaCipaQuery()
            {
                CipaId = cipa.Id
            };
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        #region [+] Pvts
        private async Task<Cipa> ObterCipaAsync(Guid id)
        {
            var errors = new List<CipasResourceNotFoundExceptionItem>();

            var cipa = await cipaReadOnlyRepository.GetByIdAsync(id);
            if (cipa == null)
                errors.Add(CipasResourceNotFoundExceptionItem.Cipa);

            if (errors.Any())
                throw new ResourceNotFoundException(errors);

            return cipa;
        }
        #endregion
    }
}