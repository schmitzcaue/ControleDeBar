using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloGarcoma;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController : Controller
{
    private readonly RepositorioGarcomEmArquivo repositorioGarcom;

    public MesaController()
    {
        ContextoDados contexto = new ContextoDados(carregarDados: true);

        repositorioGarcom = new RepositorioGarcomEmArquivo(contexto);
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Mesa> mesas = repositorioGarcom.SelecionarRegistros();

        VisualizarMesasViewModel visualizarVm = new VisualizarGarcomViewModel(mesas);

        return View(visualizarVm);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        CadastrarMesaViewModel cadastrarVm = new CadastrarMesaViewModel();

        return View(cadastrarVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarMesaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        var entidade = new Mesa(cadastrarVm.Numero, cadastrarVm.Capacidade);

        repositorioMesa.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }
}