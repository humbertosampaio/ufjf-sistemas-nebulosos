using TrocaPecasCarros;
using TrocaPecasCarros.Variaveis;

// Valores de entrada utilizados para teste
Input input = new(TempoMedioEspera: 0.0, NumeroEmpregados: 0.5);

// Variáveis linguísticas
VariaveisEntrada variaveisEntrada = new();
NumeroPecasExtras numeroPecasExtras = new();

// Elicitação das regras de inferência
Regras regras = new(variaveisEntrada, numeroPecasExtras);

// Defuzzificação
Defuzzificador defuzzificador = new(regras);
double resultado = defuzzificador.Defuzzificar(input);

Console.WriteLine($"Número de peças extras estimado: {resultado:0.000} (pode ser necessário ajustar a escala do valor final)");