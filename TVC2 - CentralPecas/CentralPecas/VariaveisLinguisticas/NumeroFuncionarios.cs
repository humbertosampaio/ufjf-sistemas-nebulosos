using FLS;
using FLS.MembershipFunctions;

namespace CentralPecas.VariaveisLinguisticas;

public class NumeroFuncionarios : LinguisticVariable
{
    public static readonly NumeroFuncionarios Instancia = new();

    public NumeroFuncionarios() : base(nameof(NumeroFuncionarios))
    {
        Pequeno = MembershipFunctions.AddTrapezoid("P", 0.0, 0.0, 0.4, 0.6);
        Medio = MembershipFunctions.AddTriangle("M", 0.4, 0.6, 0.8);
        Grande = MembershipFunctions.AddTrapezoid("G", 0.6, 0.8, 1.0, 1.0);
    }

    public IMembershipFunction Pequeno { get; }
    public IMembershipFunction Medio { get; }
    public IMembershipFunction Grande { get; }
}
