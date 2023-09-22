using FLS;
using FLS.MembershipFunctions;

namespace CalculadoraFuzzyTempoLavagem;

public class Mancha : LinguisticVariable
{
    public Mancha() : base("Mancha")
    {
        SM = MembershipFunctions.AddTriangle("SM", 0, 0, 50);
        MM = MembershipFunctions.AddTriangle("MM", 0, 50, 100);
        GM = MembershipFunctions.AddTriangle("GM", 50, 100, 100);
    }

    /// <summary>
    /// Sem manchas
    /// </summary>
    public IMembershipFunction SM { get; }

    /// <summary>
    /// Média quantidade de manchas
    /// </summary>
    public IMembershipFunction MM { get; }

    /// <summary>
    /// Grande grau de manchas
    /// </summary>
    public IMembershipFunction GM { get; }
}
