using CalculadoraFuzzyTempoLavagem;
using Shared.Deffuzificacao;

Input input = new();

Metodo[] metodos = [Metodo.CentroGravidade, Metodo.MediaPonderada];

foreach (Metodo metodo in metodos)
{
    double resultado = Defuzzificador.Defuzzificar(input, ColecaoRegrasInferencia.Regras, metodo);
    Console.WriteLine($"Tempo estimado utilizando {metodo}: {resultado:0.##} min");
}
