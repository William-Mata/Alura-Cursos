using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Testes.Infraestrutura.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Abstractions;

namespace Alura.ByteBank.Testes.Infraestrutura;

public class AgenciaRepositorioTestes
{
    private readonly IAgenciaRepositorio _agenciaRepositorio;
    private readonly IByteBankRepositorio _byteBankRepositorio;
    public ITestOutputHelper testOutputHelper { get; set; }

    public AgenciaRepositorioTestes(ITestOutputHelper testOutputHelperTwo)
    {
        testOutputHelper = testOutputHelperTwo;
        testOutputHelper.WriteLine("Construtor executado com sucesso!");

        var servico = new ServiceCollection();
        servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
        servico.AddTransient<IByteBankRepositorio, ByteBankRepositorio>();
        var provedor = servico.BuildServiceProvider();
        _agenciaRepositorio = provedor.GetService<IAgenciaRepositorio>()!;
        _byteBankRepositorio = provedor.GetService<IByteBankRepositorio>()!;
    }

    [Fact]
    public void TestarObterTodasAgencias()
    {
        //Arrange
        //Act
        var agencias = _agenciaRepositorio.ObterTodos();
        
        // Assert
        Assert.True(agencias.Any());
    }

    [Theory]
    [InlineData(2)]
    public void TestarBuscarAgenciaPorId(int id)
    {
        //Arrange
        //Act
        var agencia = _agenciaRepositorio.ObterPorId(id);

        // Assert
        Assert.NotNull(agencia);
    }


    [Fact]
    public void TestarAtualizarAgencia() 
    {
        //Arrange
        var agencia = _agenciaRepositorio.ObterPorId(3);
        agencia.Endereco = "Alagoas, Matriz de Macaragibe";

        //Act
        var atualizado = _agenciaRepositorio.Atualizar(3, agencia);

        // Assert
        Assert.True(atualizado);
    }


    [Fact]
    public void TestarExcecaoObterAgenciaPorId()
    {
        //Act
        //Assert
        Assert.Throws<Exception>(() =>
        {
            _agenciaRepositorio.ObterPorId(99);
        });
    }


    [Fact]
    public void TestarAdicionarAgenciaMoq()
    {
        // Arrange
        var agencia = new Agencia()
        {
            Nome = "Agencia Central 5",
            Identificador = Guid.NewGuid(),
            Id = 1,
            Endereco = "Av Adamastor, 33",
            Numero = 33
        };

        // Act
        var adicionado = _byteBankRepositorio.AdicionarAgencia(agencia);

        //Assert 
        Assert.True(adicionado);
    }


    [Fact]
    public void TestarObterAgenciaPorIdMoq()
    {
        //Arrange
        var bytebanckRepositorioMock = new Mock<IByteBankRepositorio>();
        var mock = bytebanckRepositorioMock.Object;

        //Act
        var lista = mock.BuscarAgencias();

        //Assert
        bytebanckRepositorioMock.Verify(b => b.BuscarAgencias());
        
    }
}