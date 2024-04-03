using Dotnet.ListaDeConvidados.Interfaces;
using Dotnet.ListaDeConvidados.Models;

namespace Dotnet.ListaDeConvidados.Utils
{
    public class Arquivo : IArquivo<Convidado>
    {
        private string filePath = "lista_de_convidados.txt";

        public void GerarArquivo(List<Convidado> listaDeConvidados)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var convidado in listaDeConvidados)
                    {
                        writer.WriteLine($"Nome: {convidado.Nome}, Telefone: {convidado.Telefone}, Email: {convidado.Email}");
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erro ao gerar o arquivo de convidados: ", exception);
            }
        }

        public List<Convidado> LerArquivo()
        {
            var listaDeConvidados = new List<Convidado>();

            try
            {
                if (File.Exists(filePath))
                {
                    string[] linhas = File.ReadAllLines(filePath);

                    foreach (string linha in linhas)
                    {
                        string[] dados = linha.Split(',');

                        listaDeConvidados.Add(new Convidado
                        {
                            Nome = dados[0].Split(':')[1].Trim(),
                            Telefone = dados[1].Split(':')[1].Trim(),
                            Email = dados[2].Split(':')[1].Trim()
                        });
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erro ao ler o arquivo de convidados: ", exception);
            }

            return listaDeConvidados;
        }
    }
}
