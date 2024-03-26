namespace Dotnet.LojaVirtual.Tests
{
    public class CarrinhoDeComprasTest
    {
        CarrinhoDeCompras carrinhoDeCompras = new CarrinhoDeCompras();

        [Fact]
        public void RemoverItem_DeveRemoverItemCorretamenteDoCarrinho()
        {
            var item = new Item("Calça Jeans", 1, 59.99);

            carrinhoDeCompras.AdicionarItem(item);

            carrinhoDeCompras.RemoverItem(item);

            Assert.DoesNotContain(item, carrinhoDeCompras.Itens);
        }

        [Fact]
        public void RemoverItem_NaoDeveRemoverItemSeItemNaoExistirNoCarrinho()
        {
            var item1 = new Item("Camiseta", 2, 29.99);
            var item2 = new Item("Calça Jeans", 1, 59.99);

            carrinhoDeCompras.AdicionarItem(item1);

            carrinhoDeCompras.RemoverItem(item2);

            Assert.Contains(item1, carrinhoDeCompras.Itens);
        }


        [Fact]
        public void CalcularPrecoTotal_DeveRetornarPrecoTotalCorretoDoCarrinho()
        {
            var item1 = new Item("Camiseta", 2, 29.99);
            var item2 = new Item("Calça Jeans", 1, 59.99);

            carrinhoDeCompras.AdicionarItem(item1);
            carrinhoDeCompras.AdicionarItem(item2);

            var precoTotalRecebido = carrinhoDeCompras.CalcularPrecoTotal();

            var precoTotalEsperado = 119.97;
            
            Assert.Equal(precoTotalEsperado, precoTotalRecebido);
        }

        [Fact]
        public void CalcularPrecoTotal_DeveRetornarZeroSeTodosOsItensTiveremPrecoZero()
        {
            var item1 = new Item("Camiseta", 2, 0.0);
            var item2 = new Item("Calça Jeans", 1, 0.0);

            carrinhoDeCompras.AdicionarItem(item1);
            carrinhoDeCompras.AdicionarItem(item2);

            var precoTotalRecebido = carrinhoDeCompras.CalcularPrecoTotal();

            var precoTotalEsperado = 0.0;

            Assert.Equal(precoTotalEsperado, precoTotalRecebido);
        }

    }
}
