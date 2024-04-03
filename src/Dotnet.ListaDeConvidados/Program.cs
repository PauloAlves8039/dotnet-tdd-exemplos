using Dotnet.ListaDeConvidados.Interfaces;
using Dotnet.ListaDeConvidados.Models;
using Dotnet.ListaDeConvidados.Servicos;
using Dotnet.ListaDeConvidados.Utils;

internal class Program
{
    static IServicos<Convidado> _convidadoServico;

    private static void Main(string[] args)
    {
        Console.WriteLine("********** Convidados **********");

        IArquivo<Convidado> arquivo = new Arquivo();
        _convidadoServico = new ConvidadoServico(arquivo);

        var sair = false;

        while (!sair)
        {
            Console.WriteLine("--------------- Menu ---------------");
            Console.WriteLine("1. Exibir Lista de Convidados");
            Console.WriteLine("2. Pesquisar Convidado Por Nome");
            Console.WriteLine("3. Adicionar Convidado");
            Console.WriteLine("4. Excluir Convidado");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ExibirListaDeConvidados();
                    break;
                case "2":
                    PesquisarConvidadoPorNome();
                    break;
                case "3":
                    AdicionarConvidado();
                    break;
                case "4":
                    ExcluirConvidado();
                    break;
                case "5":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.ReadKey();
        }

        Console.ReadKey();
    }

    static void ExibirListaDeConvidados()
    {
        Console.WriteLine("====================  Lista de Convidados ====================");
        var listaDeConvidados = _convidadoServico.ObterTodos();

        foreach (var convidado in listaDeConvidados)
        {
            Console.WriteLine($"Nome: {convidado.Nome}, Telefone: {convidado.Telefone}, Email: {convidado.Email}");
        }
    }

    static void PesquisarConvidadoPorNome()
    {
        Console.Write("Digite o nome do(a) convidado(a) que deseja pesquisar: ");
        string nome = Console.ReadLine();

        var convidado = _convidadoServico.PesquisarPorNome(nome);

        if (convidado != null)
        {
            Console.WriteLine($"Convidado(a) encontrado(a): Nome: {convidado.Nome}, Telefone: {convidado.Telefone}, Email: {convidado.Email}");
        }
        else
        {
            Console.WriteLine($"O convidado {nome} não foi encontrado na lista.");
        }
    }

    static void AdicionarConvidado()
    {
        Console.Write("Digite o nome do(a) convidado(a): ");
        string nome = Console.ReadLine();

        Console.Write("Digite o telefone do(a) convidado(a): ");
        string telefone = Console.ReadLine();
        
        Console.Write("Digite o email do(a) convidado(a): ");
        string email = Console.ReadLine();

        _convidadoServico.Adicionar(new Convidado { Nome = nome, Telefone = telefone, Email = email });
        Console.WriteLine("Convidado(a) adicionado(a) com sucesso!");
    }

    static void ExcluirConvidado()
    {
        Console.Write("Digite o nome do(a) convidado(a) que deseja excluir: ");
        string nome = Console.ReadLine();

        var convidado = _convidadoServico.ObterTodos().Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (convidado != null)
        {
            _convidadoServico.Excluir(nome);
            Console.WriteLine($"Convidado(a) {nome} foi removido(a) da lista.");
        }
        else
        {
            Console.WriteLine($"Convidado(a) {nome} não foi encontrado(a) na lista.");
        }
    }
}