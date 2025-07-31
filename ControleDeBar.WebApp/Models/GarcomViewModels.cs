using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloGarcom;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class CadastrarGarcomViewModel
{
    [Range(1, 1000, ErrorMessage = "O campo \"Número\" precisa conter um valor entre 1 e 1000.")]
    public int Numero { get; set; }

    [Range(1, 1000, ErrorMessage = "O campo \"Capacidade de Lugares\" precisa conter um valor entre 1 e 1000.")]
    public int Capacidade { get; set; }

    public CadastrarGarcomViewModel()
    {
    }
}

public class VisualizarGarcomViewModel
{
    public List<DetalhesGarcomViewModel> Registros { get; set; } = new List<DetalhesGarcomViewModel>();

    public VisualizarGarcomViewModel(List<Garcom> garcons)
    {
        foreach (Garcom g in garcons)
        {
            DetalhesMesaViewModel detalhesVm = new DetalhesGarcomViewModel(
                g.Id,
                g.Nome,
                g.Cpf
            );

            Registros.Add(detalhesVm);
        }
    }
}

public class DetalhesGarcomViewModel
{
    public int Id { get; set; }
    public int Nome { get; set; }
    public int Cpf { get; set; }

    public DetalhesGarcomViewModel(int id, int nome, int cpf)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
    }
}