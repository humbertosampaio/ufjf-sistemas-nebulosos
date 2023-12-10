using FLS;
using FLS.MembershipFunctions;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Deffuzificacao;

/// <summary>
/// Defuzzificação por média ponderada, ou Weighted Fuzzy Mean (WFM).
/// </summary>
public class DefuzzificacaoMediaPonderada : IDefuzzification
{
    public double Defuzzify(List<IMembershipFunction> functions)
        => functions.Sum(f => f.Max() * f.PremiseModifier) / functions.Sum(f => f.PremiseModifier);
}
