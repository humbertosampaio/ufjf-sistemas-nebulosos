namespace TrocaPecasCarros.Variaveis;

public class VariaveisEntrada
{
	public VariaveisEntrada()
	{
		TempoMedioEspera = new TempoMedioEspera();
		NumeroEmpregados = new NumeroEmpregados();
	}

	public TempoMedioEspera TempoMedioEspera { get; }
	public NumeroEmpregados NumeroEmpregados { get; }
}
