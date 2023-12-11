using FLS;
using FLS.MembershipFunctions;

namespace ControleUltrapassagem.VaariaveisLinguisticas;

internal sealed class VelocidadeRelativa : LinguisticVariable
{
    public static readonly VelocidadeRelativa Instancia = new();

    public VelocidadeRelativa() : base(nameof(VelocidadeRelativa))
    {
        Negativa = MembershipFunctions.AddRectangle(nameof(Negativa), 0D, 0D);
        Baixa = MembershipFunctions.AddTrapezoid(nameof(Baixa), 0D, 0D, 20D, 50D);
        Media = MembershipFunctions.AddTrapezoid(nameof(Media), 30D, 50D, 80D, 100D);
        Alta = MembershipFunctions.AddTriangle(nameof(Alta), 80D, double.PositiveInfinity, double.PositiveInfinity);
    }

    public IMembershipFunction Negativa { get; }
    public IMembershipFunction Baixa { get; }
    public IMembershipFunction Media { get; }
    public IMembershipFunction Alta { get; }
}
