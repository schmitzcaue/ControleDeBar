using System.Text.RegularExpressions;
using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;

namespace ControleDeBar.ConsoleApp.ModuloGarcom;

public class Garcom : EntidadeBase<Garcom>
{
    public string Nome { get; set; }
    public string Cpf { get; set; }

    public Garcom(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }

    //    ○ Nome(mínimo 3 caracteres, máximo 100)
    //○ CPF(formato validado: XXX.XXX.XXX-XX)

    public override void AtualizarRegistro(Garcom registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        Cpf = registroAtualizado.Cpf;
    }

    public override string Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo \"Nome\" deve conter entre 3 e 100 caracteres.";

        if (!Regex.IsMatch(Cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
            erros += "O campo \"CPF\" deve seguir o formato XXX.XXX.XXX-XX.";


        return erros;
    }
}
