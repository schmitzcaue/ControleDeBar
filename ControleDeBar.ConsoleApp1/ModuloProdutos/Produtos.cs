using System.Text.RegularExpressions;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloProdutos;

public class Produtos : EntidadeBase<Produtos>
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public Produtos(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
    public override void AtualizarRegistro(Produtos registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        Preco = registroAtualizado.Preco;
    }
    public override string Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 2 || Nome.Length > 100)
            erros += "O campo \"Nome\" deve conter entre 2 e 100 caracteres.";

        if (Preco == 0.0m)
            erros += "O campo \"preço\" deve conter um número positivo.";

        return erros;
    }
}
