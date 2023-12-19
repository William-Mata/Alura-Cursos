using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Testes.Infraestrutura.Servico;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Alura.ByteBank.Testes.Infraestrutura;

public class ClienteRepositorioTestes
{
    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly IByteBankRepositorio _byteBankRepositorio;
    public ITestOutputHelper testOutputHelper { get; set; }

    public ClienteRepositorioTestes(ITestOutputHelper testOutputHelperTwo)
    {
        // INJEÇÃO DE DEPENDECIA
        testOutputHelper = testOutputHelperTwo;
        testOutputHelper.WriteLine("Construtor executado com sucesso!");

        var servico = new ServiceCollection();
        servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
        servico.AddTransient<IByteBankRepositorio, ByteBankRepositorio>();
        var provedor = servico.BuildServiceProvider();
        _clienteRepositorio = provedor.GetService<IClienteRepositorio>()!;
        _byteBankRepositorio = provedor.GetService<IByteBankRepositorio>()!;
    }

    [Fact]
    public void TesteObterTodosClientes()
    {
        //Arrange
        //Act
        List<Cliente> clientes = _clienteRepositorio.ObterTodos();

        //Assert
        Assert.NotNull(clientes);
        Assert.True(clientes.Count > 0);
    }


    [Theory]
    [InlineData(1)]
    public void TestarObterClientePorId(int id)
    {
        // Arrange
        // Act
        var cliente = _clienteRepositorio.ObterPorId(id);

        // Assert
        Assert.NotNull(cliente);
    }

    [Fact]
    public void TestarAtualizarCliente()
    {

        //Arrange
        var cliente = _clienteRepositorio.ObterPorId(3);
        cliente.Nome = "Maria";

        //Act
        var atualizado = _clienteRepositorio.Atualizar(3, cliente);

        // Assert
        Assert.True(atualizado);
    }


    [Fact]
    public void TestarAdicionarClienteMoq()
    {
        // Arrange
        var cliente  = new Cliente()
        {
            Nome = "Alex",
            CPF = "110.022.910-89",
            Identificador = Guid.NewGuid(),
            Profissao = "Op. de Empilhadeira",
            Id = 2
        };

        // Act
        var adicionado = _byteBankRepositorio.AdicionarCliente(cliente);

        //Assert 
        Assert.True(adicionado);
    }
}
