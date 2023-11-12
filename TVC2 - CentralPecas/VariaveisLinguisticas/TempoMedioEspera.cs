using FLS;
using FLS.MembershipFunctions;

namespace CentralPecas.VariaveisLinguisticas;

public sealed class TempoMedioEspera : LinguisticVariable
{
    public static readonly TempoMedioEspera Instancia = new();

    public TempoMedioEspera() : base(nameof(TempoMedioEspera))
    {
        MuitoPequeno = MembershipFunctions.AddTrapezoid("MP", 0.0, 0.0, 0.1, 0.3);
        Pequeno = MembershipFunctions.AddTriangle("P", 0.1, 0.3, 0.5);
        Medio = MembershipFunctions.AddTrapezoid("M", 0.4, 0.6, 0.7, 0.7);
    }

    public IMembershipFunction MuitoPequeno { get; }
    public IMembershipFunction Pequeno { get; }
    public IMembershipFunction Medio { get; }
}
