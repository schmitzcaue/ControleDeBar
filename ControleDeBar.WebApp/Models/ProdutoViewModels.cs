using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloProduto;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class CadastrarProdutoViewModel
{

    [Range(1, 1000, ErrorMessage = "O campo \"Nome\" precisa conter um valor entre 1 e 100.")]
    public string Nome { get; set; }

    [Range(1, 1000, ErrorMessage = "O campo \"Preço\" precisa conter um valor entre 1 e 1000.")]
    public Decimal Preco { get; set; }

    public CadastrarProdutoViewModel()
    {
    }
}

public class EditarProdutoViewModel
{
    public int Id { get; set; }

    [Range(1, 1000, ErrorMessage = "O campo \"Nome\" precisa conter um valor entre 1 e 100.")]
    public string Nome { get; set; }

    [Range(1, 1000, ErrorMessage = "O campo \"Preço\" precisa conter um valor entre 1 e 1000.")]
    public Decimal Preco { get; set; }

    public EditarProdutoViewModel() { }

    public EditarProdutoViewModel(int id, string nome, Decimal preco)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
    }
}

public class ExcluirProdutoViewModel
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public ExcluirProdutoViewModel() { }

    public ExcluirProdutoViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarProdutosViewModel
{
    public List<DetalhesProdutoViewModel> Registros { get; set; } = new List<DetalhesProdutoViewModel>();

    public VisualizarProdutosViewModel(List<Produto> produtos)
    {
        foreach (Produto p in produtos)
        {
            DetalhesProdutoViewModel detalhesVm = new DetalhesProdutoViewModel(
                p.Id,
                p.Nome,
                p.Preco
            );

            Registros.Add(detalhesVm);
        }
    }
}

public class DetalhesProdutoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public DetalhesProdutoViewModel(int id, string nome, decimal preco)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
    }
}