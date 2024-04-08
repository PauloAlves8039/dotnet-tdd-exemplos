namespace Dotnet.NumerosRomanos.Tests
{
    public class ConversorDeNumeroRomanoTest
    {
        ConversorDeNumeroRomano numeroRomano = new ConversorDeNumeroRomano();

        [Fact(DisplayName = "ConverteNumero - Retorna valor zero com símbolo vazio")]
        public void ConverteNumero_ValorInteiroZeroEsperado_DeveEntenderOSimboloVazio()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("");

            var numeroEsperado = 0;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 1 com símbolo I")]
        public void ConverteNumero_ValorInteiroUmEsperado_DeveEntenderOSimboloI()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("I");

            var numeroEsperado = 1;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 2 com símbolo II")]
        public void ConverteNumero_ValorInteiroDoisEsperado_DeveEntenderOSimboloII()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("II");

            var numeroEsperado = 2;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 3 com símbolo III")]
        public void ConverteNumero_ValorInteiroTresEsperado_DeveEntenderOSimboloIII()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("III");

            var numeroEsperado = 3;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 5 com símbolo V")]
        public void ConverteNumero_ValorInteiroCincoEsperado_DeveEntenderOSimboloV()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("V");

            var numeroEsperado = 5;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 10 com símbolo X")]
        public void ConverteNumero_ValorInteiroDezEsperado_DeveEntenderOSimboloX()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("X");

            var numeroEsperado = 10;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 50 com símbolo L")]
        public void ConverteNumero_ValorInteiroCinquentaEsperado_DeveEntenderOSimboloL()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("L");

            var numeroEsperado = 50;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 100 com símbolo C")]
        public void ConverteNumero_ValorInteiroCemEsperado_DeveEntenderOSimboloC()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("C");

            var numeroEsperado = 100;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 500 com símbolo D")]
        public void ConverteNumero_ValorInteiroQuinhentosEsperado_DeveEntenderOSimboloD()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("D");

            var numeroEsperado = 500;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 1000 com símbolo M")]
        public void ConverteNumero_ValorInteiroMilEsperado_DeveEntenderOSimboloM()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("M");

            var numeroEsperado = 1000;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 4 com símbolo IV")]
        public void ConverteNumero_ValorInteiroQuatroEsperado_DeveEntenderOSimboloIV()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("IV");

            var numeroEsperado = 4;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 13 com símbolo XIII")]
        public void ConverteNumero_ValorInteiroTrezeEsperado_DeveEntenderOSimboloXIII()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("XIII");

            var numeroEsperado = 13;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 28 com símbolo XXVIII")]
        public void ConverteNumero_ValorInteiroVinteEOitoEsperado_DeveEntenderOSimboloXXVIII()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("XXVIII");

            var numeroEsperado = 28;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }

        [Fact(DisplayName = "ConverteNumero - Retorna valor 38 com símbolo XXXVIII")]
        public void ConverteNumero_ValorInteiroTrintaEOitoEsperado_DeveEntenderOSimboloXXXVIII()
        {
            var numeroRecebido = numeroRomano.ConverteNumero("XXXVIII");

            var numeroEsperado = 38;

            Assert.Equal(numeroEsperado, numeroRecebido);
        }
    }
}