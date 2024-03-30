namespace Dotnet.Corretora.Tests
{
    public class CorretoraDeImoveisTest
    {
        CorretoraDeImoveis corretora = new CorretoraDeImoveis();

        List<Imovel> listaDeImoveis = new List<Imovel>
        {
            new Imovel("Rua Principal N° 10 Apto 05 Centro Recife-PE", 9000.0, "Apartamento"),
            new Imovel("Rua São Pedro N° 238 Apto 12 Boa Vista Recife-PE", 8000.0, "Apartamento"),
            new Imovel("Avenica Santo Antônio N° 47 Encruzilhada Recife-PE", 7000.0, "Casa")
        };

        [Fact(DisplayName = "ObterTodosOsImoveis - Retorna todos os imóveis")]
        public void ObterTodosOsImoveis_DeveRetornarListaDeImoveis()
        {
            foreach (var imovel in listaDeImoveis)
            {
                corretora.InserirImovel(imovel.Endereco, imovel.Preco, imovel.Tipo);
            }

            var saida = new StringWriter();
            Console.SetOut(saida);
            corretora.ObterTodosOsImoveis();

            var resultado = saida.ToString();

            Assert.Contains("Rua Principal N° 10 Apto 05 Centro Recife-PE", resultado);
            Assert.Contains("Rua São Pedro N° 238 Apto 12 Boa Vista Recife-PE", resultado);
            Assert.Contains("Avenica Santo Antônio N° 47 Encruzilhada Recife-PE", resultado);
        }

        [Fact(DisplayName = "ObterTodosOsImoveis - Retorna lista vazia quando não há imóveis")]
        public void ObterTodosOsImoveis_DeveRetornarListaVaziaQuandoNaoHaImoveis()
        {
            var saida = new StringWriter();
            Console.SetOut(saida);

            corretora.ObterTodosOsImoveis();

            var resultado = saida.ToString();
            Assert.Equal("Imóveis disponíveis:\r\n", resultado);
        }

        [Fact(DisplayName = "InserirImovel - Deve inserir imóvel na lista")]
        public void InserirImovel_DeveInserirImovelNaLista()
        {
            var endereco = "Rua Principal N° 10 Apto 05 Centro Recife-PE";
            var preco = 9000.0;
            var tipo = "Apartamento";

            corretora.InserirImovel(endereco, preco, tipo);

            Assert.Single(corretora.listaDeImoveis);
            Assert.Equal(endereco, corretora.listaDeImoveis[0].Endereco); 
            Assert.Equal(preco, corretora.listaDeImoveis[0].Preco); 
            Assert.Equal(tipo, corretora.listaDeImoveis[0].Tipo);
        }

        [Fact(DisplayName = "InserirImovel - Deve tratar corretamente valores vazios ou zerados")]
        public void InserirImovel_DeveTratarCorretamenteValoresVaziosOuZerados()
        {
            var endereco = "";
            var preco = 0.0;
            var tipo = "";

            corretora.InserirImovel(endereco, preco, tipo);

            Assert.Empty(corretora.listaDeImoveis);
        }

        [Fact(DisplayName = "AlterarPrecoDoImovel - Deve alterar o preço do imóvel")]
        public void AlterarPrecoDoImovel_DeveAlterarOPrecoDoImovel()
        {
            var enderecoExistente = "Rua Principal N° 10 Apto 05 Centro Recife-PE";
            var novoPreco = 9500.0;

            corretora.InserirImovel(enderecoExistente, 9000.0, "Apartamento");

            corretora.AlterarPrecoDoImovel(enderecoExistente, novoPreco);

            var imovelAlterado = corretora.listaDeImoveis.FirstOrDefault(i => i.Endereco == enderecoExistente);
            
            Assert.NotNull(imovelAlterado);
            Assert.Equal(novoPreco, imovelAlterado.Preco);
        }

        [Fact(DisplayName = "AlterarPrecoDoImovel - Deve mostrar mensagem de imóvel não encontrado")]
        public void AlterarPrecoDoImovel_DeveMostrarMensagemDeImovelNaoEncontrado()
        {
            var enderecoInexistente = "Endereço Inexistente";
            var novoPreco = 9500.0;

            var saida = new StringWriter();
            Console.SetOut(saida);
            corretora.AlterarPrecoDoImovel(enderecoInexistente, novoPreco);

            var resultado = saida.ToString();
            Assert.Contains("Imóvel não encontrado!", resultado);
        }

        [Fact(DisplayName = "CalcularValorMedio - Deve retornar valor médio dos imóveis quando há imóveis")]
        public void CalcularValorMedio_DeveRetornarValorMedioQuandoHaImoveis()
        {
            var endereco1 = "Rua Principal N° 10 Apto 05 Centro Recife-PE";
            var preco1 = 9000.0;
            var tipo1 = "Apartamento";

            var endereco2 = "Rua São Pedro N° 238 Apto 12 Boa Vista Recife-PE";
            var preco2 = 8000.0;
            var tipo2 = "Apartamento";

            corretora.InserirImovel(endereco1, preco1, tipo1);
            corretora.InserirImovel(endereco2, preco2, tipo2);

            var resultado = corretora.CalcularValorMedio();
            var resultadoEsperado = (preco1 + preco2) / 2;

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact(DisplayName = "CalcularValorMedio - Deve retornar 0 quando não há imóveis")]
        public void CalcularValorMedio_DeveRetornarZeroQuandoNaoHaImoveis()
        {
            var resultado = corretora.CalcularValorMedio();
            var resultadoEsperado = 0.0;

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}