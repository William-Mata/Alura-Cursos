using Alura.ByteBank.Dominio.Entidades;

namespace Alura.ByteBank.Testes.Infraestrutura.Servico;

public class ByteBankRepositorio : IByteBankRepositorio
{
    private List<Cliente> _clientes = new List<Cliente>()
    {
        new Cliente()
        {
            Nome = "William",
            CPF = "894.599.480-73",
            Identificador = Guid.NewGuid(),
            Profissao = "Dev",
            Id = 1
        },
        new Cliente()
        {
            Nome = "Maria",
            CPF = "181.514.730-02",
            Identificador = Guid.NewGuid(),
            Profissao = "Cuidadora de Idosos",
            Id = 2
        },
        new Cliente()
        {
            Nome = "Walace",
            CPF = "160.501.120-70",
            Identificador = Guid.NewGuid(),
            Profissao = "Op. de Empilhadeira",
            Id = 2
        }
    };
    private List<Agencia> _agencias = new List<Agencia>()
    {
        new Agencia()
        {
            Nome = "Agencia Central 1",
            Identificador = Guid.NewGuid(),
            Id = 1,
            Endereco= "Rua das Flores,25",
            Numero=147
        },
        new Agencia()
        {
            Nome = "Agencia Central 2",
            Identificador = Guid.NewGuid(),
            Id = 2,
            Endereco= "Rua Gomes de Freitas,418",
            Numero=852
        },
        new Agencia()
        {
            Nome = "Agencia Central 3",
            Identificador = Guid.NewGuid(),
            Id = 3,
            Endereco= "Av. Gumercindo Avides,13",
            Numero=349
        }
    };
    private List<ContaCorrente> _contasCorrentes = new List<ContaCorrente>()
    {
        new ContaCorrente()
        {
            Saldo = 10,
            Id = 1,
            Identificador = Guid.NewGuid(),
            Cliente = new Cliente(){
                    Nome = "Bruce Kent",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Empresário",
                    Id = 1
            },
            Agencia = new Agencia(){
                    Nome = "Agencia Central 1",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco= "Rua das Flores,25",
                    Numero=147
            }
        },
        new ContaCorrente()
        {
            Saldo = 10,
            Id = 2,
            Identificador = Guid.NewGuid(),
            Cliente = new Cliente(){
                    Nome = "Marta Silva",
                    CPF = "877.288.430-44",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Agente de Viagens",
                    Id = 2
            },
            Agencia = new Agencia(){
                Nome = "Agencia Central 2",
                Identificador = Guid.NewGuid(),
                Id = 2,
                Endereco= "Rua Gomes de Freitas,418",
                Numero=852
            }
        }
    };

    public List<Cliente> Clientes { get { return _clientes; }}
    public List<Agencia> Agencias { get { return _agencias; }}
    public List<ContaCorrente> ContasCorrentes { get { return _contasCorrentes; }}

    public List<Cliente> BuscarClientes()
    {
        return Clientes;
    }
    public List<Agencia> BuscarAgencias()
    {
        return Agencias;
    }
    public List<ContaCorrente> BuscarContasCorrentes()
    {
        return ContasCorrentes;
    }
    public bool AdicionarCliente(Cliente cliente)
    {
        try
        {
            this.Clientes.Add(cliente);
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
    public bool AdicionarAgencia(Agencia agencia)
    {
        try
        {
            this.Agencias.Add(agencia);
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
    public bool AdicionarConta(ContaCorrente conta)
    {
        try
        {
            this.ContasCorrentes.Add(conta);
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
}
