namespace ByteBankIO.Models;

public class Botao
{
    public string? Texto { get; set; }
    public string? Cor { get; set; }


    public Botao(string texto, string cor)
    {
        Texto = texto;
        Cor = cor;
    }
}
