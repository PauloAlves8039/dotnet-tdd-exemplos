using Dotnet.CalculosDiversos.Interfaces;

namespace Dotnet.CalculosDiversos.Utils
{
    public class Calculadora : ICalculadora
    {
        public double CalcularMediaDeNumeros(double numero1, double numero2, double numero3)
        {
            var media = (numero1 + numero2 + numero3) / 3;
            return media;
        }

        public int CalcularFatorialDeNumero(int numero)
        {
            int fatorial = 1;

            if (numero == 0) 
            {
                return 1;
            }

            for (int i = 1; i <= numero; i++) 
            {
                fatorial *= i;
            }

            return fatorial;
        }

        public int CalcularSomaDosDigitos(int numero)
        {
            var soma = 0;

            while (numero != 0) 
            {
                soma += numero % 10;
                numero /= 10;
            }

            return soma;
        }

        public bool VerificarNumeroPrimo(int numero)
        {
            if (numero <= 1) 
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(numero); i++) 
            {
                if (numero % i == 0) 
                {
                    return false;
                }
            }

            return true;
        }
    }
}
