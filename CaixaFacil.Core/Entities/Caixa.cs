namespace CaixaFacil.Core.Entities;
public class Caixa
{
    public int Id { get; set; }
    public string Name {  get;  set; }
    public double Altura {  get;  set; }
    public double Largura {  get;  set; }
    public double Comprimento {  get; set; }

    public double Volume => Altura * Largura * Comprimento;
}
