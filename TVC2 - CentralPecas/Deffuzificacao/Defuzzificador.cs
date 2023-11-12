using FLS;
using FLS.Rules;

namespace CentralPecas.Deffuzificacao;

public static class Defuzzificador
{
    public static double Defuzzificar(Input input, IEnumerable<FuzzyRule> regras, Metodo metodo)
    {
        FuzzyEngine fuzzyEngine = new(metodo.Defuzzificacao);
        regras.ForEach(fuzzyEngine.Rules.Add);

        return fuzzyEngine.Defuzzify(input);
    }
}
