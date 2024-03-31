using Dotnet.FormasGeometricas.Interfaces;

namespace Dotnet.FormasGeometricas.Utils
{
    public class Circulo : IFormaGeometrica
    {
        public double Raio { get; set; }

        public Circulo(double raio)
        {
            Raio = raio;
        }

        public double CalcularArea()
        {
            var resultadoArea = Math.PI * Math.Pow(Raio, 2);
            return resultadoArea;
        }

        public double CalcularPerimetro()
        {
            var resultadoPerimetro = 2 * Math.PI * Raio;
            return resultadoPerimetro;
        }
    }
}
