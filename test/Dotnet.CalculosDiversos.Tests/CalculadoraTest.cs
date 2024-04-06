using Dotnet.CalculosDiversos.Interfaces;
using Dotnet.CalculosDiversos.Utils;

namespace Dotnet.CalculosDiversos.Tests
{
    public class CalculadoraTest
    {
        private readonly ICalculadora _calculadora;

        public CalculadoraTest()
        {
            _calculadora = new Calculadora();
        }

        [Theory(DisplayName = "CalcularMediaDeNumero - Retorna m�dia de n�meros correta")]
        [InlineData(0, 0, 0, 0)]
        [InlineData(5, 5, 5, 5)]
        [InlineData(10, 20, 30, 20)]
        [InlineData(30.5, 30.5, 30.5, 30.5)]
        public void CalcularMediaDeNumeros_DeveCalcularAMediaCorreta(double numero1, double numero2, double numero3, double resultadoEsperado)
        {
            var resultado = _calculadora.CalcularMediaDeNumeros(numero1, numero2, numero3);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory(DisplayName = "CalcularMediaDeNumero - Retorna m�dia de n�meros incorreta")]
        [InlineData(0, 0, 0, 1)]
        [InlineData(5, 5, 5, 6)]
        [InlineData(10, 20, 30, -21)]
        [InlineData(30.5, 30.5, 30.5, -31.99)]
        public void CalcularMediaDeNumeros_DeveCalcularAMediaIncorreta(double numero1, double numero2, double numero3, double resultadoEsperado)
        {
            var resultado = _calculadora.CalcularMediaDeNumeros(numero1, numero2, numero3);
            Assert.NotEqual(resultadoEsperado, resultado);
        }

        [Theory(DisplayName = "CalcularFatorialDeNumero - Retorna fatorial de n�mero correto")]
        [InlineData(0, 1)]
        [InlineData(1, 1)] 
        [InlineData(5, 120)] 
        [InlineData(10, 3628800)]
        public void CalcularFatorialDeNumero_DeveCalcularFatorialCorreto(int numero, int resultadoEsperado)
        {
            var resultado = _calculadora.CalcularFatorialDeNumero(numero);

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory(DisplayName = "CalcularFatorialDeNumero - Retorna fatorial de n�mero incorreto")]
        [InlineData(0, -1)]
        [InlineData(1, 2)]
        [InlineData(5, -120)]
        [InlineData(10, 3628700)]
        public void CalcularFatorialDeNumero_DeveCalcularFatorialIncorreto(int numero, int resultadoEsperado)
        {
            var resultado = _calculadora.CalcularFatorialDeNumero(numero);

            Assert.NotEqual(resultadoEsperado, resultado);
        }

        [Theory(DisplayName = "CalcularSomaDosDigitos - Retorna soma dos d�gitos correta")]
        [InlineData(123, 6)]
        [InlineData(100, 1)]
        [InlineData(524, 11)]
        [InlineData(987, 24)]
        public void CalcularSomaDosDigitos_DeveCalcularSomaDosDigitosCorreta(int numero, int resultadoEsperado)
        {
            var resultado = _calculadora.CalcularSomaDosDigitos(numero);

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory(DisplayName = "CalcularSomaDosDigitos - Retorna soma dos d�gitos incorreta")]
        [InlineData(123, 76)]
        [InlineData(100, 21)]
        [InlineData(524, -11)]
        [InlineData(987, -24)]
        public void CalcularSomaDosDigitos_DeveCalcularSomaDosDigitosIncorreta(int numero, int resultadoEsperado)
        {
            var resultado = _calculadora.CalcularSomaDosDigitos(numero);

            Assert.NotEqual(resultadoEsperado, resultado);
        }

        [Theory(DisplayName = "VerificarNumeroPrimo - Retorna verifica��o correta de n�mero primo")]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(10, false)]
        [InlineData(20, false)]
        public void VerificarNumeroPrimo_DeveVerificarNumeoPrimoCorreto(int numero, bool resultadoEsperado)
        {
            var resultado = _calculadora.VerificarNumeroPrimo(numero);

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory(DisplayName = "VerificarNumeroPrimo - Retorna verifica��o incorreta de n�mero primo")]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(10, true)]
        [InlineData(20, true)]
        public void VerificarNumeroPrimo_DeveVerificarNumeoPrimoIncorreto(int numero, bool resultadoEsperado)
        {
            var resultado = _calculadora.VerificarNumeroPrimo(numero);

            Assert.NotEqual(resultadoEsperado, resultado);
        }
    }
}