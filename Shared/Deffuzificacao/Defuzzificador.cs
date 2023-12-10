using FLS;
using FLS.Rules;
using System.Collections.Generic;

namespace Shared.Deffuzificacao;

public static class Defuzzificador
{
    public static double Defuzzificar(object input, IEnumerable<FuzzyRule> regras, Metodo metodo)
    {
        FuzzyEngine fuzzyEngine = new(metodo.Defuzzificacao);
        regras.ForEach(fuzzyEngine.Rules.Add);

        return fuzzyEngine.Defuzzify(input);
    }
}
