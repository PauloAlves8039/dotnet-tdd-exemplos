namespace Dotnet.LojaVirtual
{
    public class MaiorPreco
    {
        public double EncontrarMaiorPreco(CarrinhoDeCompras carrinhoDeCompras)
        {
            if (carrinhoDeCompras.Itens.Count == 0) 
            {
                return 0;
            }

            var maior = carrinhoDeCompras.Itens[0].ValorTotalPorItem;

            foreach (var item in carrinhoDeCompras.Itens)
            {
                if (maior < item.ValorTotalPorItem) 
                {
                    maior = item.ValorTotalPorItem;
                }
            }

            return maior;
        }
    }
}
