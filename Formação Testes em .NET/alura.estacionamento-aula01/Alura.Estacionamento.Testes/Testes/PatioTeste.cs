using Alura.Estacionamento.Alura.Estacionamento.Modelos.Models;
using Alura.Estacionamento.Alura.Estacionamento.Modelos.Models.Enums;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes.Testes;

public class PatioTeste : IDisposable
{
    private Veiculo veiculo;
    private Patio estacionamento;
    private Operador operador;
    ITestOutputHelper _output;

    public PatioTeste(ITestOutputHelper output)
    {
        veiculo = new Veiculo();
        estacionamento = new Patio();
        operador = new Operador();
        operador.Nome = "Manoel";
        estacionamento.Operador = operador;
        _output = output;
        _output.WriteLine("Construtor Invocado");
    }

    [Fact]
    public void RegistrarEntradaVeiculoDoEstacionamento()
    {
        // Arrange
        veiculo.Proprietario = "William";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Preto";
        veiculo.Modelo = "Honda Civic";
        veiculo.Placa = "ADS-2018";

        estacionamento.RegistrarEntradaVeiculo(veiculo);

        //Act 
        var horaEntrada = veiculo.HoraEntrada;

        //Assert
        Assert.NotEqual(horaEntrada, DateTime.MinValue);
    }

    [Fact]
    public void RegistrarSaidaVeiculoDoEstacionamento()
    {
        // Arrange
        veiculo.Proprietario = "William";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Preto";
        veiculo.Modelo = "Honda Civic";
        veiculo.Placa = "ADS-2018";

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act 
        var horaSaida = veiculo.HoraSaida;

        //Assert
        Assert.NotEqual(horaSaida, DateTime.MinValue);
    }

    [Fact]
    public void TotalFaturamentoDoEstcionamento()
    {
        //Arrange
        veiculo.Proprietario = "William";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Preto";
        veiculo.Modelo = "Honda Civic";
        veiculo.Placa = "ADS-2018";

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        var faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2.0, faturamento);
    }

    [Theory] // Dessa forma é executado um teste para cada InlineData
    [InlineData("William", "ADS-2018", "preto", "Honda Civic")]
    [InlineData("Maria", "MSF-2018", "vermelho", "Gol")]
    [InlineData("Walace", "WMS-1989", "prata", "Corola")]
    [InlineData("Alex", "AMS-1989", "cinza", "Jeep Renegade")]
    public void TotalFaturamentoDoEstacionamentoComVariosModelos(string proprietario, string placa, string cor, string modelo)
    {
        // Arrange
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);
    }

    [Theory]
    [InlineData("William", "ADS-2018", "preto", "Honda Civic")]
    public void PesquisarVeiculoPatioPorIdTicket(string proprietario, string placa, string cor, string modelo)
    {
        // Arrange
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        //Act
        var consulta = estacionamento.PesquisarVeiculoPatio(veiculo.IdTicket);

        //Assert
        Assert.Equal(consulta, veiculo.IdTicket);
    }

    [Theory]
    [InlineData("William", "ADS-2018", "preto", "Honda Civic")]
    public void AlterarDadosDoVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
    {
        // Arrange
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        //Act
        var carroAlterar = new Veiculo() { Proprietario = proprietario, };
        carroAlterar.Placa = placa;
        carroAlterar.Cor = "Prata";
        carroAlterar.Modelo = modelo;

        var carroAlterado = estacionamento.AlterarDadosVeiculoPatio(carroAlterar);

        //Assert
        Assert.Equal(carroAlterar.Cor, carroAlterado.Cor);
    }


    [Theory]
    [InlineData("William", "ADS-2018", "preto", "Honda Civic")]
    public void ValidarTicketVeiculo(string proprietario, string placa, string cor, string modelo)
    {
        // Arrange
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;

        // Act
        var ticket = estacionamento.RegistrarEntradaVeiculo(veiculo);

        // Assert
        Assert.Contains(" Ticket Estacionamento Alura ", ticket);
    }

    public void Dispose()
    {
        _output.WriteLine("Dispose Invocado.");
    }
}
