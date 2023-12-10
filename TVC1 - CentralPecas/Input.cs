using CSharpFunctionalExtensions;

namespace CentralPecas;

/// <summary>
/// Estrutura que contém as variáveis de entrada do sistema
/// </summary>
public sealed record class Input(double TempoMedioEspera, double FatorUtilizacao, double NumeroFuncionarios)
{
    public static Result<Input> CriarLendoTeclado()
    {
        Result<double> resultadoTempoMedioEspera = ObterVariavelEntrada("tempo médio de espera");
        if (resultadoTempoMedioEspera.IsFailure)
            return resultadoTempoMedioEspera.ConvertFailure<Input>();

        Result<double> resultadoFatorUtilizacao = ObterVariavelEntrada("fator de utilização");
        if (resultadoFatorUtilizacao.IsFailure)
            return resultadoFatorUtilizacao.ConvertFailure<Input>();

        Result<double> resultadoNumeroFuncionarios = ObterVariavelEntrada("número de funcionários");
        if (resultadoNumeroFuncionarios.IsFailure)
            return resultadoNumeroFuncionarios.ConvertFailure<Input>();

        return new Input(resultadoTempoMedioEspera.Value, resultadoFatorUtilizacao.Value, resultadoNumeroFuncionarios.Value);
    }

    private static Result<double> ObterVariavelEntrada(string nomeVariavel)
    {
        Console.WriteLine($"Insira o {nomeVariavel} normalizado:");
        return Validar(nomeVariavel, Console.ReadLine());
    }

    private static Result<double> Validar(string nomeParametro, string valorParametro)
    {
        if (!double.TryParse(valorParametro, out double parsed))
            return Result.Failure<double>($"O parâmetro '{nomeParametro}' deve ser um número. Valor inserido: '{valorParametro}'");

        if (parsed < 0 || parsed > 1)
            return Result.Failure<double>($"O parâmetro '{nomeParametro}' deve ser um número entre 0 e 1, separando decimais com vírgula. Valor inserido: '{valorParametro}'");

        return parsed;
    }
}
