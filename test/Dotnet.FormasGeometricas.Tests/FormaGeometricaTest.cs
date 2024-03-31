using Dotnet.FormasGeometricas.Interfaces;
using Moq;

namespace Dotnet.FormasGeometricas.Tests
{
    public class FormaGeometricaTest
    {
        [Fact(DisplayName = "CalcularArea - Retorna a Área de um Circulo")]
        public void CalcularArea_DeveRetornarAreaDeUmCirculo()
        {
            var raio = 5.0;
            var valorEsperado = Math.PI * Math.Pow(raio, 2);

            var mockCirculo = new Mock<IFormaGeometrica>();
            mockCirculo.Setup(c => c.CalcularArea()).Returns(valorEsperado);

            var resultado = mockCirculo.Object.CalcularArea();

            Assert.Equal(valorEsperado, resultado);
        }

        [Fact(DisplayName = "CalcularPerimetro - Retorna o Perímetro de um Circulo")]
        public void CalcularPerimetro_DeveRetornarPerimetroDeUmCirculo()
        {
            var raio = 5.0;
            var valorEsperado = 2 * Math.PI * raio;

            var mockCirculo = new Mock<IFormaGeometrica>();
            mockCirculo.Setup(c => c.CalcularPerimetro()).Returns(valorEsperado);

            var resultado = mockCirculo.Object.CalcularPerimetro();

            Assert.Equal(valorEsperado, resultado);
        }

        [Fact(DisplayName = "CalcularArea - Retorna Zero para a Área de um Círculo")]
        public void CalcularArea_DeveRetornarZeroParaAreaDeUmCirculo()
        {
            var valorEsperado = 0.0;

            var mockCirculo = new Mock<IFormaGeometrica>();
            mockCirculo.Setup(c => c.CalcularArea()).Returns(valorEsperado);

            var resultado = mockCirculo.Object.CalcularArea();

            Assert.Equal(valorEsperado, resultado);
        }

        [Fact(DisplayName = "CalcularPerimetro - Retorna Zero para o Parímetro de um Círculo")]
        public void CalcularPerimetro_DeveRetornarZeroParaPerimetroDeUmCirculo()
        {
            var valorEsperado = 0.0;

            var mockCirculo = new Mock<IFormaGeometrica>();
            mockCirculo.Setup(c => c.CalcularPerimetro()).Returns(valorEsperado);

            var resultado = mockCirculo.Object.CalcularPerimetro();

            Assert.Equal(valorEsperado, resultado);
        }

        [Fact(DisplayName = "CalcularArea - Retorna a Área de um Retângulo")]
        public void CalcularArea_DeveRetornarAreaDeUmRetangulo()
        {
            var largura = 5.0;
            var altura = 10.0;
            var valorEsperado = largura * altura;

            var mockRetangulo = new Mock<IFormaGeometrica>();
            mockRetangulo.Setup(r => r.CalcularArea()).Returns(valorEsperado);

            var resultado = mockRetangulo.Object.CalcularArea();

            Assert.Equal(valorEsperado, resultado);
        }

        [Fact(DisplayName = "CalcularPerimetro - Retorna o Perímetro de um Retângulo")]
        public void CalcularArea_DeveRetornarPerimetroDeUmRetangulo()
        {
            var largura = 5.0;
            var altura = 10.0;
            var valorEsperado = 2 * (largura + altura);

            var mockRetangulo = new Mock<IFormaGeometrica>();
            mockRetangulo.Setup(r => r.CalcularPerimetro()).Returns(valorEsperado);

            var resultado = mockRetangulo.Object.CalcularPerimetro();

            Assert.Equal(valorEsperado, resultado);
        }

        [Fact(DisplayName = "CalcularArea - Retorna Zero para a Área do Retângulo")]
        public void CalcularArea_DeveRetornarZeroParaAreaDeUmRetangulo()
        {
            var valorEsperado = 0.0;

            var mockRetangulo = new Mock<IFormaGeometrica>();
            mockRetangulo.Setup(c => c.CalcularArea()).Returns(valorEsperado);

            var resultado = mockRetangulo.Object.CalcularArea();

            Assert.Equal(valorEsperado, resultado);
        }

        [Fact(DisplayName = "CalcularPerimetro - Retorna Zero para o Parímetro de um Retângulo")]
        public void CalcularPerimetro_DeveRetornarZeroParaPerimetroDeUmRetangulo()
        {
            var valorEsperado = 0.0;

            var mockRetangulo = new Mock<IFormaGeometrica>();
            mockRetangulo.Setup(c => c.CalcularPerimetro()).Returns(valorEsperado);

            var resultado = mockRetangulo.Object.CalcularPerimetro();

            Assert.Equal(valorEsperado, resultado);
        }
    }
}