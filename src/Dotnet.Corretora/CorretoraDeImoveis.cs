using System.Globalization;

namespace Dotnet.Corretora
{
    public class CorretoraDeImoveis
    {
        public List<Imovel> listaDeImoveis = new List<Imovel>();

        public void ObterTodosOsImoveis() 
        {
            Console.WriteLine("Imóveis disponíveis:");

            foreach (var imovel in listaDeImoveis) 
            {
                Console.WriteLine($"Endereço: {imovel.Endereco}, Tipo: {imovel.Tipo}, Proço: {imovel.Preco.ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }

        public void InserirImovel(string endereco, double preco, string tipo)
        {
            if (string.IsNullOrWhiteSpace(endereco) || preco <= 0 || string.IsNullOrWhiteSpace(tipo))
            {
                Console.WriteLine("Impossível inserir o imóvel. Endereço, preço e tipo devem ser válidos.");
                return;
            }

            var imovel = new Imovel(endereco, preco, tipo);
            listaDeImoveis.Add(imovel);
            Console.WriteLine("Imóvel inserido com sucesso!");
        }


        public void AlterarPrecoDoImovel(string enderecoInformado, double novoPreco) 
        {
            var imovel = listaDeImoveis.Find(i => i.Endereco == enderecoInformado);


            if (imovel != null)
            {
                imovel.Preco = novoPreco;
                Console.WriteLine("Preço do imóvel alterado com sucesso!");
            }
            else 
            {
                Console.WriteLine("Imóvel não encontrado!");
            }
        }

        public double CalcularValorMedio() 
        {
            if (listaDeImoveis.Count == 0) 
            {
                return 0;
            }

            var somarPrecos = listaDeImoveis.Sum(imovel => imovel.Preco);
            somarPrecos.ToString("F2", CultureInfo.InvariantCulture);

            var resultado = somarPrecos / listaDeImoveis.Count;

            return resultado;
        }
    }
}
