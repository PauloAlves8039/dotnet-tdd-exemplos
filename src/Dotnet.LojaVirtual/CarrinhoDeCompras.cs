namespace Dotnet.LojaVirtual
{
    public class CarrinhoDeCompras
    {
        public IList<Item> Itens { get; private set; }

        public CarrinhoDeCompras()
        {
            Itens = new List<Item>();
        }

        public void AdicionarItem(Item item) 
        {
            Itens.Add(item);
        }

        public void RemoverItem(Item item)
        {
            Itens.Remove(item);
        }

        public double CalcularPrecoTotal()
        {
            var precoTotal = 0.0;

            foreach (var item in Itens)
            {
                precoTotal += item.ValorTotalPorItem;
            }

            return precoTotal;
        }
    }
}
