using FLS;
using FLS.MembershipFunctions;

namespace ControleUltrapassagem.VaariaveisLinguisticas;

internal sealed class Distancia : LinguisticVariable
{
    public static readonly Distancia Instancia = new();

    public Distancia() : base(nameof(Distancia))
    {
        Baixa = MembershipFunctions.AddTriangle(nameof(Baixa), 0.0, 0.0, 4.0);
        Alta = MembershipFunctions.AddTriangle(nameof(Alta), 4.0, 10.0, 10.0);
    }

    public IMembershipFunction Baixa { get; }
    public IMembershipFunction Alta { get; }
}
