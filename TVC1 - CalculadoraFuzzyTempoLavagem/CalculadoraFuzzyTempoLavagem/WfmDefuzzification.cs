using FLS;
using FLS.MembershipFunctions;

namespace CalculadoraFuzzyTempoLavagem;

/// <summary>
/// Defuzzificação por média ponderada, ou Weighted Fuzzy Mean (WFM).
/// </summary>
public class WfmDefuzzification : IDefuzzification
{
    public double Defuzzify(List<IMembershipFunction> functions)
        => functions.Sum(f => f.Max() * f.PremiseModifier) / functions.Sum(f => f.PremiseModifier);
}
