namespace CentralPecas;

/// <summary>
/// Estrutura que contém as variáveis de entrada do sistema
/// </summary>
public sealed record class Input(double TempoMedioEspera, double FatorUtilizacao, double NumeroFuncionarios)
{
    public static Input CriarLendoTeclado()
    {
        Console.WriteLine("Insira o tempo médio de espera normalizado:");
        double tempoMedioEspera = Validar("tempo médio de espera", Console.ReadLine());

        Console.WriteLine("Insira o fator de utilização normalizado:");
        double fatorUtilizacao = Validar("fator de utilização", Console.ReadLine());

        Console.WriteLine("Insira o número de funcionários normalizado:");
        double numeroFuncionarios = Validar("número de funcionários", Console.ReadLine());

        return new(tempoMedioEspera, fatorUtilizacao, numeroFuncionarios);
    }

    private static double Validar(string nomeParametro, string valorParametro)
    {
        if (!double.TryParse(valorParametro, out double parsed))
            throw new ArgumentException($"O parâmetro '{nomeParametro}' deve ser um número. Valor inserido: '{valorParametro}'");

        if (parsed < 0 || parsed > 1)
            throw new ArgumentException($"O parâmetro '{nomeParametro}' deve ser um número entre 0 e 1. Valor inserido: '{valorParametro}'");

        return parsed;
    }
}
