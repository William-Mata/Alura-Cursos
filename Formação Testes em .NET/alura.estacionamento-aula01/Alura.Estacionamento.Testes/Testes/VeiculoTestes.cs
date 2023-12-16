using Alura.Estacionamento.Alura.Estacionamento.Modelos.Models;
using Alura.Estacionamento.Alura.Estacionamento.Modelos.Models.Enums;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes.Testes;

public class VeiculoTestes : IDisposable // O metodo implementado da interface Disposable e executado após o teste
{
    private Veiculo veiculo;
    private ITestOutputHelper _output;

    public VeiculoTestes(ITestOutputHelper output)
    {
        veiculo = new Veiculo();
        _output = output;
        _output.WriteLine("Construtor Invocado");
    }

    [Fact(DisplayName = "Teste de acelerar o carro com parametro 10")] // O DisplayName define o nome que será exibido no Teste
    [Trait("Funcionalidade", "Acelerar")] // Trait adiciona uma caracteristica ao teste Trait("chave", "valor")
    public void VeiculoAcelerarComParametro10()
    {
        // PADRÃO AAA

        // ARRANGE

        // ACT
        veiculo.Acelerar(10);

        // ASSERT
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    [Trait("Funcionalidade", "Frear")]
    public void VeiculoFrearComParametro10()
    {
        // ARRANGE

        // ACT
        veiculo.Frear(10);

        // ASSERT
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TipoVeiculoQuandoInstanciadoNovoVeiculo()
    {
        // ARRANGE

        // ACT

        // ASSERT
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    // O Skip possibilita a ignora o teste e define uma mensagem que será exibida no console que pode ser uma explicação.
    [Fact(Skip = "Dessa forma o teste e ignorado")]
    public void NomeProprietarioDoVeiculo()
    {

    }

    // O ClassData utiliza o IEnumerable.GetEnumerator() que fica na classe em que está sendo testada por exemplo o veiculo e retorna um IEnumerator<object[]>
    [Theory]
    [ClassData(typeof(Veiculo))]
    public void VeiculoClass(Veiculo modelo)
    {
        //Arrange

        //Act
        veiculo.Acelerar(10);
        modelo.Acelerar(10);

        //Assert
        Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void InformacoesVeiculo()
    {
        // Arrange
        veiculo.Proprietario = "William";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Preto";
        veiculo.Placa = "ADS-1997";
        veiculo.Modelo = "Honda Civic";

        // Act
        var result = veiculo.ToString();

        // Assert
        Assert.Contains("Tipo do Veiculo: Automovel", result);

    }

    // TESTE DE EXCEPTION
    [Fact]
    public void NomeProprietarioDoVeiculoComDoisCaracteres()
    {
        // Arrange
        var nomeProprietario = "WM";

        // Assert
        Assert.Throws<FormatException>(
                () => new Veiculo(nomeProprietario)
            );

    }

    // TESTE DE EXCEPTION
    [Theory]
    [InlineData("ADS-199")]
    [InlineData("AA3-DA23")]
    [InlineData("ADSA")]
    [InlineData("ADS-213A")]
    public void PlacaDoVeiculoValidacoes(string placa)
    {
        // Arrange
        var nomeProprietario = "WM";

        // Assert
        Assert.Throws<FormatException>(
                () => veiculo.Placa = placa
            );

    }

    public void Dispose()
    {
        _output.WriteLine("Dispose Invocado.");
    }
}