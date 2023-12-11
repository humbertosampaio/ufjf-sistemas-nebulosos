using CSharpFunctionalExtensions;

namespace ControleUltrapassagem;

/// <summary>
/// Estrutura que contém as variáveis de entrada do sistema
/// </summary>
public sealed record class Input(
    double Distancia,
    double DistanciaPistaContraria,
    double Faixa,
    double QualidadePista,
    double VelocidadeRelativa)
{
    public static Result<Input> CriarLendoTeclado()
    {
        Result<double> resultadoDistancia = ObterVariavelEntrada("distância para o carro à frente");
        if (resultadoDistancia.IsFailure)
            return resultadoDistancia.ConvertFailure<Input>();

        Result<double> resultadoDistanciaPistaContraria = ObterVariavelEntrada("distância para o primeiro obstáculo na pista contrária");
        if (resultadoDistanciaPistaContraria.IsFailure)
            return resultadoDistanciaPistaContraria.ConvertFailure<Input>();

        Result<double> resultadoFaixa = ObterVariavelEntrada("faixa (0 para contínua ou 1 para não-contínua)");
        if (resultadoFaixa.IsFailure)
            return resultadoFaixa.ConvertFailure<Input>();

        Result<double> resultadoQualidadePista = ObterVariavelEntrada("qualidade da pista (0 para ruim ou 1 para boa)");
        if (resultadoQualidadePista.IsFailure)
            return resultadoQualidadePista.ConvertFailure<Input>();

        Result<double> resultadoVelocidadeRelativa = ObterVariavelEntrada("velocidade relativa ao carro à frente");
        if (resultadoVelocidadeRelativa.IsFailure)
            return resultadoVelocidadeRelativa.ConvertFailure<Input>();

        return new Input(
            resultadoDistancia.Value,
            resultadoDistanciaPistaContraria.Value,
            resultadoFaixa.Value,
            resultadoQualidadePista.Value,
            resultadoVelocidadeRelativa.Value);
    }

    private static Result<double> ObterVariavelEntrada(string nomeVariavel)
    {
        Console.WriteLine($"Insira a {nomeVariavel}:");
        return Validar(nomeVariavel, Console.ReadLine());
    }

    private static Result<double> Validar(string nomeParametro, string valorParametro)
    {
        if (!double.TryParse(valorParametro, out double parsed))
            return Result.Failure<double>($"O parâmetro '{nomeParametro}' deve ser um número. Valor inserido: '{valorParametro}'");

        return parsed;
    }
}
