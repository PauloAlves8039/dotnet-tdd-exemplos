using Dotnet.FormasGeometricas.Interfaces;

namespace Dotnet.FormasGeometricas.Utils
{
    public class Retangulo : IFormaGeometrica
    {
        public double Largura { get; set; }
        public double Altura { get; set; }

        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }

        public double CalcularArea()
        {
            var resultadoArea = Largura * Altura;
            return resultadoArea;
        }

        public double CalcularPerimetro()
        {
            var resultadoPerimetro = 2 * (Largura + Altura);
            return resultadoPerimetro;
        }
    }
}
