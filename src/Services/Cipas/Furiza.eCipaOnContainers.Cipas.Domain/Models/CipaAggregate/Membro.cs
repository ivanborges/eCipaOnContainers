using Furiza.eCipaOnContainers.Cipas.Domain.Exceptions;
using Furiza.Base.Core.SeedWork;
using System;

namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.CipaAggregate
{
    public class Membro : Entity
    {
        public string UserName { get; private set; }
        public string NomeCompleto { get; private set; }
        public FuncaoMembro Funcao { get; private set; }

        private Membro() { }

        public Membro(string userName, string nomeCompleto, FuncaoMembro funcao) : this()
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new UsuarioNaoPodeSerNuloException();

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            UserName = userName.Trim();
            NomeCompleto = nomeCompleto?.Trim();
            Funcao = funcao;
        }
    }
}