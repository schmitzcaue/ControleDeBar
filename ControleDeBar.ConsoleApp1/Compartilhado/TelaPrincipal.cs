using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProdutos;

namespace ControleDeBar.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private RepositorioMesa repositorioMesa;
    private TelaMesa telaMesa;

    private RepositorioGarcom repositorioGarcon;
    private TelaGarcom telaGarcon;

    private RepositorioProdutos repositorioProdutos;
    private TelaProdutos telaProdutos;

    public TelaPrincipal()
    {
        repositorioMesa = new RepositorioMesa();
        repositorioGarcon = new RepositorioGarcom();
        repositorioProdutos = new RepositorioProdutos();

        telaMesa = new TelaMesa(repositorioMesa);
        telaGarcon = new TelaGarcom(repositorioGarcon);
        telaProdutos = new TelaProdutos(repositorioProdutos);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|           Controle de Bar            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Mesas");
        Console.WriteLine("2 - Controle de Garçons");
        Console.WriteLine("3 - Controle de Produtos");
        Console.WriteLine("4 - Controle de Contas");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoEscolhida = Console.ReadLine()![0];
    }

    public ITela ObterTela()
    {
        if (opcaoEscolhida == '1')
            return telaMesa;

        if (opcaoEscolhida == '2')
            return telaGarcon;

        if (opcaoEscolhida == '3')
            return telaProdutos;

        if (opcaoEscolhida == '4')
            return null;

        return null;
    }
}