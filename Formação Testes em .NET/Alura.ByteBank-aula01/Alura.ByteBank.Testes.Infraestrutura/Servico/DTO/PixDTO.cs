namespace Alura.ByteBank.Testes.Infraestrutura.Servico.DTO;

public class PixDTO
{
    private Guid chave;
    private double saldo;
    public Guid Chave { get => chave; set => chave = value; }
    public double Saldo { get => saldo; set => saldo = value; }
}
