using Dotnet.NumerosRomanos;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** Conversor de Número Romano **********");

        var numeroRomano = new ConversorDeNumeroRomano();
        var valorRecebido = "III";

        var resultado = numeroRomano.ConverteNumero(valorRecebido);

        Console.WriteLine($"O valor '{valorRecebido}' foi convertido para o número: {resultado}");

        Console.ReadKey();
    }
}