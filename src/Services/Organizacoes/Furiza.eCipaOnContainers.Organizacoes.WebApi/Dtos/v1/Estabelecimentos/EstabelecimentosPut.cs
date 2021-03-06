﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Dtos.v1.Estabelecimentos
{
    public class EstabelecimentosPut
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}