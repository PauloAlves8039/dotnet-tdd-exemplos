using Dotnet.ListaDeConvidados.Interfaces;
using Dotnet.ListaDeConvidados.Models;
using Dotnet.ListaDeConvidados.Servicos;
using Moq;

namespace Dotnet.ListaDeConvidados.Tests
{
    public class ServicosTest
    {
        List<Convidado> listaDeConvidadosEsperada = new List<Convidado>
        {
            new Convidado { Nome = "João", Telefone = "123456789", Email = "joao@example.com" },
            new Convidado { Nome = "Maria", Telefone = "987654321", Email = "maria@example.com" }
        };

        [Fact(DisplayName = "ObterTodos - Retorna lista com todos os convidados")]
        public void ConvidadoServico_ObterTodos_DeveRetornarListaDeConvidados()
        {
            var mockServicos = new Mock<IServicos<Convidado>>();

            mockServicos.Setup(m => m.ObterTodos()).Returns(listaDeConvidadosEsperada);

            var resultado = mockServicos.Object.ObterTodos();

            Assert.Equal(listaDeConvidadosEsperada.Count, resultado.Count);

            for (int i = 0; i < listaDeConvidadosEsperada.Count; i++)
            {
                Assert.Equal(listaDeConvidadosEsperada[i].Nome, resultado[i].Nome);
                Assert.Equal(listaDeConvidadosEsperada[i].Telefone, resultado[i].Telefone);
                Assert.Equal(listaDeConvidadosEsperada[i].Email, resultado[i].Email);
            }
        }

        [Fact(DisplayName = "ObterTodos - Retorna lista vazia quando não há convidados")]
        public void ConvidadoServico_ObterTodos_DeveRetornarListaVaziaQuandoNaoHouverConvidados()
        {
            var mockServicos = new Mock<IServicos<Convidado>>();

            mockServicos.Setup(m => m.ObterTodos()).Returns(new List<Convidado>());

            var resultado = mockServicos.Object.ObterTodos();

            Assert.Empty(resultado);
        }

        [Fact(DisplayName = "PesquisarPorNome - Retorna convidado por nome")]
        public void ConvidadoServico_PesquisarPorNome_DeveRetornarConvidadoPorNome()
        {
            var nomeBuscado = "João";
            var convidadoEsperado = new Convidado { Nome = "João", Telefone = "123456789", Email = "joao@example.com" };

            var mockArquivo = new Mock<IArquivo<Convidado>>();
            mockArquivo.Setup(m => m.LerArquivo()).Returns(new List<Convidado>
            {
                convidadoEsperado,
                new Convidado { Nome = "Maria", Telefone = "987654321", Email = "maria@example.com" }
            });

            var servicos = new ConvidadoServico(mockArquivo.Object);

            var resultado = servicos.PesquisarPorNome(nomeBuscado);

            Assert.Equal(convidadoEsperado, resultado);
        }

        [Fact(DisplayName = "PesquisarPorNome - Retorna nulo quando não encontrar convidado")]
        public void ConvidadoServico_PesquisarPorNome_DeveRetornarNullQuandoNaoEncontrarConvidado()
        {
            var nomeBuscado = "João";

            var mockArquivo = new Mock<IArquivo<Convidado>>();
            mockArquivo.Setup(m => m.LerArquivo()).Returns(new List<Convidado>
            {
                new Convidado { Nome = "Maria", Telefone = "987654321", Email = "maria@example.com" }
            });

            var servicos = new ConvidadoServico(mockArquivo.Object);

            var resultado = servicos.PesquisarPorNome(nomeBuscado);

            Assert.Null(resultado);
        }

        [Fact(DisplayName = "Adicionar - Retorna convidado ao ser adicionado")]
        public void ConvidadoServico_Adicionar_DeveRetornarConvidadoAdicionado()
        {
            var mockServicos = new Mock<IServicos<Convidado>>();
            var novoConvidado = new Convidado { Nome = "Carlos", Telefone = "999999999", Email = "carlos@example.com" };

            mockServicos.Setup(m => m.Adicionar(It.IsAny<Convidado>()))
                .Callback<Convidado>(pessoa =>
                {
                    listaDeConvidadosEsperada.Add(pessoa);
                });

            mockServicos.Object.Adicionar(novoConvidado);

            Assert.Contains(novoConvidado, listaDeConvidadosEsperada);
        }

        [Fact(DisplayName = "Adicionar - Retorna exceção ao adicionar convidado inválido")]
        public void ConvidadoServico_Adicionar_DeveLancarExcecaoQuandoConvidadoInvalido()
        {
            var mockServicos = new Mock<IServicos<Convidado>>();
            var convidadoInvalido = new Convidado { Nome = null, Telefone = "999999999", Email = "carlos@example.com" };

            mockServicos.Setup(m => m.Adicionar(It.IsAny<Convidado>()))
                .Throws(new ArgumentException("Convidado(a) não é válido(a)"));

            Assert.Throws<ArgumentException>(() => mockServicos.Object.Adicionar(convidadoInvalido));
        }

        [Fact(DisplayName = "Excluir - Retorna convidado excluído")]
        public void ConvidadoServico_Excluir_DeveRetornarConvidadoExcluido()
        {
            var mockServicos = new Mock<IServicos<Convidado>>();
            var convidadoAExcluir = listaDeConvidadosEsperada[0];

            mockServicos.Setup(m => m.Excluir(It.IsAny<string>()))
                .Callback<string>(nome =>
                {
                    listaDeConvidadosEsperada.RemoveAll(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
                });

            mockServicos.Object.Excluir(convidadoAExcluir.Nome);

            Assert.DoesNotContain(convidadoAExcluir, listaDeConvidadosEsperada);
        }

        [Fact(DisplayName = "Excluir - Retorna exceção ao excluir convidado")]
        public void ConvidadoServico_Excluir_DeveLancarExcecaoQuandoPessoaNaoEncontrada()
        {
            var mockServicos = new Mock<IServicos<Convidado>>();
            var convidadeNaoEncontrado = "ConvidadoInexistente";

            mockServicos.Setup(m => m.Excluir(It.IsAny<string>()))
                .Throws(new InvalidOperationException("Convidado(a) não foi encontrado(a)"));

            Assert.Throws<InvalidOperationException>(() => mockServicos.Object.Excluir(convidadeNaoEncontrado));
        }

    }
}