using CentralPecas;
using CentralPecas.Deffuzificacao;

Input input = Input.CriarLendoTeclado();

IReadOnlyCollection<Metodo> todosMetodos = Metodo.List;
foreach (Metodo metodo in todosMetodos)
{
    Console.WriteLine();
    Console.WriteLine($"### Execução para o método {metodo} ###");

    double resultado = Defuzzificador.Defuzzificar(input, ColecaoRegrasInferencia.Regras, metodo);

    Console.WriteLine($"Número de peças extras (normalizado) estimado utilizando {metodo}: {resultado:0.##}");
}