namespace Dotnet.ListaDeConvidados.Interfaces
{
    public interface IArquivo<T>
    {
        void GerarArquivo(List<T> listaDeRegistros);
        List<T> LerArquivo();
    }
}
