using Dotnet.FormasGeometricas.Utils;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** Formas Geométricas **********");

        Console.WriteLine("\nDigite os dados do Retângulo: ");

        Console.Write("Largura: ");
        double largura = double.Parse(Console.ReadLine());

        Console.Write("Altura: ");
        double altura = double.Parse(Console.ReadLine());

        Console.WriteLine("\nDigite os dado(s) do Círculo: ");

        Console.Write("Raio: ");
        double raio = double.Parse(Console.ReadLine());

        var retangulo = new Retangulo(largura, altura);
        var circulo = new Circulo(raio);

        Console.WriteLine("---------- Resultado ----------");

        Console.WriteLine("Área e Perímetro do Retângulo:");
        Console.WriteLine($"Área: {retangulo.CalcularArea().ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Perímetro: {retangulo.CalcularPerimetro().ToString("F2", CultureInfo.InvariantCulture)}");

        Console.WriteLine("\nÁrea e Perímetro do Círculo:");
        Console.WriteLine($"Área: {circulo.CalcularArea().ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Perímetro: {circulo.CalcularPerimetro().ToString("F2", CultureInfo.InvariantCulture)}");

        Console.ReadKey();
    }
}