using FLS;
using FLS.MembershipFunctions;

namespace CentralPecas.VariaveisLinguisticas;

public class NumeroPecasExtras : LinguisticVariable
{
    public static readonly NumeroPecasExtras Instancia = new();

    public NumeroPecasExtras() : base(nameof(NumeroPecasExtras))
    {
        MuitoPequeno = MembershipFunctions.AddTrapezoid("MP", 0.0, 0.0, 0.1, 0.3);
        Pequeno = MembershipFunctions.AddTriangle("P", 0.0, 0.2, 0.4);
        PoucoPequeno = MembershipFunctions.AddTriangle("PP", 0.25, 0.35, 0.45);
        Medio = MembershipFunctions.AddTriangle("M", 0.3, 0.5, 0.7);
        PoucoGrande = MembershipFunctions.AddTriangle("PG", 0.55, 0.65, 0.75);
        Grande = MembershipFunctions.AddTriangle("G", 0.6, 0.8, 1.0);
        MuitoGrande = MembershipFunctions.AddTrapezoid("MG", 0.7, 0.9, 1.0, 1.0);
    }

    public IMembershipFunction MuitoPequeno { get; }
    public IMembershipFunction Pequeno { get; }
    public IMembershipFunction PoucoPequeno { get; }
    public IMembershipFunction Medio { get; }
    public IMembershipFunction PoucoGrande { get; }
    public IMembershipFunction Grande { get; }
    public IMembershipFunction MuitoGrande { get; }
}
