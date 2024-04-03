namespace Dotnet.ListaDeConvidados.Interfaces
{
    public interface IServicos<T>
    {
        List<T> ObterTodos();
        T PesquisarPorNome(string nome);
        void Adicionar(T entidade);
        void Excluir(string nome);
    }
}
