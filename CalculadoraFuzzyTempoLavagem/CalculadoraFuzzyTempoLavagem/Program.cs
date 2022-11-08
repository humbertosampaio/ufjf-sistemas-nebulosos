using CalculadoraFuzzyTempoLavagem;
using FLS;
using FLS.MembershipFunctions;
using FLS.Rules;

{
	// Valores de entrada utilizados para teste
	Input input = new(Sujeira: 10, Mancha: 5);

	// Variáveis linguísticas
	LinguisticVariable sujeira = new("Sujeira");
	LinguisticVariable mancha = new("Mancha");
	LinguisticVariable tempo = new("Tempo");

	// Cria um dicionário de regras, mapeando da tupla (sujeira x mancha) para o tempo
	Dictionary<(IMembershipFunction, IMembershipFunction), IMembershipFunction> dicionarioRegras
		= ObterDicionarioRegras(sujeira, mancha, tempo);

	// Converte o dicionário na estrutura de dados utilizada pela biblioteca
	List<FuzzyRule> regras = MapearRegras(sujeira, mancha, tempo, dicionarioRegras);
	ObterResultadoPorCentroDeGravidade(regras, input);
	ObterResultadoPorMediaPonderada(regras, input);
}

// Métodos auxiliares para o teste

static Dictionary<(IMembershipFunction, IMembershipFunction), IMembershipFunction> ObterDicionarioRegras(
	LinguisticVariable sujeira, LinguisticVariable mancha, LinguisticVariable tempo)
{
	IMembershipFunction pequenoGrauSujeira = sujeira.MembershipFunctions.AddTriangle("PS", 0, 0, 50);
	IMembershipFunction medioGrauSujeira = sujeira.MembershipFunctions.AddTriangle("MS", 0, 50, 100);
	IMembershipFunction grandeGrauSujeira = sujeira.MembershipFunctions.AddTriangle("GS", 50, 100, 100);

	IMembershipFunction semMancha = mancha.MembershipFunctions.AddTriangle("SM", 0, 0, 50);
	IMembershipFunction mediaQuantidadeManchas = mancha.MembershipFunctions.AddTriangle("MM", 0, 50, 100);
	IMembershipFunction grandeQuantidadeManchas = mancha.MembershipFunctions.AddTriangle("GM", 50, 100, 100);

	IMembershipFunction tempoMuitoCurto = tempo.MembershipFunctions.AddTriangle("MC", 0, 0, 10);
	IMembershipFunction tempoCurto = tempo.MembershipFunctions.AddTriangle("C", 0, 10, 25);
	IMembershipFunction tempoMedio = tempo.MembershipFunctions.AddTriangle("M", 10, 25, 40);
	IMembershipFunction tempoLongo = tempo.MembershipFunctions.AddTriangle("L", 25, 40, 60);
	IMembershipFunction tempoMuitoLongo = tempo.MembershipFunctions.AddTriangle("ML", 40, 60, 60);

	return new()
	{
		{ (pequenoGrauSujeira, semMancha), tempoMuitoCurto },
		{ (pequenoGrauSujeira, mediaQuantidadeManchas), tempoMedio },
		{ (pequenoGrauSujeira, grandeQuantidadeManchas), tempoLongo },
		{ (medioGrauSujeira, semMancha), tempoCurto },
		{ (medioGrauSujeira, mediaQuantidadeManchas), tempoMedio },
		{ (medioGrauSujeira, grandeQuantidadeManchas),tempoLongo  },
		{ (grandeGrauSujeira, semMancha), tempoMedio },
		{ (grandeGrauSujeira, mediaQuantidadeManchas), tempoLongo },
		{ (grandeGrauSujeira, grandeQuantidadeManchas), tempoMuitoLongo }
	};
}

static List<FuzzyRule> MapearRegras(LinguisticVariable sujeira, LinguisticVariable mancha, LinguisticVariable tempo, Dictionary<(IMembershipFunction, IMembershipFunction), IMembershipFunction> dicionarioRegras)
{
	return dicionarioRegras
		.Select(item => Rule
			.If(sujeira.Is(item.Key.Item1).And(mancha.Is(item.Key.Item2)))
			.Then(tempo.Is(item.Value)))
		.ToList();
}

static void ObterResultadoPorCentroDeGravidade(List<FuzzyRule> regras, Input input)
	=> ObterResultado(regras, new CoGDefuzzification(), input);

static void ObterResultadoPorMediaPonderada(List<FuzzyRule> regras, Input input)
	=> ObterResultado(regras, new WfmDefuzzification(), input);

static void ObterResultado(List<FuzzyRule> regras, IDefuzzification defuzzificacao, Input input)
{
	FuzzyEngine fuzzyEngine = new(defuzzificacao);
	regras.ForEach(regra => fuzzyEngine.Rules.Add(regra));

	double result = fuzzyEngine.Defuzzify(input);
	Console.WriteLine($"Tempo estimado utilizando {defuzzificacao.GetType().Name}: {result:0.##}m");
}