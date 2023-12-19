using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Testes.Infraestrutura.Servico;
using Alura.ByteBank.Testes.Infraestrutura.Servico.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Alura.ByteBank.Testes.Infraestrutura;

public class ContaCorrenteRepositorioTestes
{
    private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
    private readonly IByteBankRepositorio _byteBankRepositorio;

    public ContaCorrenteRepositorioTestes()
    {
        var service = new ServiceCollection();
        service.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
        service.AddTransient<IByteBankRepositorio, ByteBankRepositorio>();
        var provider = service.BuildServiceProvider();
        _contaCorrenteRepositorio = provider.GetService<IContaCorrenteRepositorio>()!;
        _byteBankRepositorio = provider.GetService<IByteBankRepositorio>()!;
    }

    [Fact]
    public void TestarObterTodasContas()
    {
        //Arrange 
        //Act
        var contas = _contaCorrenteRepositorio.ObterTodos();


        //Assert
        Assert.True(contas.Any());
    }

    [Theory]
    [InlineData(96)]
    public void TestarObterContaPorId(int Id)
    {
        //Arrange
        //Act
        var conta = _contaCorrenteRepositorio.ObterPorId(Id);

        // Assert
        Assert.NotNull(conta);
    }

    [Fact]
    public void TestarAtualizarSaldoDeterminadaConta()
    {
        // Arrange
        var conta = _contaCorrenteRepositorio.ObterPorId(96);
        conta.Saldo = 15;

        // Act
        var atualizado = _contaCorrenteRepositorio.Atualizar(96, conta);

        //Assert
        Assert.True(atualizado);
    }

    [Fact]
    public void TestarInserirUmaContaCorrente()
    {
        // Arrange
        var conta = new ContaCorrente()
        {
            Identificador = Guid.NewGuid(),
            PixConta = Guid.NewGuid(),
            Saldo = 100.0d,
            Numero = 2,
            Cliente = new Cliente()
            {
                Identificador = Guid.NewGuid(),
                CPF = "411.867.250-28",
                Nome = "William",
                Profissao = "Dev"
            },
            Agencia = new Agencia()
            {
                Identificador = Guid.NewGuid(),
                Endereco = "Belford Roxo, Xavantes, Adamastor",
                Numero = 2,
                Nome = "Agencia Xavantes"
            } 
        };

        // Act
        var adicionado = _contaCorrenteRepositorio.Adicionar(conta);

        //Assert
        Assert.True(adicionado);
    }

    [Fact]
    public void TestarRemoveConta()
    {
        //Arrange
        //Act
        var removido = _contaCorrenteRepositorio.Excluir(100);

        //Assert
        Assert.True(removido);
    }

    [Fact]
    public void TestarAdicionarContaCorrenteMoq()
    {
        // Arrange
        var conta = new ContaCorrente()
        {
            Saldo = 10,
            Id = 1,
            Identificador = Guid.NewGuid(),
            Cliente = new Cliente()
            {
                Nome = "Bruce Kent",
                CPF = "486.074.980-45",
                Identificador = Guid.NewGuid(),
                Profissao = "Empresário",
                Id = 1
            },
            Agencia = new Agencia()
            {
                Nome = "Agencia Central 1",
                Identificador = Guid.NewGuid(),
                Id = 1,
                Endereco = "Rua das Flores,25",
                Numero = 147
            }
        };

        // Act
        var adicionado = _byteBankRepositorio.AdicionarConta(conta);

        //Assert 
        Assert.True(adicionado);
    }

    [Fact]
    public void TestarConsultaTodosPixStub()
    {
        //Arrange
        var guid = new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a");
        var chavePix = new PixDTO() { Chave = guid, Saldo = 10 };
        var pixRepositorioMock = new Mock<IPixRepositorio>();
        pixRepositorioMock.Setup(x => x.consultaPix(It.IsAny<Guid>())).Returns(chavePix);
        var mock = pixRepositorioMock.Object;

        //Act
        var saldo = mock.consultaPix(guid).Saldo;


        //Assert
        Assert.Equal(10.0d, saldo);
    }
}
