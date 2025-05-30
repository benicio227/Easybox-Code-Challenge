namespace CaixaFacil.Application.Models;
public class EmpacotamentoViewModel
{
    public int PedidoId {  get; set; }
    public List<CaixaComProdutos> Caixas { get; set; } = new List<CaixaComProdutos>();
}
