using System.Text.RegularExpressions;
using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeBar.ConsoleApp.ModuloGarcon;

public class Garcon : EntidadeBase<Garcon>
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    //public int Cpf { get; set; }

    public Garcon(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }

    //    ○ Nome(mínimo 3 caracteres, máximo 100)
    //○ CPF(formato validado: XXX.XXX.XXX-XX)

    public override void AtualizarRegistro(Garcon registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        Cpf = registroAtualizado.Cpf;
    }

    public override string Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo \"Nome\" deve conter entre 3 e 100 caracteres.";// throw new NotImplementedException();

        if (Cpf.Length != 11)
            erros += "O campo \"cpf\" deve conter 11 caracteres.";

        //if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
        //    erros += "O campo \"Telefone\" deve seguir o padrão (DDD) 90000-0000.";

        return erros;
    }
}
