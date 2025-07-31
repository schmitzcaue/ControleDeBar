using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloGarcoma;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class GarcomController : Controller
{
    private readonly RepositorioGarcomEmArquivo repositorioGarcom;

    public GarcomController()
    {
        ContextoDados contexto = new ContextoDados(carregarDados: true);

        repositorioGarcom = new RepositorioGarcomEmArquivo(contexto);
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Garcom> garcons = repositorioGarcom.SelecionarRegistros();

        VisualizarGarcomViewModel visualizarVm = new VisualizarGarcomViewModel(garcons);

        return View(visualizarVm);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        CadastrarGarcomViewModel cadastrarVm = new CadastrarGarcomViewModel();

        return View(cadastrarVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarGarcomViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        var entidade = new Garcom(cadastrarVm.Nome, cadastrarVm.Cpf);

        repositorioGarcom.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }
}