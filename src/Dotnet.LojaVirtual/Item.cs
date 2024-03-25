namespace Dotnet.LojaVirtual
{
    public class Item
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }

        public Item(string descricao, int quantidade, double valorUnitario)
        {
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public double ValorTotalPorItem 
        {
            get { return ValorUnitario * Quantidade; }
        }
    }
}
