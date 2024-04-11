namespace Dotnet.ContaBancaria.Models
{
    public class Conta
    {
        public double Saldo { get; protected set; }

        public Conta(double saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public virtual void Depositar(double valor)
        {
            Saldo += valor;
        }

        public virtual bool Sacar(double valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
