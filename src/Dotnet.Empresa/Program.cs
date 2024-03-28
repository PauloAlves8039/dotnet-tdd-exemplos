using Dotnet.Empresa;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** Projeto Empresa **********");

        var funcionario1 = new Funcionario("Paulo", 1500.0, Cargo.DESENVOLVEDOR);
        var funcionario2 = new Funcionario("Pedro", 2500.0, Cargo.DBA);

        var calculadoraDeSalario = new CalculadoraDeSalario();

        var resultadoFuncionario1 = calculadoraDeSalario.CalcularSalario(funcionario1);
        var resultadoFuncionario2 = calculadoraDeSalario.CalcularSalario(funcionario2);

        Console.WriteLine();

        Console.WriteLine("---------- Resultados ----------");

        Console.WriteLine($"Nome do funcionário: {funcionario1.Nome}");
        Console.WriteLine($"Cargo: {Cargo.DESENVOLVEDOR}");
        Console.WriteLine($"Salário: {resultadoFuncionario1.ToString("F2")}");

        Console.WriteLine();

        Console.WriteLine($"Nome do funcionário: {funcionario2.Nome}");
        Console.WriteLine($"Cargo: {Cargo.DBA}");
        Console.WriteLine($"Salário: {resultadoFuncionario2.ToString("F2")}");

        Console.ReadKey();
    }
}