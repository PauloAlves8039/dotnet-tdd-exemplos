using Dotnet.ContaBancaria.Models;
using FluentAssertions;

namespace Dotnet.ContaBancaria.Tests
{
    public class ContaTest
    {
        [Fact(DisplayName = "Depositar - Retorna depósito com valor correto")]
        public void Depositar_DeveRetornarDepositoCorretamente()
        {
            var saldoInicial = 1000.0;
            var valorDeposito = 500.0;
            var saldoEsperado = saldoInicial + valorDeposito;

            var conta = new Conta(saldoInicial);

            conta.Depositar(valorDeposito);

            conta.Saldo.Should().Be(saldoEsperado);
        }

        [Fact(DisplayName = "Depositar - Retorna depósito com valor negativo")]
        public void Depositar_DeveRetornarDepositoNegativo()
        {
            var saldoInicial = 1000.0;
            var valorDepositoNegativo = -500.0;

            var conta = new Conta(saldoInicial);

            conta.Invoking(c => c.Depositar(valorDepositoNegativo)).Should().NotThrow<Exception>();
        }

        [Fact(DisplayName = "Depositar - Retorna depósito com valor zerado")]
        public void Depositar_DeveRetornarDepositoComValorZero()
        {
            var saldoInicial = 1000.0;
            var valorDepositoNegativo = 0.0;

            var conta = new Conta(saldoInicial);

            conta.Depositar(valorDepositoNegativo);

            conta.Saldo.Should().Be(saldoInicial);
        }

        [Fact(DisplayName = "Sacar - Retorna valor do saque correto")]
        public void Sacar_DeveRetornarSaqueCorretamente()
        {
            var saldoInicial = 1000.0;
            var valorSaque = 500.0;
            var saldoEsperado = saldoInicial - valorSaque;

            var conta = new Conta(saldoInicial);

            conta.Sacar(valorSaque);

            conta.Saldo.Should().Be(saldoEsperado);
        }

        [Fact(DisplayName = "Sacar - Retorna valor zero para o saque")]
        public void Sacar_DeveRetornarSaqueZeradoQuandoSaldoEhZero()
        {
            var saldoInicial = 0.0;
            var valorSaque = 500.0;

            var conta = new Conta(saldoInicial);

            conta.Invoking(c => c.Sacar(valorSaque)).Should().NotThrow<Exception>(); 
            conta.Saldo.Should().Be(0); 
        }

        [Fact(DisplayName = "Sacar - Retorna valor do saque zero para saldo negativo")]
        public void Sacar_DeveRetornarSaqueZeradoQuandoValorEhNegativo()
        {
            var saldoInicial = -1000.0;
            var valorSaque = 500.0;

            var conta = new Conta(saldoInicial);

            bool saqueBemSucedido = conta.Sacar(valorSaque);

            saqueBemSucedido.Should().BeFalse();
            conta.Saldo.Should().Be(saldoInicial);
        }

    }
}