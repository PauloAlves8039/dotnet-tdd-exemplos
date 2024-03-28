using Dotnet.LojaVirtual;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("********** Carrinho de Compras **********");

        var carrinho = new CarrinhoDeCompras();

        var item1 = new Item("Camiseta", 2, 29.99);
        var item2 = new Item("Calça Jeans", 1, 59.99);
        var item3 = new Item("Tênis", 1, 89.99);
        var item4 = new Item("Pulseira", 1, 39.99);

        carrinho.AdicionarItem(item1);
        carrinho.AdicionarItem(item2);
        carrinho.AdicionarItem(item3);
        carrinho.AdicionarItem(item4);

        Console.WriteLine();

        Console.WriteLine("Itens no carrinho:");

        Console.WriteLine();

        foreach (var item in carrinho.Itens)
        {
            Console.WriteLine($"Descrição: {item.Descricao}, Quantidade: {item.Quantidade}, Valor Unitário: R$ {item.ValorUnitario}, Valor Total por iten: R$ {item.ValorTotalPorItem}");
        }

        Console.WriteLine();

        Console.WriteLine($"Preço parcial dos itens no carrinho: R$ {carrinho.CalcularPrecoTotal().ToString("F2")}");

        Console.WriteLine();

        Console.WriteLine($"Removendo o item '{item4.Descricao}' do carrinho.");
        
        carrinho.RemoverItem(item4);

        var calcularPreco = new MaiorPreco();
        
        var maiorPreco = calcularPreco.EncontrarMaiorPreco(carrinho);

        Console.WriteLine();

        Console.WriteLine($"Maior valor total no carrinho: R$ {maiorPreco}");

        Console.WriteLine();

        Console.WriteLine($"Preço total dos itens no carrinho: R$ {carrinho.CalcularPrecoTotal().ToString("F2")}");

        Console.ReadKey();
    }
}