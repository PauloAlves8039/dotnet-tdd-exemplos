namespace Dotnet.CalculosDiversos.Interfaces
{
    public interface ICalculadora
    {
        double CalcularMediaDeNumeros(double numero1, double numero2, double numero3);
        int CalcularFatorialDeNumero(int numero);
        int CalcularSomaDosDigitos(int numero);
        bool VerificarNumeroPrimo(int numero);
    }
}
