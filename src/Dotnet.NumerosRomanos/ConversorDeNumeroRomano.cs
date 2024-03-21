namespace Dotnet.NumerosRomanos
{
    public class ConversorDeNumeroRomano
    {
        public int ConverteNumero(string numeroEmRomano) 
        {
            var acumulador = 0;
            var ultimoValorDaDireita = 0;
            var multiplicador = 1;

            for (int i = numeroEmRomano.Length - 1; i >= 0; i--) 
            {
                var valorAtual = tabelaDeNumerosRomanos[numeroEmRomano[i].ToString()];

                if (valorAtual < ultimoValorDaDireita) 
                {
                    multiplicador = -1;
                }

                acumulador += valorAtual * multiplicador;
                ultimoValorDaDireita = valorAtual;
            }

            return acumulador;
        }

        private static Dictionary<string, int> tabelaDeNumerosRomanos = new Dictionary<string, int>() 
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };
    }
}
