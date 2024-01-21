using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes.Testes;

public class ExtrairPetDoCsvTest
{
    private Arquivo _arquivo;

    public ExtrairPetDoCsvTest()
    {
        _arquivo = new Arquivo("");
    }

    [Fact]
    public void VerificarSeExtracaoDePetDoCsvEValida()
    {
        //Arrange
        var linhaPetTexto = $"{new Guid()}; Pretinha; 1";

        //Act
        Pet pet = _arquivo.ExtrairPetPorLinha(linhaPetTexto);

        // Assert
        Assert.NotNull(pet);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void VerificarErroAoExtrairNullOuVazio(string? linhaPetTexto)
    {
        //Arrange
        //Act
        // Assert
        Assert.ThrowsAny<ArgumentNullException>(() => _arquivo.ExtrairPetPorLinha(linhaPetTexto));
    }

    [Fact]
    public void VerificarErroAoEnviarInformacoesIncompleta()
    {
        //Arrange
        var linhaPetTexto = $"{new Guid()}; 1";

        //Act
        // Assert
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() => _arquivo.ExtrairPetPorLinha(linhaPetTexto));
    }

    [Fact]
    public void VerificarErroAoEnviarGuidInvalido()
    {
        //Arrange
        var linhaPetTexto = $"12321; Pretinha; 1";

        //Act
        // Assert
        Assert.ThrowsAny<ArgumentException>(() => _arquivo.ExtrairPetPorLinha(linhaPetTexto));
    }

    [Fact]
    public void VerificarErroAoEnviarTipoPetnvalido()
    {
        //Arrange
        var linhaPetTexto = $"{new Guid()}; Pretinha; 5";

        //Act
        // Assert
        Assert.ThrowsAny<ArgumentException>(() => _arquivo.ExtrairPetPorLinha(linhaPetTexto));
    }
}
