using Alura.ByteBank.Testes.Infraestrutura.Servico.DTO;

namespace Alura.ByteBank.Testes.Infraestrutura.Servico;

public interface IPixRepositorio
{
    public PixDTO consultaPix(Guid pix);
    
}
