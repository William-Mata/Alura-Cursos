using Alura.ByteBank.Dominio.Entidades;

namespace Alura.ByteBank.Testes.Infraestrutura.Servico;

public interface IByteBankRepositorio
{
    public List<Cliente> BuscarClientes();
    public List<Agencia> BuscarAgencias();
    public List<ContaCorrente> BuscarContasCorrentes();
    public bool AdicionarCliente(Cliente cliente);
    public bool AdicionarAgencia(Agencia agencia);
    public bool AdicionarConta(ContaCorrente conta);
}
