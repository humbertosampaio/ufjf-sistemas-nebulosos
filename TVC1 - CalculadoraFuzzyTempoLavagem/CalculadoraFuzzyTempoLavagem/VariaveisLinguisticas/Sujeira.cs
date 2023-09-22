using FLS;
using FLS.MembershipFunctions;

namespace CalculadoraFuzzyTempoLavagem;

public class Sujeira : LinguisticVariable
{
    public Sujeira() : base("Sujeira")
    {
        PS = MembershipFunctions.AddTriangle("PS", 0, 0, 50);
        MS = MembershipFunctions.AddTriangle("MS", 0, 50, 100);
        GS = MembershipFunctions.AddTriangle("GS", 50, 100, 100);
    }

    /// <summary>
    /// Pequeno grau de sujeira
    /// </summary>
    public IMembershipFunction PS { get; }

    /// <summary>
    /// Médio grau de sujeira
    /// </summary>
    public IMembershipFunction MS { get; }

    /// <summary>
    /// Grande grau de sujeira
    /// </summary>
    public IMembershipFunction GS { get; }
}
