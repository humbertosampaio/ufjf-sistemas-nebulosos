using CalculadoraFuzzyTempoLavagem;
using CalculadoraFuzzyTempoLavagem.Deffuzificacao;

Input input = new();

Metodo[] metodos = new[] { Metodo.CentroGravidade, Metodo.MediaPonderada };

foreach (Metodo metodo in metodos)
{
    double resultado = Defuzzificador.Defuzzificar(input, ColecaoRegrasInferencia.Regras, metodo);
    Console.WriteLine($"Tempo estimado utilizando {metodo}: {resultado:0.##} min");
}
