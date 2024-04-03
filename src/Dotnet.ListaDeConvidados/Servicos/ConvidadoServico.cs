using Dotnet.ListaDeConvidados.Interfaces;
using Dotnet.ListaDeConvidados.Models;

namespace Dotnet.ListaDeConvidados.Servicos
{
    public class ConvidadoServico : IServicos<Convidado>
    {
        private readonly IArquivo<Convidado> _arquivo;

        public ConvidadoServico(IArquivo<Convidado> arquivo)
        {
            _arquivo = arquivo;
        }
        
        public List<Convidado> ObterTodos()
        {
            try
            {
                return _arquivo.LerArquivo();
            }
            catch (Exception exception)
            {
                throw new Exception("Erro ao obter lista de convidados.", exception);
            }
        }

        public Convidado PesquisarPorNome(string nome)
        {
            try
            {
                return ObterTodos().FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception exception)
            {
                throw new Exception("O convidado(a) não foi encontrado(a): ", exception);
            }
        }

        public void Adicionar(Convidado convidado)
        {
            try
            {
                List<Convidado> listaDeConvidados = ObterTodos();
                listaDeConvidados.Add(convidado);
                _arquivo.GerarArquivo(listaDeConvidados);
            }
            catch (Exception exception)
            {
                throw new Exception("Convidado(a) não é válido(a): ", exception);
            }
        }

        public void Excluir(string nome)
        {
            try
            {
                List<Convidado> listaDeConvidados = ObterTodos();
                listaDeConvidados.RemoveAll(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
                _arquivo.GerarArquivo(listaDeConvidados);
            }
            catch (Exception exception)
            {
                throw new Exception("Convidado(a) não foi encontrado(a): ", exception);
            }
        }
    }
}
