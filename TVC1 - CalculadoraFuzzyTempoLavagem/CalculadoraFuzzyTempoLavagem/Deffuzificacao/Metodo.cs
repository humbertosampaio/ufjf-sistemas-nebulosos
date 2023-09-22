using Ardalis.SmartEnum;
using FLS;

namespace CalculadoraFuzzyTempoLavagem.Deffuzificacao;

public sealed class Metodo : SmartEnum<Metodo>
{
    public static readonly Metodo CentroGravidade = new("Centro de gravidade", 1, new DefuzzificacaoCentroGravidade());
    public static readonly Metodo MediaPonderada = new("Média ponderada", 2, new DefuzzificacaoMediaPonderada());

    private Metodo(string name, int value, IDefuzzification defuzzificacao)
        : base(name, value)
    {
        Defuzzificacao = defuzzificacao;
    }

    public IDefuzzification Defuzzificacao { get; }
}
