using Dotnet.ContaBancaria.Utils;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** Conta Bancária **********");

        Console.WriteLine("\nDigite as operações para a Conta Corrente: ");

        Console.Write("Valor do depósito: ");
        double depositoContaCorrente = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Valor do saque: ");
        double saqueContaCorrente = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine("\nDigite as operações para a Conta Poupança: ");

        Console.Write("Valor do depósito: ");
        double depositoContaPoupanca = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Valor do saque: ");
        double saqueContaPoupanca = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        ContaCorrente contaCorrente = new ContaCorrente(1000);
        ContaPoupanca contaPoupanca = new ContaPoupanca(1000);

        Console.WriteLine("\n---------- Resultado Conta Corrente ----------");

        Console.WriteLine("\nSaldo Inicial da Conta Corrente: " + contaCorrente.Saldo.ToString("F2", CultureInfo.InvariantCulture));
        contaCorrente.Depositar(depositoContaCorrente);
        Console.WriteLine("Saldo após depósito na Conta Corrente: " + contaCorrente.Saldo.ToString("F2", CultureInfo.InvariantCulture));
        contaCorrente.Sacar(saqueContaCorrente);
        Console.WriteLine("Saldo após saque na Conta Corrente: " + contaCorrente.Saldo.ToString("F2", CultureInfo.InvariantCulture));

        Console.WriteLine("\n---------- Resultado Conta Poupança ----------");

        Console.WriteLine("\nSaldo Inicial da Conta Poupança: " + contaPoupanca.Saldo.ToString("F2", CultureInfo.InvariantCulture));
        contaPoupanca.Depositar(depositoContaPoupanca);
        Console.WriteLine("Saldo após depósito na Conta Poupança: " + contaPoupanca.Saldo.ToString("F2", CultureInfo.InvariantCulture));
        contaPoupanca.Sacar(saqueContaPoupanca);
        Console.WriteLine("Saldo após saque na Conta Poupança: " + contaPoupanca.Saldo.ToString("F2", CultureInfo.InvariantCulture));

        Console.ReadKey();
    }
}