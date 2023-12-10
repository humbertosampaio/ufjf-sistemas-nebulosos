using FLS;
using FLS.MembershipFunctions;

namespace CentralPecas.VariaveisLinguisticas;

public sealed class FatorUtilizacao : LinguisticVariable
{
    public static readonly FatorUtilizacao Instancia = new();

    public FatorUtilizacao() : base(nameof(FatorUtilizacao))
    {
        Baixo = MembershipFunctions.AddTrapezoid("B", 0.0, 0.0, 0.2, 0.4);
        Medio = MembershipFunctions.AddTriangle("M", 0.3, 0.5, 0.7);
        Alto = MembershipFunctions.AddTrapezoid("A", 0.6, 0.8, 1.0, 1.0);
    }

    public IMembershipFunction Baixo { get; }
    public IMembershipFunction Medio { get; }
    public IMembershipFunction Alto { get; }
}
