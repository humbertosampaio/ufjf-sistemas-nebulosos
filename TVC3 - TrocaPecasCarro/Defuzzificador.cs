using FLS;

namespace TrocaPecasCarros;

public class Defuzzificador
{
	private readonly FuzzyEngine _fuzzyEngine;

	public Defuzzificador(Regras regras, IDefuzzification defuzzificacao = null)
	{
		_fuzzyEngine = new(defuzzificacao ?? new CoGDefuzzification());
		regras.ForEach(regra => _fuzzyEngine.Rules.Add(regra));
	}

	public double Defuzzificar(Input input) => _fuzzyEngine.Defuzzify(input);
}
