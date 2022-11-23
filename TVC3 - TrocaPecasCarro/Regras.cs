using FLS;
using FLS.MembershipFunctions;
using FLS.Rules;
using System.Collections;
using TrocaPecasCarros.Variaveis;

namespace TrocaPecasCarros;

public class Regras : IEnumerable<FuzzyRule>
{
	private readonly List<FuzzyRule> _regras;

	public Regras(VariaveisEntrada variaveisEntrada, NumeroPecasExtras numeroPecasExtras)
	{
		TempoMedioEspera tempoMedioEspera = variaveisEntrada.TempoMedioEspera;
		NumeroEmpregados numeroEmpregados = variaveisEntrada.NumeroEmpregados;

		Rule.If(tempoMedioEspera.Is(tempoMedioEspera.MuitoPequeno)
			.And(numeroEmpregados.Is(numeroEmpregados.Pequeno)))
			.Then(numeroPecasExtras.Is(numeroPecasExtras.MuitoGrande));

		Dictionary<(IMembershipFunction, IMembershipFunction), IMembershipFunction> dicionarioRegras = new()
		{
			{ (tempoMedioEspera.MuitoPequeno, numeroEmpregados.Pequeno), numeroPecasExtras.MuitoGrande },
			{ (tempoMedioEspera.MuitoPequeno, numeroEmpregados.Medio), numeroPecasExtras.PoucoGrande },
			{ (tempoMedioEspera.MuitoPequeno, numeroEmpregados.Grande), numeroPecasExtras.MuitoPequeno },
			{ (tempoMedioEspera.Pequeno, numeroEmpregados.Pequeno), numeroPecasExtras.Grande },
			{ (tempoMedioEspera.Pequeno, numeroEmpregados.Medio), numeroPecasExtras.PoucoPequeno },
			{ (tempoMedioEspera.Pequeno, numeroEmpregados.Grande), numeroPecasExtras.Pequeno },
			{ (tempoMedioEspera.Medio, numeroEmpregados.Pequeno), numeroPecasExtras.Medio },
			{ (tempoMedioEspera.Medio, numeroEmpregados.Medio), numeroPecasExtras.Pequeno },
			{ (tempoMedioEspera.Medio, numeroEmpregados.Grande), numeroPecasExtras.MuitoPequeno }
		};

		_regras = dicionarioRegras
			.Select(item => Rule
				.If(tempoMedioEspera.Is(item.Key.Item1).And(numeroEmpregados.Is(item.Key.Item2)))
				.Then(numeroPecasExtras.Is(item.Value)))
			.ToList();
	}

	public IEnumerator<FuzzyRule> GetEnumerator() => _regras.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => _regras.GetEnumerator();
}