using System;

namespace Furiza.eCipaOnContainers.PlanosDeAcao.Application.Commands
{
    public class CriarCommandResult
    {
        public Guid Id { get; }
        public string Codigo { get; }

        public CriarCommandResult(Guid id)
        {
            Id = id;
        }

        public CriarCommandResult(Guid id, string codigo) : this(id)
        {
            Codigo = codigo;
        }
    }
}