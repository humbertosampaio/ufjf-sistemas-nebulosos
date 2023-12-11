using FLS;
using FLS.MembershipFunctions;

namespace ControleUltrapassagem.VaariaveisLinguisticas;

internal sealed class Ultrapassar : LinguisticVariable
{
    internal static readonly Ultrapassar Instancia = new();

    public Ultrapassar() : base(nameof(Ultrapassar))
    {
        Nao = MembershipFunctions.AddTrapezoid(nameof(Nao), 0D, 0D, 0.6, 0.9);
        Sim = MembershipFunctions.AddTriangle(nameof(Sim), 0.8, 1D, 1D);
    }

    public IMembershipFunction Sim { get; }
    public IMembershipFunction Nao { get; }
}
