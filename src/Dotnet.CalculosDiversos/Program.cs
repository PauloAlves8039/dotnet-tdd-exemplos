using Dotnet.CalculosDiversos.Utils;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** Calculos **********");

        var calculadora = new Calculadora();

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Calcular média de três números");
            Console.WriteLine("2 - Calcular fatorial de um número");
            Console.WriteLine("3 - Calcular soma dos dígitos de um número");
            Console.WriteLine("4 - Verificar se um número é primo");
            Console.WriteLine("5 - Sair");

            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o primeiro número: ");
                    double numero1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Digite o segundo número: ");
                    double numero2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Digite o terceiro número: ");
                    double numero3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    double media = calculadora.CalcularMediaDeNumeros(numero1, numero2, numero3);
                    Console.WriteLine($"A média é: {media.ToString("F2", CultureInfo.InvariantCulture)}");
                    break;
                case "2":
                    Console.Write("Digite o número para calcular o fatorial: ");
                    int numeroFatorial = int.Parse(Console.ReadLine());
                    int fatorial = calculadora.CalcularFatorialDeNumero(numeroFatorial);
                    Console.WriteLine($"O fatorial de {numeroFatorial} é: {fatorial}");
                    break;
                case "3":
                    Console.Write("Digite um número para calcular a soma dos dígitos: ");
                    int digitos = int.Parse(Console.ReadLine());
                    int somaDosDigitos = calculadora.CalcularSomaDosDigitos(digitos);
                    Console.WriteLine($"A soma dos dígitos de {digitos} é: {somaDosDigitos}");
                    break;
                case "4":
                    Console.Write("Digite o número para verificar se é primo: ");
                    int numeroPrimo = int.Parse(Console.ReadLine());
                    bool primo = calculadora.VerificarNumeroPrimo(numeroPrimo);
                    Console.WriteLine($"O número {numeroPrimo} é primo: {primo}");
                    break;
                case "5":
                    Console.WriteLine("Encerrando o programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }
}