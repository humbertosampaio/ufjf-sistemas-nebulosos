using FLS;
using FLS.MembershipFunctions;

namespace ControleUltrapassagem.VaariaveisLinguisticas;

internal sealed class DistanciaPistaContraria : LinguisticVariable
{
    internal static readonly DistanciaPistaContraria Instancia = new();

    public DistanciaPistaContraria() : base(nameof(DistanciaPistaContraria))
    {
        Baixa = MembershipFunctions.AddTriangle(nameof(Baixa), 0D, 0D, 60D);
        Media = MembershipFunctions.AddTrapezoid(nameof(Media), 50D, 70D, 80D, 90D);
        Alta = MembershipFunctions.AddTrapezoid(nameof(Alta), 80D, 100D, double.PositiveInfinity, double.PositiveInfinity);
    }

    public IMembershipFunction Baixa { get; }
    public IMembershipFunction Media { get; }
    public IMembershipFunction Alta { get; }
}
