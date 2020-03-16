using AutoMapper;
using Furiza.AspNetCore.ExceptionHandling;
using Furiza.AspNetCore.WebApi.Configuration;
using Furiza.Base.Core.Exceptions.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Furiza.eCipaOnContainers.Organizacoes.Application.Commands;
using Furiza.eCipaOnContainers.Organizacoes.Application.Commands.EstabelecimentoCommands;
using Furiza.eCipaOnContainers.Organizacoes.Domain.Models.EstabelecimentoAggregate;
using Furiza.eCipaOnContainers.Organizacoes.WebApi.Dtos.v1.Estabelecimentos;
using Furiza.eCipaOnContainers.Organizacoes.WebApi.Exceptions;
using Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries.Estabelecimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EstabelecimentosController : RootController
    {
        private readonly IEstabelecimentoReadOnlyRepository estabelecimentoReadOnlyRepository;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public EstabelecimentosController(IEstabelecimentoReadOnlyRepository estabelecimentoReadOnlyRepository,
            IMediator mediator,
            IMapper mapper)
        {
            this.estabelecimentoReadOnlyRepository = estabelecimentoReadOnlyRepository ?? throw new ArgumentNullException(nameof(estabelecimentoReadOnlyRepository));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ObterEstabelecimentosQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> GetManyAsync([FromQuery]ObterEstabelecimentosQuery query)
        {
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        [HttpGet("{id}", Name = "EstabelecimentosGet")]
        [ProducesResponseType(typeof(ObterEstabelecimentoQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> GetAsync([FromRoute]Guid id)
        {
            var query = new ObterEstabelecimentoQuery()
            {
                EstabelecimentoId = id
            };
            var queryResult = await mediator.Send(query);
            if (queryResult == null)
                throw new ResourceNotFoundException(new ResourceNotFoundExceptionItem[] { CoreBusinessResourceNotFoundExceptionItem.Estabelecimento });

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
        public async Task<IActionResult> PostAsync([FromBody]EstabelecimentosPost model)
        {
            var command = mapper.Map<EstabelecimentosPost, CriarEstabelecimentoCommand>(model);
            var commandResult = await mediator.Send(command);

            return CreatedAtRoute("EstabelecimentosGet", new { id = commandResult.Id }, commandResult);
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
            [FromBody]EstabelecimentosPut model)
        {
            var estabelecimento = await ObterEstabelecimentoAsync(id);

            var command = mapper.Map<EstabelecimentosPut, AtualizarEstabelecimentoCommand>(model, opts => 
                opts.AfterMap((s, d) => 
                    d.Estabelecimento = estabelecimento));

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
            var estabelecimento = await ObterEstabelecimentoAsync(id);

            var command = new AlternarStatusDeAtividadeDoEstabelecimentoCommand()
            {
                Estabelecimento = estabelecimento
            };

            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}/Cipas")]
        [ProducesResponseType(typeof(ObterCipasDoEstabelecimentoQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> CipasGetAsync([FromRoute]Guid id)
        {
            var estabelecimento = await ObterEstabelecimentoAsync(id);

            var query = new ObterCipasDoEstabelecimentoQuery()
            {
                EstabelecimentoId = estabelecimento.Id
            };
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        #region [+] Pvts
        private async Task<Estabelecimento> ObterEstabelecimentoAsync(Guid id)
        {
            var errors = new List<CoreBusinessResourceNotFoundExceptionItem>();

            var estabelecimento = await estabelecimentoReadOnlyRepository.GetByIdAsync(id);
            if (estabelecimento == null)
                errors.Add(CoreBusinessResourceNotFoundExceptionItem.Estabelecimento);

            if (errors.Any())
                throw new ResourceNotFoundException(errors);

            return estabelecimento;
        } 
        #endregion
    }
}