using CentralPecas.VariaveisLinguisticas;
using FLS;
using FLS.MembershipFunctions;
using FLS.Rules;

namespace CentralPecas;

public static class ColecaoRegrasInferencia
{
    private static readonly TempoMedioEspera TempoMedioEspera = TempoMedioEspera.Instancia;
    private static readonly FatorUtilizacao FatorUtilizacao = FatorUtilizacao.Instancia;
    private static readonly NumeroFuncionarios NumeroFuncionarios = NumeroFuncionarios.Instancia;
    private static readonly NumeroPecasExtras NumeroPecasExtras = NumeroPecasExtras.Instancia;

    private static readonly RegraInferencia[] _regras =
    [
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Baixo,  NumeroFuncionarios.Pequeno, NumeroPecasExtras.MuitoGrande),
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Baixo,  NumeroFuncionarios.Medio,   NumeroPecasExtras.Grande),
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Baixo,  NumeroFuncionarios.Grande,  NumeroPecasExtras.PoucoGrande),
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Medio,  NumeroFuncionarios.Pequeno, NumeroPecasExtras.Grande),
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Medio,  NumeroFuncionarios.Medio,   NumeroPecasExtras.PoucoGrande),
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Medio,  NumeroFuncionarios.Grande,  NumeroPecasExtras.Medio),
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Alto,   NumeroFuncionarios.Pequeno, NumeroPecasExtras.PoucoGrande),
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Alto,   NumeroFuncionarios.Medio,   NumeroPecasExtras.Medio),
        new(TempoMedioEspera.MuitoPequeno,  FatorUtilizacao.Alto,   NumeroFuncionarios.Grande,  NumeroPecasExtras.PoucoPequeno),

        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Baixo,  NumeroFuncionarios.Pequeno, NumeroPecasExtras.Grande),
        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Baixo,  NumeroFuncionarios.Medio,   NumeroPecasExtras.PoucoGrande),
        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Baixo,  NumeroFuncionarios.Grande,  NumeroPecasExtras.Medio),
        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Medio,  NumeroFuncionarios.Pequeno, NumeroPecasExtras.PoucoGrande),
        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Medio,  NumeroFuncionarios.Medio,   NumeroPecasExtras.Medio),
        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Medio,  NumeroFuncionarios.Grande,  NumeroPecasExtras.PoucoPequeno),
        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Alto,   NumeroFuncionarios.Pequeno, NumeroPecasExtras.Medio),
        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Alto,   NumeroFuncionarios.Medio,   NumeroPecasExtras.PoucoPequeno),
        new(TempoMedioEspera.Pequeno,       FatorUtilizacao.Alto,   NumeroFuncionarios.Grande,  NumeroPecasExtras.Pequeno),

        new(TempoMedioEspera.Medio,         FatorUtilizacao.Baixo,  NumeroFuncionarios.Pequeno, NumeroPecasExtras.PoucoGrande),
        new(TempoMedioEspera.Medio,         FatorUtilizacao.Baixo,  NumeroFuncionarios.Medio,   NumeroPecasExtras.Medio),
        new(TempoMedioEspera.Medio,         FatorUtilizacao.Baixo,  NumeroFuncionarios.Grande,  NumeroPecasExtras.PoucoPequeno),
        new(TempoMedioEspera.Medio,         FatorUtilizacao.Medio,  NumeroFuncionarios.Pequeno, NumeroPecasExtras.Medio),
        new(TempoMedioEspera.Medio,         FatorUtilizacao.Medio,  NumeroFuncionarios.Medio,   NumeroPecasExtras.PoucoPequeno),
        new(TempoMedioEspera.Medio,         FatorUtilizacao.Medio,  NumeroFuncionarios.Grande,  NumeroPecasExtras.Pequeno),
        new(TempoMedioEspera.Medio,         FatorUtilizacao.Alto,   NumeroFuncionarios.Pequeno, NumeroPecasExtras.PoucoPequeno),
        new(TempoMedioEspera.Medio,         FatorUtilizacao.Alto,   NumeroFuncionarios.Medio,   NumeroPecasExtras.Pequeno),
        new(TempoMedioEspera.Medio,         FatorUtilizacao.Alto,   NumeroFuncionarios.Grande,  NumeroPecasExtras.MuitoPequeno),
    ];

    public static readonly IReadOnlyList<FuzzyRule> Regras = _regras
        .Select(regraInferencia => Rule
            .If(TempoMedioEspera.Is(regraInferencia.TempoMedioEspera)
                .And(FatorUtilizacao.Is(regraInferencia.FatorUtilizacao))
                .And(NumeroFuncionarios.Is(regraInferencia.NumeroFuncionarios)))
            .Then(NumeroPecasExtras.Is(regraInferencia.NumeroPecasExtras)))
        .ToArray();

    private sealed record class RegraInferencia(
        IMembershipFunction TempoMedioEspera,
        IMembershipFunction FatorUtilizacao,
        IMembershipFunction NumeroFuncionarios,
        IMembershipFunction NumeroPecasExtras);
}
