using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloGarcom;

public class TelaGarcom : TelaBase<Garcom>, ITela
{

    public TelaGarcom(RepositorioGarcom repositorioGarcom) : base("Garçom", repositorioGarcom)
    {
    }
    public override void CadastrarRegistro()
    {
        ExibirCabecalho();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Cadastro de {nomeEntidade}");
        Console.Write("------------------------------------------");

        Console.WriteLine();

        Garcom novoRegistro = (Garcom)ObterDados();

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
        Garcom[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Garcom garcomRegistrado = (Garcom)registros[i];

            if (garcomRegistrado == null)
                continue;

            if (garcomRegistrado.Nome == novoRegistro.Nome || garcomRegistrado.Cpf == novoRegistro.Cpf)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Um amigo com este nome ou CPF já foi cadastrado!");
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

        Garcom registroAtualizado = ObterDados();

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

        Garcom[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Garcom garcomRegistrado = (Garcom)registros[i];

            if (garcomRegistrado == null)
                continue;

            if (
                garcomRegistrado.Id != idSelecionado &&
                garcomRegistrado.Nome == registroAtualizado.Nome ||
                garcomRegistrado.Cpf == registroAtualizado.Cpf)

            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("------------------------------------------");
                Console.WriteLine("Um garçom com este nome ou CPF já foi cadastrado!");
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
        Console.WriteLine("Visualização de Garçom");
        Console.WriteLine("------------------------------------------");



        Console.WriteLine(
            "{0, -10} |{0, -15} | {1, -30}",
            "Id", "Nome", "CPF"
        );

        Garcom[] garcoms = repositorio.SelecionarRegistros();

        for (int i = 0; i < garcoms.Length; i++)
        {
            Garcom g = garcoms[i];

            if (g == null)
                continue;

            Console.WriteLine(
             "{0, -10} |{0, -15} | {1, -30}",
                g.Id, g.Nome, g.Cpf
            );
        }

        ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    protected override Garcom ObterDados()
    {
        string nome = string.Empty;

        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.Write("Digite o nome do garçom: ");
            nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(nome))
            {
                ApresentarMensagem("Digite um nome válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        string cpf = string.Empty;

        while (string.IsNullOrWhiteSpace(cpf))
        {
            Console.Write("Digite o CPF do garçom: ");
            cpf = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                ApresentarMensagem("Digite um CPF válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        return new Garcom(nome, cpf);
    }

}