using FLS;
using FLS.Rules;

namespace CalculadoraFuzzyTempoLavagem.Deffuzificacao;

public static class Defuzzificador
{
    public static double Defuzzificar(Input input, IEnumerable<FuzzyRule> regras, Metodo metodo)
    {
        FuzzyEngine fuzzyEngine = new(metodo.Defuzzificacao);
        regras.ForEach(regra => fuzzyEngine.Rules.Add(regra));

        return fuzzyEngine.Defuzzify(input);
    }
}
