using ControleDeBar.ConsoleApp.ModuloProduto;

namespace ControleDeBar.ConsoleApp.ModuloConta;

public class Pedido
{
    public int Id { get; set; }
    public Produto Produto { get; set; }
    public int QuantidadeSolicitada { get; set; }

    private static int contadorIds = 0;

    public Pedido(Produto produto, int quantidadeEscolhida)
    {
        Id = ++contadorIds;
        Produto = produto;
        QuantidadeSolicitada = quantidadeEscolhida;
    }

    public decimal CalcularTotalParcial()
    {
        return Produto.Valor * QuantidadeSolicitada;
    }

    public override string ToString()
    {
        return $"{QuantidadeSolicitada} x {Produto.Nome}";
    }
}