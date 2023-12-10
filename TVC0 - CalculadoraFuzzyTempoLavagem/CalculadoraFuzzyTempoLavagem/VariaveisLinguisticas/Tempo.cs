using FLS;
using FLS.MembershipFunctions;

namespace CalculadoraFuzzyTempoLavagem;

public class Tempo : LinguisticVariable
{
    public Tempo() : base("Tempo")
    {
        MC = MembershipFunctions.AddTriangle("MC", 0, 0, 10);
        C = MembershipFunctions.AddTriangle("C", 0, 10, 25);
        M = MembershipFunctions.AddTriangle("M", 10, 25, 40);
        L = MembershipFunctions.AddTriangle("L", 25, 40, 60);
        ML = MembershipFunctions.AddTriangle("ML", 40, 60, 60);
    }

    /// <summary>
    /// Muito curto
    /// </summary>
    public IMembershipFunction MC { get; }

    /// <summary>
    /// Curto
    /// </summary>
    public IMembershipFunction C { get; }

    /// <summary>
    /// Médio
    /// </summary>
    public IMembershipFunction M { get; }

    /// <summary>
    /// Longo
    /// </summary>
    public IMembershipFunction L { get; }

    /// <summary>
    /// Muito longo
    /// </summary>
    public IMembershipFunction ML { get; }
}
