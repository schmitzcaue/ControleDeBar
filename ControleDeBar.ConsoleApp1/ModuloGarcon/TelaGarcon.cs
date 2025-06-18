using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;

namespace ControleDeBar.ConsoleApp.ModuloGarcon;

public class TelaGarcon : TelaBase<Garcon>, ITela
{

    public TelaGarcon(RepositorioGarcon repositorioGarcon) : base("Garçon", repositorioGarcon)
    {
    }
    public override void CadastrarRegistro()
    {
        ExibirCabecalho();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Cadastro de {nomeEntidade}");
        Console.Write("------------------------------------------");

        Console.WriteLine();

        Garcon novoRegistro = (Garcon)ObterDados();

        string erros = novoRegistro.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            Console.Write("\nDigite ENTER para continuar...");
            Console.ReadLine();

            CadastrarRegistro();

            return;
        }
        Garcon[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Garcon amigoRegistrado = (Garcon)registros[i];

            if (amigoRegistrado == null)
                continue;

            if (amigoRegistrado.Nome == novoRegistro.Nome || amigoRegistrado.Cpf == novoRegistro.Cpf)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Um amigo com este nome ou CPF já foi cadastrado!");
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

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

        Garcon registroAtualizado = ObterDados();

        string erros = registroAtualizado.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            Console.Write("\nDigite ENTER para continuar...");
            Console.ReadLine();

            EditarRegistro();

            return;
        }

        Garcon[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Garcon garconRegistrado = (Garcon)registros[i];

            if (garconRegistrado == null)
                continue;

            if (
                garconRegistrado.Id != idSelecionado &&
                garconRegistrado.Nome == registroAtualizado.Nome ||
                garconRegistrado.Cpf == registroAtualizado.Cpf)
            
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("------------------------------------------");
                Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                Console.Write("------------------------------------------");

                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

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

        Console.WriteLine("Visualização de Garçons");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} |{0, -15} | {1, -30}",
            "Id", "Nome", "CPF"
        );

        Garcon[] garcons = repositorio.SelecionarRegistros();

        for (int i = 0; i < garcons.Length; i++)
        {
            Garcon m = garcons[i];

            if (m == null)
                continue;

            Console.WriteLine(
             "{0, -10} |{0, -15} | {1, -30}",
                m.Id, m.Nome, m.Cpf
            );
        }

        ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    protected override Garcon ObterDados()
    {
        //ajustes
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Digite o nome do garçon: ");
        string nome = Console.ReadLine();
        Console.WriteLine("------------------------------------------");

        Console.Write("Digite o CPF do garcon: ");
        string cpf = Console.ReadLine();
        //int cpf = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("------------------------------------------");

        Console.ResetColor();

        Garcon garcon = new Garcon(nome, cpf);

        return garcon;
    }




}