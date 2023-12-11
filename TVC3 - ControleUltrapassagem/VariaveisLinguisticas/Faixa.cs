using FLS;
using FLS.MembershipFunctions;

namespace ControleUltrapassagem.VaariaveisLinguisticas;

internal sealed class Faixa : LinguisticVariable
{
    public static readonly Faixa Instancia = new();

    public Faixa() : base(nameof(Faixa))
    {
        Continua = MembershipFunctions.AddTrapezoid(nameof(Continua), 0D, 0D, 0.95, 1D);
        NaoContinua = MembershipFunctions.AddTriangle(nameof(NaoContinua), 0.95, 1D, 1D);
    }

    public IMembershipFunction Continua { get; }
    public IMembershipFunction NaoContinua { get; }
}
