using Dotnet.ListaDeConvidados.Interfaces;
using Dotnet.ListaDeConvidados.Models;
using Moq;

namespace Dotnet.ListaDeConvidados.Tests
{
    public class ArquivoTest
    {
        List<Convidado> listaDeConvidadosEsperada = new List<Convidado>
        {
            new Convidado { Nome = "João", Telefone = "123456789", Email = "joao@example.com" },
            new Convidado { Nome = "Maria", Telefone = "987654321", Email = "maria@example.com" }
        };

        [Fact(DisplayName = "GerarArquivo - Retorna arquivo gerado")]
        public void Arquivo_GerarArquivo_DeveRetornarArquivoGerado()
        {
            var mockFileWriter = new Mock<TextWriter>();
            var mockFile = new Mock<IArquivo<Convidado>>();

            mockFile.Setup(m => m.GerarArquivo(It.IsAny<List<Convidado>>()))
                .Callback<List<Convidado>>(lista =>
                {
                    foreach (var convidado in lista)
                    {
                        mockFileWriter.Object.WriteLine($"Nome: {convidado.Nome}, Telefone: {convidado.Telefone}, Email: {convidado.Email}");
                    }
                });

            mockFile.Object.GerarArquivo(listaDeConvidadosEsperada);

            mockFileWriter.Verify(m => m.WriteLine("Nome: João, Telefone: 123456789, Email: joao@example.com"), Times.Once());
            mockFileWriter.Verify(m => m.WriteLine("Nome: Maria, Telefone: 987654321, Email: maria@example.com"), Times.Once());
        }

        [Fact(DisplayName = "GerarArquivo - Retorna exceção quando não gerar arquivo")]
        public void Arquivo_GerarArquivo_DeveRetornarExcecaoQuandoNaoConseguirGerarArquivo()
        {
            var mockFile = new Mock<IArquivo<Convidado>>();

            mockFile.Setup(m => m.GerarArquivo(It.IsAny<List<Convidado>>()))
                .Throws(new IOException("Erro ao gerar arquivo"));

            Assert.Throws<IOException>(() => mockFile.Object.GerarArquivo(listaDeConvidadosEsperada));
        }

        [Fact(DisplayName = "LerArquivo - Retorna leitura de lista de convidados em arquivo existente")]
        public void Arquivo_LerArquivo_DeveRetornarLeituraDeArquivo()
        {
            var mockFile = new Mock<IArquivo<Convidado>>();

            mockFile.Setup(m => m.LerArquivo()).Returns(listaDeConvidadosEsperada);

            var resultado = mockFile.Object.LerArquivo();

            Assert.Equal(listaDeConvidadosEsperada.Count, resultado.Count);

            for (int i = 0; i < listaDeConvidadosEsperada.Count; i++)
            {
                Assert.Equal(listaDeConvidadosEsperada[i].Nome, resultado[i].Nome);
                Assert.Equal(listaDeConvidadosEsperada[i].Telefone, resultado[i].Telefone);
                Assert.Equal(listaDeConvidadosEsperada[i].Email, resultado[i].Email);
            }
        }

        [Fact(DisplayName = "LerArquivo - Retorna leitura de lista de convidados vazia quando arquivo não existir")]
        public void Arquivo_LerArquivo_DeveRetornarListaVaziaQuandoArquivoNaoExistir()
        {
            var mockFile = new Mock<IArquivo<Convidado>>();

            mockFile.Setup(m => m.LerArquivo()).Returns(new List<Convidado>());

            var resultado = mockFile.Object.LerArquivo();

            Assert.Empty(resultado);
        }
    }
}
