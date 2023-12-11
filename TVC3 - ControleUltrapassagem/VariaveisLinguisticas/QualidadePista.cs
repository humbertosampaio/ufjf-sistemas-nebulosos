using FLS;
using FLS.MembershipFunctions;

namespace ControleUltrapassagem.VaariaveisLinguisticas;

internal sealed class QualidadePista : LinguisticVariable
{
    public static readonly QualidadePista Instancia = new();

    public QualidadePista() : base(nameof(QualidadePista))
    {
        Ruim = MembershipFunctions.AddTrapezoid(nameof(Ruim), 0D, 0D, 0.3, 0.5);
        Mediana = MembershipFunctions.AddTrapezoid(nameof(Mediana), 0D, 0.3, 0.6, 0.8);
        Boa = MembershipFunctions.AddTriangle(nameof(Boa), 0.7, 1D, 1D);
    }

    public IMembershipFunction Ruim { get; }
    public IMembershipFunction Mediana { get; }
    public IMembershipFunction Boa { get; }
}
