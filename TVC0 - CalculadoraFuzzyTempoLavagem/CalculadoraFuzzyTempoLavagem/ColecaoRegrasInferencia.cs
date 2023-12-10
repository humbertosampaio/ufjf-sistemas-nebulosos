using FLS;
using FLS.MembershipFunctions;
using FLS.Rules;

namespace CalculadoraFuzzyTempoLavagem;

public static class ColecaoRegrasInferencia
{
    private static readonly Sujeira Sujeira = VariaveisLinguisticas.Sujeira;
    private static readonly Mancha Mancha = VariaveisLinguisticas.Mancha;
    private static readonly Tempo Tempo = VariaveisLinguisticas.Tempo;

    private static readonly RegraInferencia[] _regras =
    [
        new(Sujeira.PS, Mancha.SM, Tempo.MC),
        new(Sujeira.PS, Mancha.MM, Tempo.M),
        new(Sujeira.PS, Mancha.GM, Tempo.L),
        new(Sujeira.MS, Mancha.SM, Tempo.C),
        new(Sujeira.MS, Mancha.MM, Tempo.M),
        new(Sujeira.MS, Mancha.GM, Tempo.L),
        new(Sujeira.GS, Mancha.SM, Tempo.M),
        new(Sujeira.GS, Mancha.MM, Tempo.L),
        new(Sujeira.GS, Mancha.GM, Tempo.ML)
    ];

    public static readonly IReadOnlyList<FuzzyRule> Regras = _regras
        .Select(regraInferencia => Rule
            .If(Sujeira.Is(regraInferencia.Sujeira).And(Mancha.Is(regraInferencia.Mancha)))
            .Then(Tempo.Is(regraInferencia.Tempo)))
        .ToArray();

    private sealed record class RegraInferencia(IMembershipFunction Sujeira, IMembershipFunction Mancha, IMembershipFunction Tempo);
}
