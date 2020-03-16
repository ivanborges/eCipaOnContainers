using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.RazorPages.RestClients.Cipas.Reunioes
{
    public enum TipoAssunto
    {
        [Display(Name = "Plano de Trabalho")]
        PlanoDeTrabalho = -1,

        [Display(Name = "Considerações Iniciais")]
        ConsideracoesIniciais = 0,

        [Display(Name = "Acompanhamento do Plano de Ação")]
        AcompanhamentoDoPlanoDeAcao = 1,

        [Display(Name = "Assuntos Pendentes de Reuniões Anteriores")]
        AssuntosPendentesDeReunioesAnteriores = 2,

        [Display(Name = "Assuntos Concluídos de Reuniões Anteriores")]
        AssuntosConcluidosDeReunioesAnteriores = 3,

        [Display(Name = "Assuntos Gerais")]
        AssuntosGerais = 4
    }
}