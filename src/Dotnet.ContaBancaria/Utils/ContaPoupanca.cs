using Dotnet.ContaBancaria.Models;

namespace Dotnet.ContaBancaria.Utils
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(double saldoInicial) : base(saldoInicial) { }

        public override bool Sacar(double valor)
        {
            double valorTotalSaque = valor + 0.10;

            if (Saldo >= valorTotalSaque)
            {
                Saldo -= valorTotalSaque;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Depositar(double valor)
        {
            Saldo += valor;
        }
    }
}
