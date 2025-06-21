using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;

namespace ControleDeBar.ConsoleApp.ModuloProdutos;

public class TelaProdutos : TelaBase<Produtos>, ITela
{

    public TelaProdutos(RepositorioProdutos repositorio) : base("Produtos", repositorio)
    {
    }
    public override void CadastrarRegistro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"             Cadastro de {nomeEntidade}");
        Console.Write("------------------------------------------");
        Console.ResetColor();

        Console.WriteLine();

        Produtos novoRegistro = (Produtos)ObterDados();

        string erros = novoRegistro.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            ExibirContinuar();

            CadastrarRegistro();

            return;
        }
        Produtos[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Produtos amigoRegistrado = (Produtos)registros[i];

            if (amigoRegistrado == null)
                continue;

            if (amigoRegistrado.Nome == novoRegistro.Nome )
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("------------------------------------------");
                Console.WriteLine("Um produto com este nome já foi cadastrado!");
                Console.Write("------------------------------------------");
                Console.ResetColor();

                ExibirContinuar();

                CadastrarRegistro();
                return;
            }
        }

        repositorio.CadastrarRegistro(novoRegistro);

        Console.Clear();
        Console.Write("------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
        Console.ResetColor();
        Console.Write("------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.ResetColor();
        Console.Write("------------------------------------------");
        Console.ReadLine();
    }
    public override void EditarRegistro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"            Edição de {nomeEntidade}");
        Console.WriteLine("------------------------------------------");
        Console.ResetColor();
        Console.WriteLine();

        VisualizarRegistros(false);
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.Clear();
        Console.WriteLine();
        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"            Edição de {nomeEntidade}");
        Console.WriteLine("------------------------------------------");
        Console.ResetColor();

        Produtos registroAtualizado = ObterDados();

        string erros = registroAtualizado.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            ExibirContinuar();


            EditarRegistro();

            return;
        }

        Produtos[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Produtos garconRegistrado = (Produtos)registros[i];

            if (garconRegistrado == null)
                continue;

            if (
                garconRegistrado.Id != idSelecionado &&
                garconRegistrado.Nome == registroAtualizado.Nome ||
                garconRegistrado.Preco == registroAtualizado.Preco)
            
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("------------------------------------------");
                Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                Console.Write("------------------------------------------");

                Console.ResetColor();

                ExibirContinuar();


                EditarRegistro();

                return;
            }
        }

        repositorio.EditarRegistro(idSelecionado, registroAtualizado);

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"{nomeEntidade} editado com sucesso!");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.WriteLine();

        Console.ResetColor();
        Console.ReadLine();
    }
    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Visualização de Produtos");
        Console.WriteLine("------------------------------------------");



        Console.WriteLine(
            "{0, -10} |{0, -15} | {1, -30}",
            "Id", "Nome", "Preço"
        );

        Produtos[] garcons = repositorio.SelecionarRegistros();

        for (int i = 0; i < garcons.Length; i++)
        {
            Produtos p = garcons[i];

            if (p == null)
                continue;

            Console.WriteLine(
             "{0, -10} |{0, -15} | {1, -30}",
                p.Id, p.Nome, p.Preco.ToString("C2")
            );
        }

        ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    protected override Produtos ObterDados()
    {
        string nome = string.Empty;

        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.Write("Digite o nome do produto: ");
            nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(nome))
            {
                ApresentarMensagem("Digite um nome válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

       bool conseguiConverterPreco  = false;

        decimal preco = 0.0m;

        while (conseguiConverterPreco)
        {
            Console.Write("Digite o preço do produto: ");
            conseguiConverterPreco = decimal.TryParse(Console.ReadLine(), out preco);

            if (conseguiConverterPreco)
            {
                ApresentarMensagem("Digite um preço válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        return new Produtos(nome, preco);
    }
}