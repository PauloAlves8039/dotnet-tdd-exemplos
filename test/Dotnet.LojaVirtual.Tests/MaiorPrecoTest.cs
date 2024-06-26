namespace Dotnet.LojaVirtual.Tests
{
    public class MaiorPrecoTest
    {
        CarrinhoDeCompras carrinhoDeCompras = new CarrinhoDeCompras();

        [Fact(DisplayName = "EncontrarMenorPreco - Retorna pre�o zero com carrinho de compras vazio")]
        public void EncontrarMenorPreco_DeveRetornarZeroSeCarrinhoVazio()
        {
            var maiorPreco = new MaiorPreco();

            var valorRecebido = maiorPreco.EncontrarMaiorPreco(carrinhoDeCompras);

            var valorEsperado = 0.0;

            Assert.Equal(valorEsperado, valorRecebido, 0.0001);
        }

        [Fact(DisplayName = "EncontrarMenorPreco - Retorna item do carrinho de compras com um elemento")]
        public void EncontrarMenorPreco_DeveRetornarValorDoItemSeCarrinhoComUmElemento()
        {
            carrinhoDeCompras.AdicionarItem(new Item("Gelareira", 1, 900.0));
            
            var maiorPreco = new MaiorPreco();

            var valorRecebido = maiorPreco.EncontrarMaiorPreco(carrinhoDeCompras);

            var valorEsperado = 900.0;

            Assert.Equal(valorEsperado, valorRecebido, 0.0001);
        }

        [Fact(DisplayName = "EncontrarMenorPreco - Retorna item com maior valor do carrinho de compras com v�rios elementos")]
        public void EncontrarMenorPreco_DeveRetornarMaiorValorSeCarrinhoContemMuitosElementos()
        {
            carrinhoDeCompras.AdicionarItem(new Item("Gelareira", 1, 900.0));
            carrinhoDeCompras.AdicionarItem(new Item("Fog�o", 1, 1500.0));
            carrinhoDeCompras.AdicionarItem(new Item("M�quina de Lavar", 1, 750.0));

            var maiorPreco = new MaiorPreco();

            var valorRecebido = maiorPreco.EncontrarMaiorPreco(carrinhoDeCompras);

            var valorEsperado = 1500.0;

            Assert.Equal(valorEsperado, valorRecebido, 0.0001);
        }
    }
}