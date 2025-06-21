using System;
using System.Text.RegularExpressions;
using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeBar.ConsoleApp.ModuloProdutos;

public class Produtos : EntidadeBase<Produtos>
{
    public string Nome { get; set; }
    public string Preco { get; set; }
    //public decimal Preco { get; set; }

    public Produtos(string nome, string Preco)
    {
        Nome = nome;
        Preco = Preco;
    }
    public override void AtualizarRegistro(Produtos registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        Preco = registroAtualizado.Preco;
    }
    public override string Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 1 || Nome.Length > 100)
            erros += "O campo \"Nome\" deve conter entre 1 e 100 caracteres.";// throw new NotImplementedException();

        if (Preco.Length < 2 )
            erros += "O campo \"preço\"deve conter um número positivo com 2 casas decimais.";
        //○ Preço(número positivo com 2 casas decimais)

        //if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
        //    erros += "O campo \"Telefone\" deve seguir o padrão (DDD) 90000-0000.";

        return erros;
    }
}
