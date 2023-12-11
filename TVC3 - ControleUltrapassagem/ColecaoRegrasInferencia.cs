using ControleUltrapassagem.VaariaveisLinguisticas;
using FLS;
using FLS.MembershipFunctions;
using FLS.Rules;

namespace ControleUltrapassagem;

public static class ColecaoRegrasInferencia
{
    private static readonly Distancia Distancia = Distancia.Instancia;
    private static readonly DistanciaPistaContraria DistanciaPistaContraria = DistanciaPistaContraria.Instancia;
    private static readonly Faixa Faixa = Faixa.Instancia;
    private static readonly QualidadePista QualidadePista = QualidadePista.Instancia;
    private static readonly VelocidadeRelativa VelocidadeRelativa = VelocidadeRelativa.Instancia;
    private static readonly Ultrapassar Ultrapassar = Ultrapassar.Instancia;

    private static readonly FuzzyRule _regraImpossibilidade = Rule
        .If(Faixa.Is(Faixa.Continua)
            .Or(QualidadePista.Is(QualidadePista.Ruim))
            .Or(VelocidadeRelativa.Is(VelocidadeRelativa.Negativa))
            .Or(DistanciaPistaContraria.Is(DistanciaPistaContraria.Baixa)))
        .Then(Ultrapassar.Is(Ultrapassar.Nao));

    private static readonly RegraInferencia[] _demaisRegras =
    [
        new(Distancia.Alta, DistanciaPistaContraria.Media, QualidadePista.Mediana, VelocidadeRelativa.Baixa, Ultrapassar.Nao),
        new(Distancia.Alta, DistanciaPistaContraria.Media, QualidadePista.Mediana, VelocidadeRelativa.Media, Ultrapassar.Nao),
        new(Distancia.Alta, DistanciaPistaContraria.Media, QualidadePista.Mediana, VelocidadeRelativa.Alta, Ultrapassar.Nao),

        new(Distancia.Alta, DistanciaPistaContraria.Media, QualidadePista.Boa, VelocidadeRelativa.Baixa, Ultrapassar.Nao),
        new(Distancia.Alta, DistanciaPistaContraria.Media, QualidadePista.Boa, VelocidadeRelativa.Media, Ultrapassar.Nao),
        new(Distancia.Alta, DistanciaPistaContraria.Media, QualidadePista.Boa, VelocidadeRelativa.Alta, Ultrapassar.Sim),

        new(Distancia.Alta, DistanciaPistaContraria.Alta, QualidadePista.Mediana, VelocidadeRelativa.Baixa, Ultrapassar.Nao),
        new(Distancia.Alta, DistanciaPistaContraria.Alta, QualidadePista.Mediana, VelocidadeRelativa.Media, Ultrapassar.Nao),
        new(Distancia.Alta, DistanciaPistaContraria.Alta, QualidadePista.Mediana, VelocidadeRelativa.Alta, Ultrapassar.Sim),

        new(Distancia.Alta, DistanciaPistaContraria.Alta, QualidadePista.Boa, VelocidadeRelativa.Baixa, Ultrapassar.Nao),
        new(Distancia.Alta, DistanciaPistaContraria.Alta, QualidadePista.Boa, VelocidadeRelativa.Media, Ultrapassar.Sim),
        new(Distancia.Alta, DistanciaPistaContraria.Alta, QualidadePista.Boa, VelocidadeRelativa.Alta, Ultrapassar.Sim),


        new(Distancia.Baixa, DistanciaPistaContraria.Media, QualidadePista.Mediana, VelocidadeRelativa.Baixa, Ultrapassar.Nao),
        new(Distancia.Baixa, DistanciaPistaContraria.Media, QualidadePista.Mediana, VelocidadeRelativa.Media, Ultrapassar.Nao),
        new(Distancia.Baixa, DistanciaPistaContraria.Media, QualidadePista.Mediana, VelocidadeRelativa.Alta, Ultrapassar.Sim),

        new(Distancia.Baixa, DistanciaPistaContraria.Media, QualidadePista.Boa, VelocidadeRelativa.Baixa, Ultrapassar.Nao),
        new(Distancia.Baixa, DistanciaPistaContraria.Media, QualidadePista.Boa, VelocidadeRelativa.Media, Ultrapassar.Sim),
        new(Distancia.Baixa, DistanciaPistaContraria.Media, QualidadePista.Boa, VelocidadeRelativa.Alta, Ultrapassar.Sim),

        new(Distancia.Baixa, DistanciaPistaContraria.Alta, QualidadePista.Mediana, VelocidadeRelativa.Baixa, Ultrapassar.Nao),
        new(Distancia.Baixa, DistanciaPistaContraria.Alta, QualidadePista.Mediana, VelocidadeRelativa.Media, Ultrapassar.Sim),
        new(Distancia.Baixa, DistanciaPistaContraria.Alta, QualidadePista.Mediana, VelocidadeRelativa.Alta, Ultrapassar.Sim),

        new(Distancia.Baixa, DistanciaPistaContraria.Alta, QualidadePista.Boa, VelocidadeRelativa.Baixa, Ultrapassar.Sim),
        new(Distancia.Baixa, DistanciaPistaContraria.Alta, QualidadePista.Boa, VelocidadeRelativa.Media, Ultrapassar.Sim),
        new(Distancia.Baixa, DistanciaPistaContraria.Alta, QualidadePista.Boa, VelocidadeRelativa.Alta, Ultrapassar.Sim),
    ];

    public static readonly IReadOnlyList<FuzzyRule> Regras = _demaisRegras
        .Select(regraInferencia => Rule
            .If(Distancia.Is(regraInferencia.Distancia)
                .And(DistanciaPistaContraria.Is(regraInferencia.DistanciaPistaContraria))
                .And(QualidadePista.Is(regraInferencia.QualidadePista))
                .And(VelocidadeRelativa.Is(regraInferencia.VelocidadeRelativa)))
            .Then(Ultrapassar.Is(regraInferencia.Ultrapassar)))
        .Concat([_regraImpossibilidade])
        .ToArray();

    private sealed record class RegraInferencia(
        IMembershipFunction Distancia,
        IMembershipFunction DistanciaPistaContraria,
        IMembershipFunction QualidadePista,
        IMembershipFunction VelocidadeRelativa,
        IMembershipFunction Ultrapassar);
}
