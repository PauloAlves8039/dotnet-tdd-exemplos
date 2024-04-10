using Dotnet.ContaBancaria.Models;

namespace Dotnet.ContaBancaria.Utils
{
    public class ContaCorrente : Conta
    {
        private bool _primeiroSaqueGratuito = true;

        public ContaCorrente(double saldoInicial) : base(saldoInicial) {}

        public override bool Sacar(double valor)
        {
            if (_primeiroSaqueGratuito)
            {
                _primeiroSaqueGratuito = false;
            }
            else
            {
                valor += 0.05;
            }

            return base.Sacar(valor);
        }

        public override void Depositar(double valor)
        {
            try
            {
                Saldo += valor;
            }
            catch (Exception exception)
            {
                throw new Exception($"Erro ao depositar valor na conta corrente: {exception.Message}");
            }
        }
    }
}
