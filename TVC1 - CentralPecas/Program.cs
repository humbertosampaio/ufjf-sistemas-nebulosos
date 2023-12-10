using CentralPecas;
using CSharpFunctionalExtensions;
using Shared.Deffuzificacao;

Result<Input> resultadoInput = Input.CriarLendoTeclado();
if (resultadoInput.IsFailure)
{
    Console.WriteLine(resultadoInput.Error);
    return;
}

Input input = resultadoInput.Value;
IReadOnlyCollection<Metodo> todosMetodos = Metodo.List;
foreach (Metodo metodo in todosMetodos)
{
    Console.WriteLine();
    Console.WriteLine($"### Execução para o método {metodo} ###");

    double resultado = Defuzzificador.Defuzzificar(input, ColecaoRegrasInferencia.Regras, metodo);

    Console.WriteLine($"Número de peças extras (normalizado) estimado utilizando {metodo}: {resultado:0.##}");
}