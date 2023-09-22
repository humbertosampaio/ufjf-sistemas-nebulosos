namespace CalculadoraFuzzyTempoLavagem;

/// <summary>
/// Estrutura que contém as variáveis de entrada do sistema
/// </summary>
public record class Input
{
    public Input()
    {
        (string sujeira, string mancha) = LerTeclado();
        (decimal sujeiraParsed, decimal manchaParsed) = Validar(sujeira, mancha);

        Sujeira = sujeiraParsed;
        Mancha = manchaParsed;
    }

    private static (string, string) LerTeclado()
    {
        Console.WriteLine("Insira o nível de sujeira: ");
        string sujeira = Console.ReadLine();

        Console.WriteLine("Insira o nível de mancha: ");
        string mancha = Console.ReadLine();

        return (sujeira, mancha);
    }

    private static (decimal, decimal) Validar(string sujeira, string mancha)
    {
        if (!decimal.TryParse(sujeira, out decimal sujeiraParsed))
            throw new ArgumentException("O grau de sujeira deve ser um número válido", nameof(sujeira));

        if (sujeiraParsed is < 0 or > 100)
            throw new ArgumentException("O grau de sujeira deve estar entre 0 e 100", nameof(sujeira));

        if (!decimal.TryParse(mancha, out decimal manchaParsed))
            throw new ArgumentException("O grau de mancha deve ser um número válido", nameof(mancha));

        if (manchaParsed is < 0 || manchaParsed > 100)
            throw new ArgumentException("O grau de mancha deve estar entre 0 e 100", nameof(mancha));

        return (sujeiraParsed, manchaParsed);
    }

    public decimal Sujeira { get; }
    public decimal Mancha { get; }
}